using Shared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Models {
    public class MatchModel: IBaseModel {
        public int? Id { get; set; }
        public int? EventId { get; set; }
        public string EventTitle { get; set; }
        public int? GroupId { get; set; }
        public string GroupTitle { get; set; }
        public string Title { get; set; }
        public int? HomeClubId { get; set; }
        public string HomeClubName { get; set; }
        public string HomeClubThumbnail { get; set; }
        public string HomeClubImage { get; set; }
        public int? AwayClubId { get; set; }
        public string AwayClubName { get; set; }
        public string AwayClubThumbnail { get; set; }
        public string AwayClubImage { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public int? Prioriry { get; set; }
        public DateTime? OccurrenceDate { get; set; }
        public DateTime? PredictionDeadline { get; set; }
        public bool? IsPredicted { get; set; }
        public int? RowsCount { get; set; }
    }
}
