using Shared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Models
{
    public class UserModel : IBaseModel
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
    }
}