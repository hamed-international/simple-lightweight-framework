using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebApi.Models {
    public class MatchGroupBindingModel: BindingModel {
        public int EventId { get; set; }
        public string Tilte { get; set; }
    }
    public class MatchGroupViewModel: IBaseViewModel {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
