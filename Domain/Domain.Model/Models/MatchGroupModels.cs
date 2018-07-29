using Shared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Models
{
    public class MatchGroupModel : IBaseModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? RowsCount { get; set; }
    }
}
