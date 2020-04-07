using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2._0_v2
{
    public class RouteSwap
    {
        public string Zigzag(string message, int columnCount)
        {
            
            for (; ; )
            {
                if (message.Length % columnCount == 0)
                    break;
                else message += " ";
            }
            string encrypt = "";
            for (int column = 1; column <= columnCount; column++)
            {

                if (column % 2 == 1)
                {
                    string result = message.Substring(column-1)[0].ToString();
                    for (int i = 0; i < message.Substring(column).Length; ++i)
                        if ((i + 1) % (columnCount) == 0) result += message.Substring(column)[i];
                    encrypt += result;
                }
                else
                {
                    string resultTwo = message.Substring(column-1)[0].ToString();
                    for (int i = 0; i < message.Substring(column).Length; ++i)
                        if ((i + 1) % (columnCount) == 0) resultTwo += message.Substring(column)[i];
                    encrypt += ReverseString(resultTwo);
                }
            }   


                return encrypt;
        }
        public string decrypt(string str)
        {
            return str;
        }
        private static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
