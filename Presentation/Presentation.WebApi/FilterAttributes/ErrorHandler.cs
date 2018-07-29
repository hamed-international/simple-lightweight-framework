using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Presentation.WebApi.FilterAttributes
{
    public class ErrorHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //if (context.HttpContext == null) return;
            ////if (context.ExceptionHandled || context.HttpContext.IsCustomErrorEnabled) return;
            //if (context.Exception is HttpException)
            //{
            //    //A http exception has occourd
            //}
            //else if (context.Exception is UnauthorizedAccessException)
            //{
            //    context.HttpContext.Response.Redirect(@"/Home/Page504");
            //}
            //else if (context.Exception is WebException)
            //{
            //    context.HttpContext.Response.Redirect(@"/Home/Page404");
            //}
            //context.ExceptionHandled = true;
            //var actionName = (string)context.RouteData.Values["action"];
            //var controllerName = (string)context.RouteData.Values["controller"];
            //var requestContext = ((MvcHandler)context.HttpContext.CurrentHandler).RequestContext;
            //if (requestContext.HttpContext.Request.IsAjaxRequest())
            //{
            //    context.HttpContext.Response.Clear();
            //    var factory = ControllerBuilder.Current.GetControllerFactory();
            //    var controller = factory.CreateController(requestContext, controllerName);
            //    var controllerContext = new ControllerContext(requestContext, (ControllerBase)controller);
            //    var jsonResult = new JsonResult
            //    {
            //        Data = new { success = false, serverError = "500" },
            //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //    };
            //    jsonResult.ExecuteResult(controllerContext);
            //    context.HttpContext.Response.End();
            //}
            //else
            //{
            //    var viewResult = new ViewResult
            //    {
            //        MasterName = Master,
            //        TempData = context.Controller.TempData,
            //        ViewName = viewName
            //    };
            //    if (context.Exception.InnerException != null && context.Exception.InnerException.Source.Equals(GeneralMessages.ExceptionSource))
            //    {
            //        viewResult.ViewData = new ViewDataDictionary(context.Exception.Message);
            //    }
            //    context.Result = viewResult;
            //}
        }
    }
}
