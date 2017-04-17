using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace COMM
{
    public class ReadFile
    {
        public static string RederFileToString(string path)
        {
            string str = ""; ;
            StreamReader sw = new StreamReader(path);
            str = sw.ReadToEnd();
            str=str.Replace("\r\n ", "");
            sw.Close();
            sw.Dispose();
            return str;
        }
    }

}
