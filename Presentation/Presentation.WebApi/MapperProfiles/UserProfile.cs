using AutoMapper;
using Domain.Model.Models;
using Domain.Model.Schemas;
using Presentation.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebApi.MapperProfiles {
    public class UserProfile: Profile {
        public UserProfile() {
            CreateMap<UserModel, UserViewModel>();

            CreateMap<ChangePasswordBindingModel, ChangePasswordSchema>();
            CreateMap<EditProfileBindingModel, UserEditSchema>();
            CreateMap<UserLoginBindingModel, UserLoginSchema>();
            CreateMap<UserLoginBindingModel, UserNextStepLoginSchema>();
            CreateMap<UserRegisterBindingModel, UserRegisterSchema>();
            CreateMap<UserSyncBindingModel, UserSyncSchema>();
            CreateMap<HeaderBindingModel, UserGetSchema>();
            CreateMap<AvatarBindingModel, UserGetSchema>();
        }
    }
}
