using Shared.Utility;
using Shared.Utility._App;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Schemas {
    [Schema("[dbo].[API_Event_GetPaging]")]
    public class EventGetPagingSchema: PagingSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
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
