using Domain.Model._App;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Common._App {
    [TestClass]
    public class Startup {
        [AssemblyInitialize]
        public static void Init(TestContext testContext) {
            var services = new ServiceCollection();
            services.AddSingleton(new MongoDBContext());
            Shared.Utility._App.ModuleInjector.Init(services);
            Domain.Application._App.ModuleInjector.Init(services);
            services.AddSingleton(new Shared.Utility._App.ServiceLocator(services));
        }
    }

    [TestClass]
    public class Cleanup {
        [AssemblyCleanup]
        public static void Init() {
        }
    }
}