using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Photo
    {
        public int id { get; set; }
        public int album_id { get; set; }
        public int owber_id { get; set; }
        public int user_id { get; set; }
        public string text { get; set; }
        public int date { get; set; }
        public List<object> sizes { get; set; }
        public string photo_75 { get; set; }
        public string photo_130 { get; set; }
        public string photo_604 { get; set; }
        public string photo_807 { get; set; }
        public string photo_1280 { get; set; }
        public string photo_2560 { get; set; }
        
        public string width { get; set; }
        public string height { get; set; }
    }
}
