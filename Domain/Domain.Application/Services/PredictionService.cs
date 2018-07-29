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
    public class PredictionService: IPredictionService {
        #region Constructor
        private readonly IStoreProcedure<LeaderboardModel, GetLeaderboardSchema> _getLeaderboard;
        private readonly IStoreProcedure<PredictionModel, PredictionGetPagingSchema> _getPaging;
        private readonly IStoreProcedure<IBaseModel, PredictedCountSchema> _getPredictedCount;
        private readonly IStoreProcedure<MostPredictedModel, MostPredictedSchema> _mostPredicted;
        private readonly IStoreProcedure<IBaseModel, EditPredictionSchema> _editPrediction;

        public PredictionService(IStoreProcedure<LeaderboardModel, GetLeaderboardSchema> getLeaderboard,
            IStoreProcedure<PredictionModel, PredictionGetPagingSchema> getPaging,
            IStoreProcedure<IBaseModel, PredictedCountSchema> getPredictedCount,
            IStoreProcedure<MostPredictedModel, MostPredictedSchema> mostPredicted,
            IStoreProcedure<IBaseModel, EditPredictionSchema> editPrediction) {
            _getLeaderboard = getLeaderboard;
            _getPaging = getPaging;
            _getPredictedCount = getPredictedCount;
            _mostPredicted = mostPredicted;
            _editPrediction = editPrediction;
        }
        #endregion

        public async Task<IEnumerable<LeaderboardModel>> GetLeaderboardPagingAsync(GetLeaderboardSchema model) {
            var result = await _getLeaderboard.ExecuteAsync(model);
            model.RowsCount = result != null && result.Any() ? result.FirstOrDefault().RowsCount.Value : 0;
            return result;
        }

        public async Task<IEnumerable<PredictionModel>> GetPagingAsync(PredictionGetPagingSchema model) {
            var result = await _getPaging.ExecuteAsync(model);
            model.RowsCount = result != null && result.Any() ? result.FirstOrDefault().RowsCount.Value : 0;
            return result;
        }

        public async Task GetPredictedCountAsync(PredictedCountSchema model) {
            await _getPredictedCount.ExecuteReturnLessAsync(model);
        }

        public async Task<IEnumerable<MostPredictedModel>> GetMostPredictedAsync(MostPredictedSchema model) {
            return await _mostPredicted.ExecuteAsync(model);
        }

        public async Task EditAsync(EditPredictionSchema model) {
            await _editPrediction.ExecuteReturnLessAsync(model);
        }
    }
}
