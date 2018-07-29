using Domain.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Utility._App;
using Domain.Model.Collections;
using System;

namespace Test.Common.Units {
    [TestClass]
    public class HttpLogTest {
        #region Constructor
        private readonly IHttpLogService _httpLogService;
        public HttpLogTest() {
            _httpLogService = ServiceLocator.Current.GetInstance<IHttpLogService>();
        }
        #endregion
        [TestMethod]
        [TestCategory("HttpLog")]
        [TestCategory("Insert")]
        public void Insert() {
            var result = _httpLogService.InsertAsync(new HttpLog { Duration = 1, Method = "1", ReqestedAt = DateTime.Now, ResponsedAt = DateTime.Now }, 10000).Result;
            Assert.IsTrue(result > 0);
        }
    }
}