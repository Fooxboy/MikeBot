using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MikeBot.Mafia.Methods
{
    public static class WriteFile
    {
        public static void Start(string text, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.Write(text);
            }
        }
    }
}
