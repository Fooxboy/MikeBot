using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;


namespace MikeBot.Command
{
    public static class Execute
    {
        public static void Start(string[] arg)
        {
            string code = "";

            foreach(string s in arg)
            {
                code += s;
            }

            

        }
    }
}
