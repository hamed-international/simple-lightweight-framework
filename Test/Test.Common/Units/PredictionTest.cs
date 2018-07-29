using Domain.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Utility._App;

namespace Test.Common.Units {
    [TestClass]
    public class PredictionTest {
        #region Constructor
        private readonly IPredictionService _predictionService;
        public PredictionTest() {
            _predictionService = ServiceLocator.Current.GetInstance<IPredictionService>();
        }
        #endregion
        [TestMethod]
        [TestCategory("Prediction")]
        [TestCategory("RemoveRepeatedValues")]
        public void RemoveRepeatedValues() {
        }
    }
}