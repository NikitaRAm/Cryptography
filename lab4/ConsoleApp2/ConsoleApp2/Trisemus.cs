using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Trisemus
    {
        public static string Encrypt()
        {
         


            char[,] alfrus = {     {'N', 'I', 'K', 'A', 'B'},
                                   { 'C','D','E', 'F', 'G' },
                                   { 'H','L', 'M','O',  'P'},
                                   { 'Q', 'R','S','T',  'U'},
                                   { 'V','W','X','Y', 'Z' },
                         
                               };

            StreamReader file = new StreamReader("textfile.txt", Encoding.Default);
            string message = file.ReadToEnd();
            string new_message = "";



            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < alfrus.GetLength(0); j++)
                    for (int k = 0; k < alfrus.GetLength(1); k++)
                        if (Char.ToLower(alfrus[j, k]) == message[i] || Char.ToUpper(alfrus[j, k]) == message[i])
                        {
                            int x = j + 1;
                            int y = k;
                            if (x == 5)
                            {
                                x = 1;
                            }
                            new_message += alfrus[x, y];
                            break;
                        }

            }
            return new_message;
        }
    }
}