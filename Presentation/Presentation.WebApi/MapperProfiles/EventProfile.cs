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
    public class EventProfile: Profile {
        public EventProfile() {
            CreateMap<EventModel, EventViewModel>()
                .ForMember(d => d.StartedAt, s => s.MapFrom(mf => mf.StartedAt.UnixTimestampFromDateTime()))
                .ForMember(d => d.EndedAt, s => s.MapFrom(mf => mf.EndedAt.UnixTimestampFromDateTime()));
            CreateMap<EventBindingModel, EventGetPagingSchema>()
                .ForMember(d => d.FromDate, s => s.MapFrom(mf => mf.FromDate.DateTimeFromUnix()))
                .ForMember(d => d.ToDate, s => s.MapFrom(mf => mf.ToDate.DateTimeFromUnix()));
        }
    }
}
