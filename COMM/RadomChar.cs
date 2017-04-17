using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace COMM
{
    public class RadomChar
    {
        public static string GetRandomString(int minCount,int maxCount, bool isBig)
        {
            string str = "";
            Random rd = new Random();
            Random rb = new Random();
            int count = rd.Next(minCount, maxCount);
            Thread.Sleep(40);
            for (int i = 0; i < count; i++)
            {
                str += ((char)rb.Next(97, 122)).ToString();
                if(isBig)
                {
                    str.Remove(str.Length - 1);
                    str += ((char)rb.Next(65, 90)).ToString();
                }
            }
            return str;
        }
        public static int GetRandomint(int minCount, int maxCount)
        {
            Random rd = new Random();
            Thread.Sleep(40);
            int count = rd.Next(minCount, maxCount);
            return count;
        }
    }
}
