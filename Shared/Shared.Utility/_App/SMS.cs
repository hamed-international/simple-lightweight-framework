﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Utility._App {
    public interface ISMS {
        (bool result, string errorMessage, string trackId) Send(string phoneNo, string message);
    }
    public class Candoo: ISMS {

        public (bool result, string errorMessage, string trackId) Send(string phoneNo, string message) {
            return (false, null, null);
        }
    }
}
