using Domain.Model.Collections;
using Domain.Model.Models;
using Domain.Model.Schemas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Application {
    public interface IExceptionService {
        Task InsertAsync(Exception model, string url, string ip);
    }
    public interface IMatchService {
        Task<IEnumerable<MatchModel>> GetPagingAsync(MatchGetPagingSchema model);
        Task Predict(MatchPredictSchema model);
        Task<IEnumerable<MatchGroupModel>> GroupsGetPagingAsync(MatchGroupGetPagingSchema model);
    }
    public interface IChangeMeService {
    }
    public interface IEventService {
        Task<IEnumerable<EventModel>> GetPagingAsync(EventGetPagingSchema model);
    }
    public interface IUserService {
        Task RegisterAsync(UserRegisterSchema model);
        Task ChangePasswordAsync(ChangePasswordSchema model);
        Task EditAsync(UserEditSchema model);
        Task LoginAsync(UserLoginSchema model);
        Task LoginAsync(UserNextStepLoginSchema model);
        Task SyncAsync(UserSyncSchema model);
        Task<UserModel> GetAsync(UserGetSchema model);
    }
    public interface IHttpLogService {
        Task<int> InsertAsync(HttpLog model, int timeoutMS = 256);
    }
    public interface IPredictionService {
        Task<IEnumerable<LeaderboardModel>> GetLeaderboardPagingAsync(GetLeaderboardSchema model);
        Task<IEnumerable<PredictionModel>> GetPagingAsync(PredictionGetPagingSchema model);
        Task GetPredictedCountAsync(PredictedCountSchema model);
        Task<IEnumerable<MostPredictedModel>> GetMostPredictedAsync(MostPredictedSchema model);
        Task EditAsync(EditPredictionSchema model);
    }
}
