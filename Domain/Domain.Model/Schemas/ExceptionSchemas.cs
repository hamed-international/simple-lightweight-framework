using Shared.Utility;
using Shared.Utility._App;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Schemas {
    [Schema("[dbo].[API_Exception_Insert]")]
    public class ExceptionInsertSchema: IBaseSchema {
        [InputParameter]
        public string @URL { get; set; }
        [InputParameter]
        public string @Data { get; set; }
        [InputParameter]
        public string @Message { get; set; }
        [InputParameter]
        public string @Source { get; set; }
        [InputParameter]
        public string @StackTrace { get; set; }
        [InputParameter]
        public string @TargetSite { get; set; }
        [InputParameter]
        public string @IP { get; set; }
    }
}
