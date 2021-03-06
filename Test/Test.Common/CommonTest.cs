﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.Utility._App;
using System.IO;

namespace Test.Common {
    [TestClass]
    public class CommonTest {
        [TestMethod]
        [TestCategory("Common")]
        [TestCategory("Directory")]
        public void IODirectory() {
            //var d1 = Application.StartupPath;
            var d2 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var d3 = AppDomain.CurrentDomain.BaseDirectory;
            var d4 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            //var d5 = Path.GetDirectory(Application.ExecutablePath);
            var t = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var d = Directory.GetCurrentDirectory();
        }

        [TestMethod]
        [TestCategory("Common")]
        [TestCategory("SubStr")]
        public void SubStr() {
            var mongodbName = AppSettings.MongoConnection.Split('?')[0].Split('/')[3];
            Assert.IsTrue(mongodbName.Equals("PredictionEngine"));
        }
    }
}
