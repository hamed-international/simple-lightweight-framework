using AutoMapper;
using Presentation.WebApi.MapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebApi.Infrastructures {
    public class MapperConfig {
        public MapperConfiguration Init() {
            return new MapperConfiguration(mc => {
                mc.AddProfile<UserProfile>();
                mc.AddProfile<MatchProfile>();
                mc.AddProfile<ChangeMeProfile>();
                mc.AddProfile<EventProfile>();
                mc.AddProfile<PredictionProfile>();
            });
        }
    }
}
