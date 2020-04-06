using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._0_v2
{
    public class Chart
    {
        public static string EncryptText = "";
        public string getEncrypt()
        {
            return EncryptText;
        }
        public void setEncrypt(string str)
        {
            EncryptText = str;
        }
        public static string DecryptText = "";
        public string getDecrypt()
        {
            return DecryptText;
        }
        public void setDecrypt(string str)
        {
            DecryptText = str;
        }
    }
}
