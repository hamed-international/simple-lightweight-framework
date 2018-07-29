using Shared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Models
{
    public class SessionModel : IBaseModel
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string Token { get; set; }
        public string IP { get; set; }
        public string FcmId { get; set; }
    }
}
