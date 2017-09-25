using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Schools
    {
        public int id { get; set; }
        public int country { get; set; }
        public int city { get; set; }
        public string name { get; set; }
        public int year_from { get; set; }
        public int year_to { get; set; }
        public int year_graduated { get; set; }
        public string @class { get;set;}
        public string speciality { get; set; }
        public int type { get; set; }
        public string type_str { get; set;}
    }
}
