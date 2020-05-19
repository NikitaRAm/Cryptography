using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] key = ASCIIEncoding.ASCII.GetBytes("61");

            RC4 encoder = new RC4(key);
            string test = "Romanovich Nikita";
            byte[] testBytes = ASCIIEncoding.ASCII.GetBytes(test);
            byte[] result = encoder.Encode(testBytes, testBytes.Length);
            Console.WriteLine(Encoding.Default.GetString(result));

            RC4 decoder = new RC4(key);
            byte[] decryptedBytes = decoder.Decode(result, result.Length);
            string decryptedString = ASCIIEncoding.ASCII.GetString(decryptedBytes);
            Console.WriteLine(decryptedString);
            Console.ReadKey();
        }
    }
    public class RC4
    {
        byte[] S = new byte[256];

        int x = 0;
        int y = 0;

        public RC4(byte[] key)
        {
            init(key);
        }

       
        // Алгоритм ключевого расписания 
        private void init(byte[] key)
        {
            int keyLength = key.Length;

            for (int i = 0; i < 256; i++)
            {
                S[i] = (byte)i;
            }

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + key[i % keyLength]) % 256;
                S.Swap(i, j);
            }
        }

        public byte[] Encode(byte[] dataB, int size)
        {
            byte[] data = dataB.Take(size).ToArray();

            byte[] cipher = new byte[data.Length];

            for (int m = 0; m < data.Length; m++)
            {
                cipher[m] = (byte)(data[m] ^ keyItem());
            }

            return cipher;
        }
        public byte[] Decode(byte[] dataB, int size)
        {
            return Encode(dataB, size);
        }

      
        // Генератор псевдослучайной последовательности 
        private byte keyItem()
        {
            x = (x + 1) % 256;
            y = (y + S[x]) % 256;

            S.Swap(x, y);

            return S[(S[x] + S[y]) % 256];
        }
    }

    static class SwapExt
    {
        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
