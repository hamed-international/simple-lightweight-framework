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
    public class PredictionProfile : Profile
    {
        public PredictionProfile()
        {
            CreateMap<LeaderboardBindingModel, GetLeaderboardSchema>();
            CreateMap<LeaderboardModel, LeaderboardViewModel>();

            CreateMap<PredictionModel, PredictionViewModel>()
                .ForMember(d => d.OccurrenceDate, s => s.MapFrom(mf => mf.OccurrenceDate.UnixTimestampFromDateTime()));
            CreateMap<MatchBindingModel, PredictionGetPagingSchema>()
                .ForMember(d => d.FromDate, s => s.MapFrom(mf => mf.FromDate.DateTimeFromUnix()))
                .ForMember(d => d.ToDate, s => s.MapFrom(mf => mf.ToDate.DateTimeFromUnix()));

            CreateMap<PredictedCountBindingModel, PredictedCountSchema>();
            CreateMap<EditPredictionBindingModel, EditPredictionSchema>();

            CreateMap<MostPredictedBindingModel, MostPredictedSchema>();
            CreateMap<MostPredictedModel, MostPredictedViewModel>();
        }
    }
}
