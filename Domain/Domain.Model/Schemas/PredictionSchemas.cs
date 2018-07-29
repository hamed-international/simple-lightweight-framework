using Shared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Schemas {

    [Schema("[dbo].[API_Prediction_GetPaging]")]
    public class PredictionGetPagingSchema: PagingSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @EventId { get; set; }
        [InputParameter]
        public int? MatchId { get; set; }
        [InputParameter]
        public int? GroupId { get; set; }
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public DateTime? @FromDate { get; set; }
        [InputParameter]
        public DateTime? @ToDate { get; set; }

        [OutputParameter]
        public short @StatusCode { get; set; }
    }

    [Schema("[dbo].[API_Prediction_GetLeaderboardPaging]")]
    public class GetLeaderboardSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @EventId { get; set; }
        [InputParameter]
        public int? GroupId { get; set; }
        [InputParameter]
        public string @Order { get; set; }
        [InputParameter]
        public int? @Skip { get; set; }
        [InputParameter]
        public int? @Take { get; set; }

        [OutputParameter]
        public int? @MyRank { get; set; }
        [OutputParameter]
        public int? @MyPoint { get; set; }
        [OutputParameter]
        public short @StatusCode { get; set; }

        [HelperParameter]
        public int RowsCount { get; set; }
    }

    [Schema("[dbo].[API_Prediction_PredictedCount]")]
    public class PredictedCountSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int EventId { get; set; }

        [OutputParameter]
        public short @MatchCount { get; set; }
        [OutputParameter]
        public short @TotalPredicted { get; set; }
        [OutputParameter]
        public short @StatusCode { get; set; }
    }

    [Schema("[dbo].[API_Prediction_MostPredicted]")]
    public class MostPredictedSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @MatchId { get; set; }

        [OutputParameter]
        public short @StatusCode { get; set; }
    }

    [Schema("[dbo].[API_Prediction_Edit]")]
    public class EditPredictionSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @PredictionId { get; set; }
        [InputParameter]
        public int @HomeClubScore { get; set; }
        [InputParameter]
        public int @AwayClubScore { get; set; }
        [InputParameter]
        public int? @ClubMemberId { get; set; }

        [OutputParameter]
        public short @StatusCode { get; set; }
    }
}
