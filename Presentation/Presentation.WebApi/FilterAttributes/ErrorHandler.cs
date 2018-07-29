using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Presentation.WebApi.FilterAttributes {
    public class ErrorHandler: ExceptionFilterAttribute {
        public override void OnException(ExceptionContext context) {
        }
    }
}
