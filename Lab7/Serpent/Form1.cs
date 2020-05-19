﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml;
using System.Diagnostics;

namespace serpent {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            // закомментируйте следующую строку, чтобы открыть вкладку тестирование
            tabControl1.TabPages.RemoveAt(2);
            srcFile.Text = "";
            dstFile.Text = "";
        }

        private int mLastSegmentSize;

        private void label2_Click(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            DialogResult r = saveFileDialog.ShowDialog();
            if (DialogResult.OK == r) {
                dstFile.Text = saveFileDialog.FileName;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e) {
            keySize.SelectedIndex = 0;
            operationMode.SelectedIndex = 1;
            segmentSize.SelectedIndex = 0;
            abortOperation.Enabled = false;

            mLastSegmentSize = segmentSize.SelectedIndex;
        }

        private void adjustSegmentSizeToOpMode() {
            if (operationMode.SelectedItem.Equals("ECB") || operationMode.SelectedItem.Equals("CBC"))
            {
                segmentSize.Enabled = false;

                mLastSegmentSize = segmentSize.SelectedIndex;
                segmentSize.SelectedIndex = 0;
            } else {
                segmentSize.Enabled = true;

                segmentSize.SelectedIndex = mLastSegmentSize;
            }
        }

        private void operationMode_SelectedIndexChanged(object sender, EventArgs e) {
            adjustSegmentSizeToOpMode();
        }

        private void segmentSize_SelectedIndexChanged(object sender, EventArgs e) {
            if (segmentSize.Enabled) {
                mLastSegmentSize = segmentSize.SelectedIndex;
            }
        }

        private void openSrcFile_Click(object sender, EventArgs e) {
            DialogResult r = openFileDialog.ShowDialog();
            if (DialogResult.OK == r) {
                srcFile.Text = openFileDialog.FileName;
            }
        }

        private void performOperation_Click(object sender, EventArgs e) {
            // определение шифрования или дешифрования
            bool encrypt = true;
            if (tabControl1.SelectedIndex != 0) {
                encrypt = false;
            }

            /*валидация */
            List<String> errors = new List<String>();

            // совместимость паролей
            String secret = "";
            if (encrypt) {
                if (password.Text.Length == 0) {
                    errors.Add("Пароль не может быть пустым.");
                }
                    secret = password.Text;
            } else {
                secret = decryptPassword.Text;
            }

            // существование файлов
            if (!File.Exists(srcFile.Text)) {
                errors.Add("Исходный файл не существует.");
            }

            if (File.Exists(dstFile.Text)) {
                var content = "Полученный файл уже существует.Перезаписать его?";
                var result = MessageBox.Show(content, "Подтверждение", MessageBoxButtons.YesNo);

                if (DialogResult.No == result)
                {
                    return;
                }
            }

            /* выполнение алгоритма */
            BackgroundWorker bg = encryptWorker;
            try
            {
                if (errors.Count > 0)
                {
                    throw new Exception();
                }

                // изменение состояния элементов управления
                openSrcFile.Enabled = false;
                saveDstFile.Enabled = false;
                srcFile.Enabled = false;
                dstFile.Enabled = false;
                performOperation.Enabled = false;
                abortOperation.Enabled = true;
                tabControl1.Enabled = false;

                progressBar.Value = 0;
                progressBar.Visible = true;

                // выполнение алгоритма
                // создание объекта класса algorithm (IAlgorithm)
                // вызов метода encrypt или decrypt с соответствующими параметрами
                // включая поддержку индикатора выполнения и прерывания операций
                IAlgorithm alg;
                
                //
                if (encrypt)
                {
                    var cipherMode = operationMode.Text;
                    var segment = Convert.ToInt32(segmentSize.Text.Split(' ')[0]);
                    var sessionKeySize = Convert.ToInt32(keySize.Text.Split(' ')[0]);

                    alg = encryptFile(srcFile.Text, dstFile.Text, cipherMode, segment, sessionKeySize, password.Text);

                    statusBarLabel.Text = "Идет шифрование ...";
                }
                else
                {
                    var password = decryptPassword.Text;

                    alg = decryptFile(srcFile.Text, dstFile.Text, password);

                    statusBarLabel.Text = "Идет расшифровка ...";
                }

                bg.RunWorkerAsync(alg);
            }
            catch (System.IO.IOException ex)
            {
                bg.CancelAsync();
                MessageBox.Show("Произошла ошибка при сохранении или чтении файла.");
            }
            catch (ArgumentException ex)
            {
                bg.CancelAsync();
                MessageBox.Show("Произошла ошибка при инициализации алгоритма шифрования.");
            }
            catch (Exception ex)
            {
                bg.CancelAsync();

                String errorStr = "Указаны неверные параметры.\n\nПодробнее:\n" +
                    string.Join("\n", errors.ToArray());
                MessageBox.Show(errorStr);
            }
        }

        private void restoreDefaultControlsState() {
            // изменение состояния элементов управления
            openSrcFile.Enabled = true;
            saveDstFile.Enabled = true;
            srcFile.Enabled = true;
            dstFile.Enabled = true;
            performOperation.Enabled = true;
            abortOperation.Enabled = false;
            tabControl1.Enabled = true;

            progressBar.Visible = false;
        }

        private void abortOperation_Click(object sender, EventArgs e) {
            statusBarLabel.Text = "остановка операции...";

            BackgroundWorker[] workers = new BackgroundWorker[]{encryptWorker};

            foreach (BackgroundWorker w in workers) {
                if (w.IsBusy) {
                    w.CancelAsync();
                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            //System.Console.WriteLine("encryptWorker_DoWork");
            IAlgorithm alg = e.Argument as IAlgorithm;
            Int64 length = alg.getSrcLength();
            Int64 step = System.Convert.ToInt64(Math.Ceiling(length / (double)100));
            Int64 countBytes = 0;
            Int64 bytes = 1;

            while (bytes > 0 && !encryptWorker.CancellationPending) {
                // "unit work" шифрование фрагмента файла
                bytes = alg.encrypt(step);
                countBytes += bytes;

                int progress = (int)(countBytes * 100 / length);
                encryptWorker.ReportProgress(progress);
            }

            e.Result = alg;

            if (encryptWorker.CancellationPending) {
                e.Cancel = true;
            }
        }

        private void encryptWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            //System.Console.WriteLine("encryptWorker_ProgressChanged: " + e.ProgressPercentage.ToString());

            progressBar.Value = e.ProgressPercentage;
        }

        private void encryptWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            //System.Console.WriteLine("encryptWorker_RunWorkerCompleted");

            restoreDefaultControlsState();

            if (!e.Cancelled)
            {
                IAlgorithm alg = e.Result as IAlgorithm;
                bool encryption = alg.Encryption;
                alg.Dispose();

                var opStatus = (encryption ? "зашифровано" : "расшифрованно");
                statusBarLabel.Text = opStatus;
            }
            else
            {
                statusBarLabel.Text = "прервано";
            }
        }

        /**
         * Проверка правильности
         */
        private void button1_Click_1(object sender, EventArgs e)
        {
            String path = "E:\\Projekty\\BSK\\dane-testowe\\pattern.in";
            var srcChecksum = computeFileChecksum(path);

            //System.Console.WriteLine("srcChecksum = {0}", srcChecksum);

            // создание списка параметров
            String encPath = "";
            String decPath = "";

            AlgorithmParams[] algParams = new AlgorithmParams[] {
                new AlgorithmParams(path, encPath, "ECB", 128, 256, "1234567890"),

                new AlgorithmParams(path, encPath, "CBC", 128, 128, ""),

                new AlgorithmParams(path, encPath, "CFB", 128, 128, "0987654321"),
                new AlgorithmParams(path, encPath, "CFB", 120, 128, ""),
                new AlgorithmParams(path, encPath, "CFB", 112, 128, ""),
                new AlgorithmParams(path, encPath, "CFB", 104, 128, ""),
                new AlgorithmParams(path, encPath, "CFB", 96, 128, "testtest"),
                new AlgorithmParams(path, encPath, "CFB", 88, 128, ""),
                new AlgorithmParams(path, encPath, "CFB", 80, 128, ""),
                new AlgorithmParams(path, encPath, "CFB", 72, 128, ""),
                new AlgorithmParams(path, encPath, "CFB", 64, 128, ""),
                new AlgorithmParams(path, encPath, "CFB", 56, 128, ""),
                new AlgorithmParams(path, encPath, "CFB", 48, 128, ""),
                new AlgorithmParams(path, encPath, "CFB", 40, 128, ""),
                new AlgorithmParams(path, encPath, "CFB", 32, 128, ""),
                new AlgorithmParams(path, encPath, "CFB", 24, 128, ""),
                new AlgorithmParams(path, encPath, "CFB", 16, 128, ""),
                new AlgorithmParams(path, encPath, "CFB", 8, 128, ""),

                new AlgorithmParams(path, encPath, "OFB", 128, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 120, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 112, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 104, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 96, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 88, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 80, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 72, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 64, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 56, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 48, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 40, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 32, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 24, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 16, 128, ""),
                new AlgorithmParams(path, encPath, "OFB", 8, 128, "")
            };

            // выполнение тестов
            Stopwatch sw = new Stopwatch();

            foreach (var p in algParams)
            {
                if (null == p)
                    continue;

                String testSignature = p.CipherMode + "/" + p.SegmentSize.ToString() + "/" + p.SessionKeySize.ToString();

                using (var alg = encryptFile(p))
                {
                    sw.Start();
                    alg.encrypt(Int64.MaxValue);
                    sw.Stop();
                }
                Console.WriteLine(testSignature + " encrypt time: {0}", sw.Elapsed);
                sw.Reset();


                p.Src = p.Dst;
                p.Dst = decPath;

                using (var alg = decryptFile(p))
                {
                    sw.Start();
                    alg.encrypt(Int64.MaxValue);
                    sw.Stop();
                }
                Console.WriteLine(testSignature + " decrypt time: {0}", sw.Elapsed);
                sw.Reset();
            
                var resultChecksum = computeFileChecksum(decPath);
                //System.Console.WriteLine("resultChecksum = {0}", resultChecksum);

                // сравнение исходного файла с результирующим
                if (srcChecksum != resultChecksum)
                {
                    MessageBox.Show("Неверный результат во время теста " + testSignature);

                    return;
                }
            }

            MessageBox.Show("OK");
        }

        private IAlgorithm encryptFile(AlgorithmParams p)
        {
            return encryptFile(p.Src, p.Dst, p.CipherMode, p.SegmentSize, p.SessionKeySize, p.Password);
        }

        private IAlgorithm decryptFile(AlgorithmParams p)
        {
            return decryptFile(p.Src, p.Dst, p.Password);
        }

        private IAlgorithm encryptFile(String src, String dst, String cipherMode, int segment, int sessionKeySize, String password)
        {
            // выполнение алгоритма
            // создание объекта класса algorithm (IAlgorithm)
            // вызов метода encrypt с соответствующими параметрами
            // включая поддержку индикатора выполнения и прерывания операций
            IAlgorithm alg;

            var key = Serpent.generateKey(sessionKeySize);
            //var key = Serpent.generateKeyFromBytes(Convert.FromBase64String("ZgCKtGo7pgmpRw7EFHJTGQ=="));
            var iv = Serpent.generateIV();

            // шифрование ключа сеанса Serpent / ECB паролем`password'
            var sessionKeyAlg = getSessionKeyAlg(true, password);
            var encryptedKey = sessionKeyAlg.encryptInMemory(key.GetKey());

            // создание заголовка
            XDocument miXML = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("EncryptedFileHeader",
                    new XElement("Algorithm", "SERPENT"),
                    new XElement("CipherMode", cipherMode),
                    //new XElement("BlockSize", 128), //это постоянный нет необходимости, чтобы сохранить его
                    new XElement("SegmentSize", segment),
                    new XElement("KeySize", sessionKeySize),
                    new XElement("EncryptedKey", Convert.ToBase64String(encryptedKey)),
                    new XElement("IV", Convert.ToBase64String(iv))
                )
            );

            using (StreamWriter sw = new StreamWriter(dst, false, Encoding.ASCII))
            {
                miXML.Save(sw);
                sw.WriteLine();
            }
            long xmlSize = new FileInfo(dst).Length;

            // сохранение заголовка
            var headerOffset = xmlSize;

            // шифрование
            alg = new Serpent(key, iv, true);
            alg.init(src, dst, cipherMode, segment, 0, headerOffset);

            return alg;
        }

        private IAlgorithm decryptFile(String src, String dst, String password)
        {
            // выполнение алгоритма
            // создание объекта класса algorithm (IAlgorithm)
            // вызов метода encrypt или decrypt с соответствующими параметрами
            // включая поддержку индикатора выполнения и прерывания операций
            IAlgorithm alg;

            // wczytanie nagłówka
            String xmlHeader = "";
            using (StreamReader sr = new StreamReader(src))
            { 
                String line;
                while (sr.Peek() >= 0)
                {
                    line = sr.ReadLine();
                    xmlHeader += line + "\r\n";

                    if (line.Equals("</EncryptedFileHeader>"))
                    {
                        break;
                    }
                }
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlHeader);

            int headerOffset = xmlHeader.Length;

           

            // чтение параметров из заголовка
            XmlNode node = doc.DocumentElement.SelectSingleNode("/EncryptedFileHeader/KeySize");
            var keySize = Convert.ToInt32(node.InnerText);
            keySize = keySize >> 3;

            node = doc.DocumentElement.SelectSingleNode("/EncryptedFileHeader/EncryptedKey");
            byte[] encryptedKey = Convert.FromBase64String(node.InnerText);

            // расшифровка ключа сеанса с помощью алгоритма Serpent / ECB паролем`password'
            var sessionKeyAlg = getSessionKeyAlg(false, password);
            var decryptedKey = sessionKeyAlg.encryptInMemory(encryptedKey);
            if (decryptedKey.Length != keySize)
            {
                var truncatedKey = new byte[keySize];
                System.Buffer.BlockCopy(decryptedKey, 0, truncatedKey, 0, keySize);
                decryptedKey = truncatedKey;
            }

            var sessionKey = Serpent.generateKeyFromBytes(decryptedKey);

            //
            node = doc.DocumentElement.SelectSingleNode("/EncryptedFileHeader/IV");
            byte[] iv = Convert.FromBase64String(node.InnerText);

            node = doc.DocumentElement.SelectSingleNode("/EncryptedFileHeader/SegmentSize");
            var segment = Convert.ToInt32(node.InnerText);

            node = doc.DocumentElement.SelectSingleNode("/EncryptedFileHeader/CipherMode");
            var cipherMode = node.InnerText;

            // расшифровка
            alg = new Serpent(sessionKey, iv, false);
            alg.init(src, dst, cipherMode, segment, headerOffset, 0);

            return alg;
        }

        private String computeFileChecksum(String path)
        {
            using (var alg = SHA256.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    return BitConverter.ToString(alg.ComputeHash(stream)).Replace("-", "").ToLower();
                }
            }
        }

        private byte[] computeHash(String data)
        {
            using (var alg = SHA256.Create())
            {
                return alg.ComputeHash(GetBytes(data));
            }
        }

        private IAlgorithm getSessionKeyAlg(bool encryption, string password)
        {
            var SKkey = Serpent.generateKeyFromBytes(computeHash(password));
            var SKiv = Serpent.generateIV(true);
            IAlgorithm sessionKeyAlg = new Serpent(SKkey, SKiv, encryption);
            sessionKeyAlg.init(null, null, "ECB", 128);

            return sessionKeyAlg;
        }

        static byte[] GetBytes(String str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static String GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new String(chars);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("tab: {0}", tabControl1.SelectedIndex);
            if (1 == tabControl1.SelectedIndex)
            {
               
            }
        }

        private void oprogramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String text = "Программа шифрования файлов с использованием Serpent была создана для продвижения проекта" +
                "предмет безопасности компьютерных систем преподается в Гданьском Политехническом университете.\n\n" +

                "Алгоритм Serpent является финалистом конкурса AES. Это медленнее, но безопаснее, чем победитель," +
                "т. е. алгоритм Rijndael. Serpent управляет блоком длиной 128 бит, допускает ключи длиной" +
                "128, 192 и 256 бит, выполняет 32 раунда, работает по принципу spn, то есть перестановочно-перестановочной сети.\n\n" +

                "В приложении вы можете указать исходный и результирующий файл, изменить длину ключа, установить один из следующих режимов" +
                "работы: ЕЦБ, CBC, CFB и OFB. Для последних двух можно выбрать длину подблока, кратную 8 в " +
                "диапазон от 8 до 128 бит. В программе также необходимо ввести пароль, который будет использоваться для шифрования ключа сеанса" +
                "и требуется при расшифровке.\n\n" +

                "Библиотека The Bouncy Castle используется для всех криптографических операций, m.in. Для (от)шифрования с" +
                "с помощью алгоритма Serpent, генерации очень случайного ключа сеанса и вектора IV или вычисления хэша из" +
                "пароль, предоставленный пользователем.";

            MessageBox.Show(text, "О программе");
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void retypedPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void decryptPassword_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
