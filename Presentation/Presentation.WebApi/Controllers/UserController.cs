using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Application;
using Domain.Model.Schemas;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.FilterAttributes;
using Presentation.WebApi.Models;
using Shared.Utility;
using Shared.Utility._App;
using System.Drawing.Imaging;

namespace Presentation.WebApi.Controllers {
    public class UserController: BaseController {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly IExceptionService _exceptionService;
        private readonly IUserService _userService;
        public UserController(IMapper mapper, IExceptionService exceptionService, IUserService userService) {
            _mapper = mapper;
            _exceptionService = exceptionService;
            _userService = userService;
        }
        #endregion

        [HttpGet("get")]
        [ArgumentBinding]
        public async Task<IActionResult> Get([FromQuery]HeaderBindingModel collection) {
            try {
                var model = _mapper.Map<UserGetSchema>(collection);
                var user = await _userService.GetAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        user.Avatar = string.IsNullOrWhiteSpace(user.Avatar) ? null : $"{AppSettings.FileUrl}/avatars/{user.Avatar}";
                        return Ok(data: _mapper.Map<UserViewModel>(user));
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

        [HttpPost("changepassword")]
        [ArgumentBinding]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            try {
                var model = _mapper.Map<ChangePasswordSchema>(collection);
                await _userService.ChangePasswordAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok();
                    case -1:
                        return BadRequest(GeneralMessage.UserNotFound);
                    case -2:
                        return BadRequest(GeneralMessage.UserIsNotActive);
                    case -3:
                        return BadRequest("گذرواژه اشتباه است");
                }
            }
            catch (Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [HttpPost("edit")]
        [ArgumentBinding]
        public async Task<IActionResult> Edit([FromBody]EditProfileBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);

            if (!string.IsNullOrWhiteSpace(collection.Avatar) && collection.Avatar.ToLower() != "remove") {
                return BadRequest("درخواست غیر مجاز!");
            }
            if (string.IsNullOrWhiteSpace(collection.NickName) && string.IsNullOrWhiteSpace(collection.Avatar)) {
                return BadRequest("نام مستعار خود را وارد نمایید");
            }
            if (collection.Avatar == string.Empty) {
                collection.Avatar = null;
            }
            try {
                var model = _mapper.Map<UserEditSchema>(collection);
                await _userService.EditAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok();
                    case -1:
                        return BadRequest(GeneralMessage.UserNotFound);
                    case -2:
                        return BadRequest(GeneralMessage.UserIsNotActive);
                }
            }
            catch (Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [HttpPost("avatar")]
        [ArgumentBinding]
        public async Task<IActionResult> Avatar([FromForm]AvatarBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            try {
                var model = _mapper.Map<UserGetSchema>(collection);
                var user = await _userService.GetAsync(model);
                switch (model.StatusCode) {
                    case -1:
                        return BadRequest(GeneralMessage.UserNotFound);
                    case -2:
                        return BadRequest(GeneralMessage.UserIsNotActive);
                    case -3:
                        return BadRequest(GeneralMessage.PhoneIsNotVerified);
                }
                using (var memoryStream = new MemoryStream()) {
                    await collection.Avatar.CopyToAsync(memoryStream);
                    if (memoryStream.ToArray().Length == 0) {
                        return BadRequest("فایل فاقد محتوی می باشد");
                    }
                    if (memoryStream.ToArray().Length > int.Parse(AppSettings.AvatarSize) * 1024) {
                        return BadRequest("حجم تصویر شما بیشتر از میزان مجاز است");
                    }
                    var image = new Bitmap(memoryStream);
                    if (!ImageFormats.Contains(image.RawFormat)) {
                        return BadRequest("نوع تصویر شما از انواع مجاز نمی باشد");
                    }
                    var avatarResolution = AppSettings.AvatarResolution.Split('x');
                    if (image.Width * image.Height > int.Parse(avatarResolution[0]) * int.Parse(avatarResolution[1])) {
                        return BadRequest("اندازه تصویر شما بزرگتر از میزان مجاز است");
                    }
                    if (!Directory.Exists(AppSettings.FilePath))
                        Directory.CreateDirectory(AppSettings.FilePath);
                    image.Save($@"{AppSettings.FilePath}\{user.UserName}.jpeg", ImageFormat.Jpeg);
                }
                var editModel = new UserEditSchema { Token = collection.Token, DeviceId = collection.DeviceId, Avatar = $"{user.UserName}.jpeg" };
                await _userService.EditAsync(editModel);
                switch (model.StatusCode) {
                    case 1:
                        return Ok();
                }
            }
            catch (Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [HttpPost("login")]
        [ArgumentBinding]
        public async Task<IActionResult> Login([FromBody]UserLoginBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            if (string.IsNullOrWhiteSpace(collection?.UserName) && string.IsNullOrWhiteSpace(collection?.Phone) && string.IsNullOrWhiteSpace(collection?.Email))
                return BadRequest(GeneralMessage.DefectiveEntry);
            if (string.IsNullOrWhiteSpace(collection?.ActivationCode))
                return BadRequest("کد فعال سازی را وارد نمایید");
            try {
                var model = _mapper.Map<UserLoginSchema>(collection);
                await _userService.LoginAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok(data: new { model.Token });
                    case 2:
                        return Ok(status: HttpStatusCode.Accepted, message: "اعتبار سنجی دو مرحله ای فعال می باشد");
                    case -1:
                        return BadRequest(GeneralMessage.DefectiveEntry);
                    case -2:
                        return BadRequest("نام کاربری و یا کد فعال ساز شما اشتباه است");
                    case -3:
                        return BadRequest("تلفن و یا کد فعال ساز شما اشتباه است");
                    case -4:
                        return BadRequest("ایمیل و یا کد فعال ساز شما اشتباه است");
                    case -5:
                        return BadRequest(GeneralMessage.DeviceIdNotFound);
                }
            }
            catch (Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [HttpPost("loginnextstep")]
        [ArgumentBinding]
        public async Task<IActionResult> LoginNextStep([FromBody]UserLoginBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            if (string.IsNullOrWhiteSpace(collection?.UserName) && string.IsNullOrWhiteSpace(collection?.Phone) && string.IsNullOrWhiteSpace(collection?.Email))
                return BadRequest(GeneralMessage.DefectiveEntry);
            if (string.IsNullOrWhiteSpace(collection?.Password))
                return BadRequest("گذرواژه را وارد نمایید");
            try {
                var model = _mapper.Map<UserNextStepLoginSchema>(collection);
                await _userService.LoginAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok(data: new { model.Token });
                    case 2:
                        return Ok(status: HttpStatusCode.Accepted, message: "اعتبار سنجی دو مرحله ای فعال می باشد");
                    case -1:
                        return BadRequest(GeneralMessage.DefectiveEntry);
                    case -2:
                        return BadRequest("نام کاربری یا گذرواژه شما اشتباه است");
                    case -3:
                        return BadRequest("تلفن یا گذرواژه شما اشتباه است");
                    case -4:
                        return BadRequest("ایمیل یا گذرواژه شما اشتباه است");
                    case -5:
                        return BadRequest(GeneralMessage.DeviceIdNotFound);
                    case -6:
                        return BadRequest("شما ابتدا می بایست با کد فعال ساز اقدام به ورود نمایید");
                }
            }
            catch (Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [HttpPost("register")]
        [ArgumentBinding]
        public async Task<IActionResult> Register([FromBody]UserRegisterBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            if (string.IsNullOrWhiteSpace(collection?.Phone) && string.IsNullOrWhiteSpace(collection?.Email))
                return BadRequest(GeneralMessage.DefectiveEntry);
            try {
                var model = _mapper.Map<UserRegisterSchema>(collection);
                model.IP = IP;
                await _userService.RegisterAsync(model);
                switch (model.StatusCode) {
                    case 1:
                        return Ok(data: model.Token);
                    case 2:
                        return Ok(status: HttpStatusCode.Accepted, message: "اعتبار سنجی دو مرحله ای فعال می باشد");
                    case -1:
                        return BadRequest(GeneralMessage.DefectiveEntry);
                    case -2:
                        return BadRequest("نام کاربری و یا کد فعال ساز شما اشتباه است");
                    case -3:
                        return BadRequest("تلفن و یا کد فعال ساز شما اشتباه است");
                    case -4:
                        return BadRequest("ایمیل و یا کد فعال ساز شما اشتباه است");
                    case -5:
                        return BadRequest(GeneralMessage.DeviceIdNotFound);
                }
            }
            catch (Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [HttpPost("sync")]
        [ArgumentBinding]
        public async Task<IActionResult> Sync([FromBody]UserSyncBindingModel collection) {
            if (string.IsNullOrWhiteSpace(collection?.Token))
                return BadRequest(GeneralMessage.TokenNotFound);
            if (string.IsNullOrWhiteSpace(collection?.DeviceId))
                return BadRequest(GeneralMessage.DeviceIdNotFound);
            try {
                var model = _mapper.Map<UserSyncSchema>(collection);
                model.IP = IP;
                await _userService.SyncAsync(model);
                switch (model.StatusCode) {
                    case 1:
                    case 2:
                    case 3:
                        return Ok();
                    case -1:
                    case -5:
                    case -9:
                    case -13:
                        return BadRequest(GeneralMessage.UserNotFound);
                    case -2:
                    case -6:
                    case -10:
                    case -14:
                        return BadRequest(GeneralMessage.UserIsNotActive);
                    case -3:
                    case -7:
                    case -11:
                    case -15:
                        return BadRequest("کاربر فاقد شماره تلفن می باشد");
                    case -4:
                    case -8:
                    case -12:
                    case -16:
                        return BadRequest(GeneralMessage.PhoneIsNotVerified);
                    case -17:
                        return BadRequest("پروایدر ارسالی معتبر نیست");
                }
            }
            catch (Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }
    }
}