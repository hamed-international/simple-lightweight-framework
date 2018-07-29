using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Utility._App {
    public interface ISMS {
        (bool result, string errorMessage, string trackId) Send(string phoneNo, string message);
    }
    public class Candoo: ISMS {

        public (bool result, string errorMessage, string trackId) Send(string phoneNo, string message) {
            //using (var service = new com.candoosms.my.SMSAPI()) {
            //    var result = service.Send(AppSettings.CandooNumber, AppSettings.CandooPassword, AppSettings.CandooNumber, message, new string[] { phoneNo }, "0");
            //    if (result.Length == 0 || string.IsNullOrEmpty(result[0]?.Mobile)) {
            //        return (false, result[0].ID, null);
            //    }
            //    return (true, "", result[0].ID);
            //}
            return (false, null, null);
        }
    }
}
