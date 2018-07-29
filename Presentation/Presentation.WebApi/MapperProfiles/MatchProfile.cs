using AutoMapper;
using Domain.Model.Models;
using Domain.Model.Schemas;
using Presentation.WebApi.Models;
using Shared.Utility._App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebApi.MapperProfiles
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<PredictionBindingModel, MatchPredictSchema>();
            CreateMap<MatchModel, MatchViewModel>()
                .ForMember(d => d.OccurrenceDate, s => s.MapFrom(mf => mf.OccurrenceDate.UnixTimestampFromDateTime()))
                .ForMember(d => d.PredictionDeadline, s => s.MapFrom(mf => mf.PredictionDeadline.UnixTimestampFromDateTime()));
            CreateMap<MatchBindingModel, MatchGetPagingSchema>()
                .ForMember(d => d.FromDate, s => s.MapFrom(mf => mf.FromDate.DateTimeFromUnix()))
                .ForMember(d => d.ToDate, s => s.MapFrom(mf => mf.ToDate.DateTimeFromUnix()));
        }
    }
}
