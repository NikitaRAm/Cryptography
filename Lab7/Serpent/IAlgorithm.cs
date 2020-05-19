using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace serpent {
    interface IAlgorithm : IDisposable {
        /**
         * в конструкторе необходимо указать ключ сеанса и вектор IV
         */

        bool Encryption { get; }

        Int64 getSrcLength();

        /**
        * @ param srcFile входной файл
        * @ param dstfile выходной файл
        * @ param opMode режим шифрования: ECB, CBC, CFB, OFB
        * @ param segmentSize размер подблока для выбранного режима шифрования
        * @ param srcFileOffset начальное смещение индикатора чтения во входном файле
        * @ param dstfileoffset начальное смещение указателя записи в выходном файле
        * @throws Система.ArgumentException
        */
        void init(String srcFile, String dstFile, String opMode, int segmentSize,
                Int64 srcFileOffset = 0, Int64 dstFileOffset = 0);

        /**
        * @ param minBytes минимальное / расчетное количество байтов для обработки
        * @ returns количество фактически обработанных байтов
        */
        Int64 encrypt(Int64 minBytes);

        /**
        * @ param minBytes минимальное / расчетное количество байтов для обработки
        * @ returns количество фактически обработанных байтов
        */
        Int64 decrypt(Int64 minBytes);

        /**
        * @ param plaintext данные для шифрования
        * @ returns шифрограмма
        */
        byte[] encryptInMemory(byte[] plaintext);

        /**
        * @ param Cryptogram данные для расшифровки (шифрограмма)
        * @ returns декодированная строка байтов
        */
        byte[] decryptInMemory(byte[] cryptogram);
    }
}
