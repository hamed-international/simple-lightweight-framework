using Domain.Application.Services;
using Domain.Model._App;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Application._App {
    public class ModuleInjector {
        public static void Init(IServiceCollection services) {
            //Dapper.EntityFramework.Handlers.Register();
            services.AddSingleton(new ConnectionKeeper());
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton(typeof(IStoreProcedure<,>), typeof(StoreProcedure<,>));
            services.AddTransient<IHttpLogService, HttpLogService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMatchService, MatchService>();
            services.AddTransient<IChangeMeService, ChangeMeService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IExceptionService, ExceptionService>();
            services.AddTransient<IPredictionService, PredictionService>();
        }
    }
}
