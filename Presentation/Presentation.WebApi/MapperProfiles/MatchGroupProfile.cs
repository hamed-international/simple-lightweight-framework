using AutoMapper;
using Domain.Model.Models;
using Domain.Model.Schemas;
using Presentation.WebApi.Models;
using Shared.Utility._App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebApi.MapperProfiles {
    public class ChangeMeProfile: Profile {
        public ChangeMeProfile() {
            CreateMap<MatchGroupBindingModel, MatchGroupGetPagingSchema>();
            CreateMap<MatchGroupModel, MatchGroupViewModel>();
        }
    }
}
