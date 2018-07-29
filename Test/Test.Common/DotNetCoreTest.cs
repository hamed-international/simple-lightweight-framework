using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.Utility._App;

namespace Test.Common {
    [TestClass]
    public class DotNetCoreTest {
        [TestMethod]
        [TestCategory("DotNetCore")]
        [TestCategory("AppSettings")]
        public void ReadAppSettings() {
            ////var sqlCon = AppSettings.SqlConnection;
            //var mongoCon = AppSettings.MongoConnection;
            ////Assert.IsTrue(sqlCon.Contains("Server"));
            //Assert.IsTrue(mongoCon.Contains("mongodb"));
        }
    }
}
