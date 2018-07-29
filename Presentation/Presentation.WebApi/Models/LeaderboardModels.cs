
namespace Presentation.WebApi.Models {
    public class LeaderboardBindingModel: BindingModel {
        public int EventId { get; set; }
        public int? GroupId { get; set; }
    }
    public class LeaderboardViewModel: IBaseViewModel {
        public string NickName { get; set; }
        public string Phone { get; set; }
        public string Provider { get; set; }
        public int? Rank { get; set; }
        public int? Point { get; set; }
        public int? PredictionCount { get; set; }
        public int? FullPointCount { get; set; }
    }
}
