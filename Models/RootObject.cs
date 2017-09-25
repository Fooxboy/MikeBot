using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class RootObject<T>
    {
        public T response { get; set; }
    }

    public class RootObjectList<T>
    {
        public List<T> response { get; set; }
    }
}
