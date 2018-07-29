using Microsoft.AspNetCore.Mvc.Filters;
using Presentation.WebApi.Models;
using System.Linq;

namespace Presentation.WebApi.FilterAttributes {
    public class ArgumentBinding: ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext context) {
            foreach (var param in context.ActionArguments) {
                if (param.Value is IBaseBindingModel) {
                    var properties = param.Value.GetType().GetProperties();
                    foreach (var item in properties) {
                        if (!string.IsNullOrWhiteSpace(item.Name)) {
                            switch (item.Name.ToLower()) {
                                case "token":
                                    var token = context.HttpContext.Request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("token"));
                                    if (token.Value.Any())
                                        item.SetValue(param.Value, token.Value[0]);
                                    break;
                                case "deviceid":
                                    var deviceId = context.HttpContext.Request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("deviceid"));
                                    if (deviceId.Value.Any())
                                        item.SetValue(param.Value, deviceId.Value[0]);
                                    break;
                                case "os":
                                    var os = context.HttpContext.Request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("os"));
                                    if (os.Value.Any())
                                        item.SetValue(param.Value, os.Value[0]);
                                    break;
                                case "version":
                                    var version = context.HttpContext.Request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("version"));
                                    if (version.Value.Any())
                                        item.SetValue(param.Value, version.Value[0]);
                                    break;
                                case "devicename":
                                    var deviceName = context.HttpContext.Request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("devicename"));
                                    if (deviceName.Value.Any())
                                        item.SetValue(param.Value, deviceName.Value[0]);
                                    break;
                                case "browser":
                                    var browser = context.HttpContext.Request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("browser"));
                                    if (browser.Value.Any())
                                        item.SetValue(param.Value, browser.Value[0]);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
