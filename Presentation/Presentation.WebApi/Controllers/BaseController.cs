﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Models;
using Shared.Utility;

namespace Presentation.WebApi.Controllers {
    [Route("api/[controller]")]
    public class BaseController: Controller {
        protected string IP { get { return HttpContext.Connection.RemoteIpAddress.ToString(); } }
        protected string URL { get { return $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}{HttpContext.Request.QueryString}"; } }
        protected IList<ImageFormat> ImageFormats { get { return new List<ImageFormat> { ImageFormat.Gif, ImageFormat.Jpeg, ImageFormat.Tiff, ImageFormat.Png }; } }
        //protected string[] ImageExtensions { get { return new string[] { ".jpg", ".jpeg", ".png", ".tif", ".bmp", ".gif" }; } }

        public IActionResult Ok(HttpStatusCode status = HttpStatusCode.OK, string message = GeneralMessage.OK, object data = null, int? totalPages = null) {
            return Json(new BaseViewModel { Status = status, Message = message, Data = data, TotalPages = totalPages });
        }
        public IActionResult BadRequest(string message) {
            return Json(new BaseViewModel { Status = HttpStatusCode.BadRequest, Message = message });
        }
        public IActionResult InternalServerError(string message = GeneralMessage.InternalServerError) {
            return Json(new BaseViewModel { Status = HttpStatusCode.InternalServerError, Message = message });
        }
    }
}