using System;
using System.Collections.Generic;
using System.Text;

namespace YandexAPI.Translate
{
    public class Model
    {
            public int code { get; set; }
            public string lang { get; set; }
            public List<string> text { get; set; }      
    }
}
