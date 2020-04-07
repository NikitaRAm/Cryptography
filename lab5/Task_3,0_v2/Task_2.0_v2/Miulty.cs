using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._0_v2
{
    public class Miulty
    {
        const string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ.,?!-()«»:;+/0123456789";
        public string encrypt(string str)
        {
            string key1 = "ROMANOV";
            string key2 = "NIKITA";
            string str2 = "";
            char[,] mass = new char[7, 6];
            char[,] massSort = new char[7, 6];
            char[,] massSortFinal = new char[7, 6];
            for (; ; )
            {
                if (str.Length % 42 == 0)
                    break;
                else str += " ";
            }
            for (int count = 0; count < str.Length; count+= 42)
            {
                for (int i = 0, k = 0; i < key2.Length; i++)
                {
                    for (int j = 0; j < key1.Length; j++)
                    {
                        mass[j, i] = str.Substring(count)[k];
                        ++k;
                    }
                }
                for (int i = 0; i < key2.Length; i++)
                    massSort[6, i] = mass[2, i];
                for (int i = 0; i < key2.Length; i++)
                    massSort[5, i] = mass[0, i];
                for (int i = 0; i < key2.Length; i++)
                    massSort[4, i] = mass[3, i];
                for (int i = 0; i < key2.Length; i++)
                    massSort[3, i] = mass[6, i];
                for (int i = 0; i < key2.Length; i++)
                    massSort[2, i] = mass[1, i];
                for (int i = 0; i < key2.Length; i++)
                    massSort[1, i] = mass[4, i];
                for (int i = 0; i < key2.Length; i++)
                    massSort[0, i] = mass[5, i];
                for (int i = 0; i < key1.Length; i++)
                    massSortFinal[i, 5] = massSort[i, 0];
                for (int i = 0; i < key1.Length; i++)
                    massSortFinal[i, 4] = massSort[i, 2];
                for (int i = 0; i < key1.Length; i++)
                    massSortFinal[i, 3] = massSort[i, 5];
                for (int i = 0; i < key1.Length; i++)
                    massSortFinal[i, 2] = massSort[i, 3];
                for (int i = 0; i < key1.Length; i++)
                    massSortFinal[i, 1] = massSort[i, 4];
                for (int i = 0; i < key1.Length; i++)
                    massSortFinal[i, 0] = massSort[i, 1];
                for (int i = 0; i < key2.Length; i++)
                {
                    for (int j = 0; j < key1.Length; j++)
                    {
                        str2 += massSortFinal[j, i];
                    }
                }
            }
            return str2;
        }
        public string decrypt(string str)
        {
            return str;
        }
    }
}
