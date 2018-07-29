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
    public class MatchController: BaseController {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly IExceptionService _exceptionService;
        private readonly IMatchService _matchService;
        private readonly IPredictionService _predictionService;
        public MatchController(IMatchService pridctService, IMapper mapper, IExceptionService exceptionService, IPredictionService predictionService) {
            _mapper = mapper;
            _exceptionService = exceptionService;
            _matchService = pridctService;
            _predictionService = predictionService;
        }
        #endregion

        [HttpGet("get")]
        [ArgumentBinding]
        public async Task<IActionResult> GetAll([FromQuery]MatchBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            try {
                var model = _mapper.Map<MatchGetPagingSchema>(collection);
                var result = await _matchService.GetPagingAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok(data: _mapper.Map<IList<MatchViewModel>>(result), totalPages: collection.TotalPages(model.RowsCount));
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

        [HttpPost]
        [Route("predict")]
        [ArgumentBinding]
        public async Task<IActionResult> Predict([FromBody]PredictionBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            if (collection.HomeClubScore < 0 || collection.AwayClubScore < 0)
                return BadRequest("امکان ثبت امتیاز منفی وجود ندارد");
            try {
                var model = _mapper.Map<MatchPredictSchema>(collection);
                await _matchService.Predict(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok();
                    case -1:
                    case -101:
                    case -104:
                    case -107:
                        return BadRequest(GeneralMessage.UserNotFound);
                    case -2:
                    case -102:
                    case -105:
                    case -108:
                        return BadRequest(GeneralMessage.UserIsNotActive);
                    case -3:
                    case -103:
                    case -106:
                    case -109:
                        return BadRequest(GeneralMessage.UserNotFound);
                    case -4:
                        return BadRequest("کاربر ناشناس");
                    case -5:
                        return BadRequest("رویداد یافت نشد");
                    case -6:
                        return BadRequest("رویداد فعال نمی باشد");
                    case -7:
                        return BadRequest("تاریخ شروع رویداد فرا نرسیده است");
                    case -8:
                        return BadRequest("مسابقه یافت نشد");
                    case -9:
                        return BadRequest("مسابقه فعال نمی باشد");
                    case -10:
                        return BadRequest("تاریخ مسابقه گذشته است");
                    case -11:
                        return BadRequest("تاریخ پیش بینی گذشته است");
                    case -12:
                        return BadRequest("تیم میزبان یافت نشد");
                    case -13:
                        return BadRequest("تیم میزبان فعال نمی باشد");
                    case -14:
                        return BadRequest("تیم میهمان یافت نشد");
                    case -15:
                        return BadRequest("تیم میهمان فعال نمی باشد");
                    case -16:
                        return BadRequest("بازیکن انتخاب شده یافت نشد");
                    case -17:
                        return BadRequest("بازیکن انتخاب شده فعال نمی باشد");
                    case -18:
                        return BadRequest("ارتباطی بین مسابقه و تیم ها یافت نشد");
                    case -19:
                        return BadRequest("شما تمام پیش بینی های خود را برای این مسابقه انجام داده اید");
                }
            }
            catch (Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [HttpGet("getgroups")]
        [ArgumentBinding]
        public async Task<IActionResult> GetAllGroups([FromQuery]MatchGroupBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            try {
                var model = _mapper.Map<MatchGroupGetPagingSchema>(collection);
                var result = await _matchService.GroupsGetPagingAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok(data: _mapper.Map<IList<MatchGroupViewModel>>(result), totalPages: collection.TotalPages(model.RowsCount));
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