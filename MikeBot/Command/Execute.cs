using System;
using System.Collections.Generic;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;


namespace MikeBot.Command
{
    public static class Execute
    {
        public static void Py(string[] arg)
        {
            string code = "";

            foreach(string s in arg)
            {
                code += s;
            }

            ScriptEngine engine = Python.CreateEngine();
            engine.Execute(code);

        }
    }
}
