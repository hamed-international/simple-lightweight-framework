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
    public class MatchService: IMatchService {
        #region Constructor
        private readonly IStoreProcedure<IBaseModel, MatchPredictSchema> _matchPredict;
        private readonly IStoreProcedure<MatchModel, MatchGetPagingSchema> _matchGetPaging;
        private readonly IStoreProcedure<MatchGroupModel, MatchGroupGetPagingSchema> _matchGroupGetPaging;
        public MatchService(IStoreProcedure<IBaseModel, MatchPredictSchema> matchPredict,
            IStoreProcedure<MatchModel, MatchGetPagingSchema> matchGetPaging,
            IStoreProcedure<MatchGroupModel, MatchGroupGetPagingSchema> matchGroupGetPaging) {
            _matchPredict = matchPredict;
            _matchGetPaging = matchGetPaging;
            _matchGroupGetPaging = matchGroupGetPaging;
        }
        #endregion

        public async Task<IEnumerable<MatchModel>> GetPagingAsync(MatchGetPagingSchema model) {
            var result = await _matchGetPaging.ExecuteAsync(model);
            model.RowsCount = result != null && result.Any() ? result.FirstOrDefault().RowsCount.Value : 0;
            return result;
        }
        public async Task Predict(MatchPredictSchema model) {
            await _matchPredict.ExecuteReturnLessAsync(model);
        }
        public async Task<IEnumerable<MatchGroupModel>> GroupsGetPagingAsync(MatchGroupGetPagingSchema model) {
            var result = await _matchGroupGetPaging.ExecuteAsync(model);
            model.RowsCount = result != null && result.Any() ? result.FirstOrDefault().RowsCount.Value : 0;
            return result;
        }
    }
}
