﻿using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.WebApi.Models {
    public interface IBaseBindingModel { }
    public class HeaderBindingModel: IBaseBindingModel {
        public string Token { get; set; }
        public string DeviceId { get; set; }
    }
    public class FullHeaderBindingModel: HeaderBindingModel {
        public string OS { get; set; }
        public string Version { get; set; }
        public string DeviceName { get; set; }
        public string Browser { get; set; }
    }
    public class BindingModel: HeaderBindingModel {
        public string OrderBy { get; set; } = "Id";
        public string Order { get; set; } = "DESC";
        public int? PageIndex { get; set; } = 0;
        public int? PageSize { get; set; } = 10;
        public int Skip { get { return (PageIndex * PageSize).Value; } }
        public int Take { get { return PageSize.Value; } }
        public int TotalPages(int rowsCount) {
            return (int)Math.Ceiling((decimal)rowsCount / PageSize.Value);
        }
    }
}
