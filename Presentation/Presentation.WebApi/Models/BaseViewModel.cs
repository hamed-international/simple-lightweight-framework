using System.Net;

namespace Presentation.WebApi.Models {
    public interface IBaseViewModel {
    }
    public class BaseViewModel {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int? TotalPages { get; set; }
        public string Version { get { return ""; } }
    }
}
