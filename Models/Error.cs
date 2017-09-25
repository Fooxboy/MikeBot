using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
        public class Error
        {
            public ErrorRoot error { get; set; }
        }

        public class ErrorRoot
        {
            public int error_code { get; set; }
            public string error_msg { get; set; }
            public List<RequestParam> request_params { get; set; }
        }

        public class RequestParam
        {
            public string key { get; set; }
            public string value { get; set; }
        }
    
}
