using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebApi.Models {
    public class EventBindingModel: BindingModel {
        public string Tilte { get; set; }
        public long? FromDate { get; set; }
        public long? ToDate { get; set; }
    }
    public class EventViewModel: IBaseViewModel {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public int? Priority { get; set; }
        public long? StartedAt { get; set; }
        public long? EndedAt { get; set; }
    }
}
