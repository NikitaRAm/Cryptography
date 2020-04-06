using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._0_v2
{
    class Porty
    {
        const string defaultAlphabet = "AÄBCDEFGHIJKLMNOÖPQRSßTUÜVWXYZ.,?!-()«»:;+/0123456789";
        string[,] portyTable = new string[defaultAlphabet.Length, defaultAlphabet.Length];

        public string encrypt(string str)
        {
            int start = 0;
            for(int i = 0; i < defaultAlphabet.Length; i++)
            {
                for (int j = 0; j < defaultAlphabet.Length; j++)
                {
                    portyTable[i, j] = start.ToString();
                    start++;
                }
            }
            string strEncrypt="";
            for(int i = 0; i < str.Length; i+=2)
            {
                int firstNumber=0;
                int lastNumber=0;
                for (int defaultNumberCheck = 0; defaultNumberCheck < defaultAlphabet.Length; defaultNumberCheck++)
                    if (str[i] == defaultAlphabet[defaultNumberCheck])
                        firstNumber = defaultNumberCheck;
                for (int defaultNumberCheck = 0; defaultNumberCheck < defaultAlphabet.Length; defaultNumberCheck++)
                    if (str[i+1] == defaultAlphabet[defaultNumberCheck])
                        lastNumber = defaultNumberCheck;
                strEncrypt += portyTable[firstNumber, lastNumber];
            }
            return strEncrypt;
        }
        public string decrypt(string str)
        {
            return str;
        }
    }
}
