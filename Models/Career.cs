using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Career
    {
        public int group_id { get; set; }
        public string company { get; set; }
        public int country_id { get; set; }
        public int city_id { get; set; }
        public string city_name { get; set; }
        public int from { get; set; }
        public int until { get; set; }
        public string position { get; set; }

    }
}
