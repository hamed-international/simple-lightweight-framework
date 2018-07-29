using Shared.Utility;
using Shared.Utility._App;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Schemas {
    [Schema("[dbo].[API_Match_Predict]")]
    public class MatchPredictSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @MatchId { get; set; }
        [InputParameter]
        public int @HomeClubId { get; set; }
        [InputParameter]
        public int @HomeClubScore { get; set; }
        [InputParameter]
        public int @AwayClubId { get; set; }
        [InputParameter]
        public int @AwayClubScore { get; set; }
        [InputParameter]
        public byte? @Sets { get; set; }
        [InputParameter]
        public int? @ClubMemberId { get; set; }

        [OutputParameter]
        public short @StatusCode { get; set; }
    }

    [Schema("[dbo].[API_Match_GetPaging]")]
    public class MatchGetPagingSchema: PagingSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @EventId { get; set; }
        [InputParameter]
        public int? @GroupId { get; set; }
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public DateTime? @FromDate { get; set; }
        [InputParameter]
        public DateTime? @ToDate { get; set; }

        [OutputParameter]
        public short @StatusCode { get; set; }
    }
}
