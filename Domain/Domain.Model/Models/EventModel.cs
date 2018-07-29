using Shared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Models
{
    public class EventModel : IBaseModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public int? Priority { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public int? RowsCount { get; set; }
    }
}
