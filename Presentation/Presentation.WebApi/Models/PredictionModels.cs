using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebApi.Models {
    public class PredictionBindingModel: HeaderBindingModel {
        public int MatchId { get; set; }
        public int HomeClubId { get; set; }
        public int HomeClubScore { get; set; }
        public int AwayClubId { get; set; }
        public int AwayClubScore { get; set; }
        public byte? Sets { get; set; }
        public int? ClubMemberId { get; set; }
    }
    public class PredictedCountBindingModel: HeaderBindingModel {
        public int EventId { get; set; }
    }
    public class MostPredictedBindingModel: HeaderBindingModel {
        public int MatchId { get; set; }
    }
    public class PredictionViewModel: IBaseViewModel {
        public int? Id { get; set; }
        public string Title { get; set; }
        public long? OccurrenceDate { get; set; }
        public int? HomeClubId { get; set; }
        public string HomeClubName { get; set; }
        public int? HomeClubPredictedScore { get; set; }
        public int? HomeClubResultScore { get; set; }
        public int? AwayClubId { get; set; }
        public string AwayClubName { get; set; }
        public int? AwayClubPredictedScore { get; set; }
        public int? AwayClubResultScore { get; set; }
        public byte? Series { get; set; }
        //public byte? Sets { get; set; }
        //public int? ClubMemberId { get; set; }
        public int? Point { get; set; }
    }
    public class MostPredictedViewModel: IBaseViewModel {
        public int? HomeClubId { get; set; }
        public string HomeClubName { get; set; }
        public int? HomeClubScore { get; set; }
        public int? AwayClubId { get; set; }
        public string AwayClubName { get; set; }
        public int? AwayClubScore { get; set; }
        //public byte? Series { get; set; }
        //public byte? Sets { get; set; }
        //public int? ClubMemberId { get; set; }
        public int? Occurrence { get; set; }
    }
    public class EditPredictionBindingModel: HeaderBindingModel {
        public int PredictionId { get; set; }
        public int HomeClubScore { get; set; }
        public int AwayClubScore { get; set; }
        public int? ClubMemberId { get; set; }
    }
}
