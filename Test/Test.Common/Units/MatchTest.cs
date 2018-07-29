using Domain.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model.Schemas;
using Shared.Utility._App;

namespace Test.Common.Units {
    [TestClass]
    public class MatchTest {
        #region Constructor
        private readonly IMatchService _matchService;
        public MatchTest() {
            _matchService = ServiceLocator.Current.GetInstance<IMatchService>();
        }
        #endregion

        [TestMethod]
        [TestCategory("Match")]
        [TestCategory("Predict")]
        public void Predict() {
            var model = new MatchPredictSchema {
                Token = "token",
                DeviceId = "",
                MatchId = 1,
                HomeClubId = 1,
                HomeClubScore = 1,
                AwayClubId = 1,
                AwayClubScore = 1
            };
            _matchService.Predict(model);
            Assert.IsTrue(model.StatusCode != 0);
        }
    }
}