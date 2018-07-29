using Shared.Utility;
using Shared.Utility._App;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Schemas {
    [Schema("[dbo].[API_User_Register]")]
    public class UserRegisterSchema: IBaseSchema {
        [InputParameter]
        public string Phone { get; set; }
        [InputParameter]
        public string Email { get; set; }
        [InputParameter]
        public byte? IdentityProvider { get; set; }
        [InputParameter]
        public string IP { get; set; }
        [InputParameter]
        public string DeviceId { get; set; }
        [InputParameter]
        public string OS { get; set; }
        [InputParameter]
        public string Version { get; set; }
        [InputParameter]
        public string DeviceName { get; set; }
        [InputParameter]
        public string Browser { get; set; }

        [OutputParameter]
        public short @Token { get; set; }
        [OutputParameter]
        public short @StatusCode { get; set; }
    }
    [Schema("[dbo].[API_User_ChangePassword]")]
    public class ChangePasswordSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public string @CurrentPassword { get; set; }
        [InputParameter]
        public string @NewPassword { get; set; }

        [OutputParameter]
        public short @StatusCode { get; set; }
    }
    [Schema("[dbo].[API_User_Edit]")]
    public class UserEditSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public string @NickName { get; set; }
        [InputParameter]
        public string @Avatar { get; set; }

        [OutputParameter]
        public short @StatusCode { get; set; }
    }
    [Schema("[dbo].[API_User_Login]")]
    public class UserLoginSchema: IBaseSchema {
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public string @UserName { get; set; }
        [InputParameter]
        public string @Phone { get; set; }
        [InputParameter]
        public string @Email { get; set; }
        [InputParameter]
        public string @ActivationCode { get; set; }

        [OutputParameter]
        public short @Token { get; set; }
        [OutputParameter]
        public short @StatusCode { get; set; }
    }
    [Schema("[dbo].[API_User_LoginNextStep]")]
    public class UserNextStepLoginSchema: IBaseSchema {
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public string @UserName { get; set; }
        [InputParameter]
        public string @Phone { get; set; }
        [InputParameter]
        public string @Email { get; set; }
        [InputParameter]
        public string @Password { get; set; }

        [OutputParameter]
        public short @Token { get; set; }
        [OutputParameter]
        public short @StatusCode { get; set; }
    }
    [Schema("[dbo].[API_User_Sync]")]
    public class UserSyncSchema: IBaseSchema {
        [InputParameter]
        public string @Provider { get; set; }
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public string @OS { get; set; }
        [InputParameter]
        public string @Version { get; set; }
        [InputParameter]
        public string @DeviceName { get; set; }
        [InputParameter]
        public string @Browser { get; set; }
        [InputParameter]
        public string @IP { get; set; }

        [OutputParameter]
        public short @StatusCode { get; set; }
    }
    [Schema("[dbo].[API_User_Get]")]
    public class UserGetSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }

        [OutputParameter]
        public short @StatusCode { get; set; }
    }
}
