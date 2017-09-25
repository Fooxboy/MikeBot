using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Military
    {
        public string unit { get; set; }
        public int unit_id { get; set; }
        public int county_id { get; set; }
        public int from { get; set; }
        public int until { get; set; }
    }
}
