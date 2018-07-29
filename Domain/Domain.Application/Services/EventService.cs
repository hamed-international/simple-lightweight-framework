using Domain.Application._App;
using Domain.Model.Models;
using Domain.Model.Schemas;
using Shared.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Services {
    public class EventService: IEventService {
        #region Constructor
        private readonly IStoreProcedure<EventModel, EventGetPagingSchema> _matchGetPaging;
        public EventService(IStoreProcedure<EventModel, EventGetPagingSchema> matchGetPaging) {
            _matchGetPaging = matchGetPaging;
        }
        #endregion

        public async Task<IEnumerable<EventModel>> GetPagingAsync(EventGetPagingSchema model) {
            var result = await _matchGetPaging.ExecuteAsync(model);
            model.RowsCount = result != null && result.Any() ? result.FirstOrDefault().RowsCount.Value : 0;
            return result;
        }
    }
}
