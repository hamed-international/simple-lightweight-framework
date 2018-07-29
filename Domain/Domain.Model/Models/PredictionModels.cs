using Shared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Models {
    public class PredictionModel: IBaseModel {
        public int? RowsCount { get; set; }
        public int? Id { get; set; }
        public string Title { get; set; }
        public DateTime? OccurrenceDate { get; set; }
        public int? HomeClubId { get; set; }
        public string HomeClubName { get; set; }
        public int? HomeClubPredictedScore { get; set; }
        public int? HomeClubResultScore { get; set; }
        public int? AwayClubId { get; set; }
        public string AwayClubName { get; set; }
        public int? AwayClubPredictedScore { get; set; }
        public int? AwayClubResultScore { get; set; }
        public byte? Series { get; set; }
        public byte? Sets { get; set; }
        public int? ClubMemberId { get; set; }
        public int? Point { get; set; }
    }

    public class MostPredictedModel: IBaseModel {
        public int? HomeClubId { get; set; }
        public string HomeClubName { get; set; }
        public int? HomeClubScore { get; set; }
        public int? AwayClubId { get; set; }
        public string AwayClubName { get; set; }
        public int? AwayClubScore { get; set; }
        public byte? Series { get; set; }
        public int? ClubMemberId { get; set; }
        public int? Occurrence { get; set; }
    }
}
