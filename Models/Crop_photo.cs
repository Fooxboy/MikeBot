using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Crop_photo
    {
        public Photo photo { get; set; }
        public Crop crop { get; set; }
        public Crop rect { get; set; }
    }
}
