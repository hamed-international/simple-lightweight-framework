using Domain.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model.Schemas;
using Shared.Utility._App;

namespace Test.Common.Units {
    [TestClass]
    public class UserTest {
        #region Constructor
        private readonly IUserService _userService;
        public UserTest() {
            _userService = ServiceLocator.Current.GetInstance<IUserService>();
        }
        #endregion
        [TestMethod]
        [TestCategory("User")]
        [TestCategory("Register")]
        public void Register() {
            _userService.RegisterAsync(new UserRegisterSchema { });
        }
    }
}