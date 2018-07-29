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
    public class ChangeMeController: BaseController {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly IExceptionService _exceptionService;
        private readonly IChangeMeService _changeMeService;
        public ChangeMeController(IChangeMeService changeMeService, IMapper mapper, IExceptionService exceptionService) {
            _mapper = mapper;
            _exceptionService = exceptionService;
            _changeMeService = changeMeService;
        }
        #endregion

        [HttpGet("get")]
        [ArgumentBinding]
        public async Task<IActionResult> GetAll([FromQuery]MatchGroupBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            try {
                var model = _mapper.Map<MatchGroupGetPagingSchema>(collection);
                //var result = await _changeMeService.GetPagingAsync(model);
                //switch (model.StatusCode) {
                //    case 1:
                //        return Ok(data: _mapper.Map<IList<MatchGroupViewModel>>(result), totalPages: collection.TotalPages(model.RowsCount));
                //    case -1:
                //        return BadRequest(GeneralMessage.UserNotFound);
                //    case -2:
                //        return BadRequest(GeneralMessage.UserIsNotActive);
                //    case -3:
                //        return BadRequest(GeneralMessage.PhoneIsNotVerified);
                //}
            }
            catch (Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }
    }
}