using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.API.Method.Status
{
    public static class Set
    {
        public static void Start(string status)
        {
            Request.Api("status.set", $"text={status}");
        }
    }
}
