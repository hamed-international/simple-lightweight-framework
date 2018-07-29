using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Utility._App {
    public class ModuleInjector {
        public static void Init(IServiceCollection services) {
            services.AddSingleton(new ServiceLocator(services));
        }
    }
}
