using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Universities
    {
        public int id { get; set; }
        public int country { get; set; }
        public int city { get; set; }
        public string name { get; set; }
        public int faculty { get; set; }
        public string faculty_name { get; set; }
        public int chair { get; set; }
        public string chair_name { get; set; }
        public int graduation { get; set; }
        public string education_form { get; set; }
        public string education_status { get; set; }
    }
}
