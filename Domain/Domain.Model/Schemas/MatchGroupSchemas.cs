using Shared.Utility;
using Shared.Utility._App;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Schemas {
    [Schema("[dbo].[API_MatchGroup_GetPaging]")]
    public class MatchGroupGetPagingSchema: PagingSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @EventId { get; set; }
        [InputParameter]
        public string @Title { get; set; }

        [OutputParameter]
        public short @StatusCode { get; set; }
    }
}
