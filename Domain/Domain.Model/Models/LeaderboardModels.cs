using Shared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Models {
    public class LeaderboardModel: IBaseModel {
        public int? UserId { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public string Provider { get; set; }
        public int? Rank { get; set; }
        public int? Point { get; set; }
        public int? PredictionCount { get; set; }
        public int? FullPointCount { get; set; }
        public int? RowsCount { get; set; }
    }
}
