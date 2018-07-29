using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Application;
using Domain.Model.Schemas;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.FilterAttributes;
using Presentation.WebApi.Models;
using Shared.Utility;

namespace Presentation.WebApi.Controllers {
    public class EventController: BaseController {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly IExceptionService _exceptionService;
        private readonly IEventService _eventService;
        public EventController(IEventService eventService, IMapper mapper, IExceptionService exceptionService) {
            _mapper = mapper;
            _exceptionService = exceptionService;
            _eventService = eventService;
        }
        #endregion

        [HttpGet("get")]
        [ArgumentBinding]
        public async Task<IActionResult> GetAll([FromQuery]EventBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            try {
                var model = _mapper.Map<EventGetPagingSchema>(collection);
                var result = await _eventService.GetPagingAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok(data: _mapper.Map<IEnumerable<EventViewModel>>(result), totalPages: collection.TotalPages(model.RowsCount));
                    case -1:
                        return BadRequest(GeneralMessage.UserNotFound);
                    case -2:
                        return BadRequest(GeneralMessage.UserIsNotActive);
                    case -3:
                        return BadRequest(GeneralMessage.PhoneIsNotVerified);
                }
            }
            catch (Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }
    }
}
