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
    public class PredictionController: BaseController {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly IExceptionService _exceptionService;
        private readonly IPredictionService _predictionService;
        public PredictionController(IMapper mapper, IExceptionService exceptionService, IPredictionService predictionService) {
            _mapper = mapper;
            _exceptionService = exceptionService;
            _predictionService = predictionService;
        }
        #endregion

        [HttpGet("get")]
        [ArgumentBinding]
        public async Task<IActionResult> GetPaging([FromQuery]MatchBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            try {
                var model = _mapper.Map<PredictionGetPagingSchema>(collection);
                var result = await _predictionService.GetPagingAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok(data: _mapper.Map<IEnumerable<PredictionViewModel>>(result), totalPages: collection.TotalPages(model.RowsCount));
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

        [HttpGet("getleaderboard")]
        [ArgumentBinding]
        public async Task<IActionResult> GetLeaderboard([FromQuery]LeaderboardBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            if (collection?.EventId < 1)
                return BadRequest("شناسه رویداد را وارد نمایید");
            try {
                var model = _mapper.Map<GetLeaderboardSchema>(collection);
                var result = await _predictionService.GetLeaderboardPagingAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok(data: new {
                            Leaderboard = _mapper.Map<IList<LeaderboardViewModel>>(result),
                            MyPosition = new { model.MyRank, model.MyPoint }
                        }, totalPages: collection.TotalPages(model.RowsCount));
                    case -1:
                        return BadRequest(GeneralMessage.UserNotFound);
                    case -2:
                        return BadRequest(GeneralMessage.UserIsNotActive);
                    case -3:
                        return BadRequest(GeneralMessage.UserNotFound);
                    case -4:
                        return BadRequest("رویداد یافت نشد");
                    case -5:
                        return BadRequest("رویداد فعال نمی باشد");
                    case -6:
                        return BadRequest("دسته بندی انتخابی وجود ندارد");
                }
            }
            catch (Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [HttpGet("predictedcount")]
        [ArgumentBinding]
        public async Task<IActionResult> GetPredictedCount([FromQuery]PredictedCountBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            try {
                var model = _mapper.Map<PredictedCountSchema>(collection);
                await _predictionService.GetPredictedCountAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok(data: new { model.MatchCount, model.TotalPredicted });
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

        [HttpGet("mostpredicted")]
        [ArgumentBinding]
        public async Task<IActionResult> GetMostPredicted([FromQuery]MostPredictedBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            try {
                var model = _mapper.Map<MostPredictedSchema>(collection);
                var result = await _predictionService.GetMostPredictedAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok(data: _mapper.Map<IList<MostPredictedViewModel>>(result));
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

        [HttpPost("edit")]
        [ArgumentBinding]
        public async Task<IActionResult> EditAsync([FromBody]EditPredictionBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            try {
                var model = _mapper.Map<EditPredictionSchema>(collection);
                await _predictionService.EditAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok();
                    case -1:
                        return BadRequest(GeneralMessage.UserNotFound);
                    case -2:
                        return BadRequest(GeneralMessage.UserIsNotActive);
                    case -3:
                        return BadRequest(GeneralMessage.PhoneIsNotVerified);
                    case -4:
                        return BadRequest("پیشبینی یافت نشد");
                    case -5:
                        return BadRequest("شما فقط قادر به ویرایش پیشبینی های خود می باشید");
                    case -6:
                        return BadRequest("مسابقه فعال نمی باشد");
                    case -7:
                        return BadRequest("تاریخ پیشبینی گذشته است");
                }
            }
            catch (Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }
    }
}