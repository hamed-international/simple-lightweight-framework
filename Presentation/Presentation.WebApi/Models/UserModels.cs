using Microsoft.AspNetCore.Http;

namespace Presentation.WebApi.Models {
    public class UserSyncBindingModel: FullHeaderBindingModel {
        public string Provider { get; set; }
    }
    public class ChangePasswordBindingModel: HeaderBindingModel {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class EditProfileBindingModel: HeaderBindingModel {
        public string NickName { get; set; }
        public string Avatar { get; set; }
    }
    public class AvatarBindingModel: HeaderBindingModel {
        public IFormFile Avatar { get; set; }
    }
    public class UserLoginBindingModel: IBaseViewModel {
        public string DeviceId { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ActivationCode { get; set; }
        public string Password { get; set; }
    }
    public class UserRegisterBindingModel: IBaseViewModel {
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte? IdentityProvider { get; set; }
        public string IP { get; set; }
        public string DeviceId { get; set; }
        public string OS { get; set; }
        public string Version { get; set; }
        public string DeviceName { get; set; }
        public string Browser { get; set; }
    }
    public class UserViewModel: IBaseViewModel {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
    }
}
