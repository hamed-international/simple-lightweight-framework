﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.Model.Collections {
    public class HttpLog {
        public ObjectId Id { get; set; }
        public string IP { get; set; }
        public string Method { get; set; }
        public string URL { get; set; }
        public IDictionary<string, string[]> RequsetHeader { get; set; }
        public DateTime ReqestedAt { get; set; }
        public string Request { get; set; }
        public IDictionary<string, string[]> ResponseHeader { get; set; }
        public DateTime ResponsedAt { get; set; }
        public string Response { get; set; }
        public long Duration { get; set; }
    }
}