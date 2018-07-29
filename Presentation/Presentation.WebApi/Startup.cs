using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Application.Services;
using Domain.Model._App;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Presentation.WebApi.Infrastructures;
using Presentation.WebApi.Middlewares;

namespace Presentation.WebApi {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            //services.AddMvcCore().AddVersionedApiExplorer(v => v.GroupNameFormat = "'v'.VVV");
            services.AddSingleton(new MongoDBContext());
            Shared.Utility._App.ModuleInjector.Init(services);
            Domain.Application._App.ModuleInjector.Init(services);
            services.AddSingleton(new MapperConfig().Init().CreateMapper());
            services.AddMvc();
            //services.AddApiVersioning();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseGateway();
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }
            //app.UseMvc();
            app.UseStaticFiles();
            //app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "index.html" } });
            app.UseMvcWithDefaultRoute();
        }
    }
}