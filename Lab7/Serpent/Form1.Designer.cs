namespace serpent {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveDstFile = new System.Windows.Forms.Button();
            this.dstFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openSrcFile = new System.Windows.Forms.Button();
            this.srcFile = new System.Windows.Forms.TextBox();
            this.performOperation = new System.Windows.Forms.Button();
            this.abortOperation = new System.Windows.Forms.Button();
            this.encryptWorker = new System.ComponentModel.BackgroundWorker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.decryptPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.blockSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.keySize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.operationMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.segmentSize = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.statusBar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Исходный файл";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarLabel,
            this.progressBar});
            this.statusBar.Location = new System.Drawing.Point(0, 389);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(428, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusBarLabel
            // 
            this.statusBarLabel.Name = "statusBarLabel";
            this.statusBarLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // progressBar
            // 
            this.progressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 16);
            this.progressBar.Value = 30;
            this.progressBar.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveDstFile);
            this.groupBox1.Controls.Add(this.dstFile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.openSrcFile);
            this.groupBox1.Controls.Add(this.srcFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки ввода / вывода";
            // 
            // saveDstFile
            // 
            this.saveDstFile.Location = new System.Drawing.Point(318, 55);
            this.saveDstFile.Name = "saveDstFile";
            this.saveDstFile.Size = new System.Drawing.Size(73, 23);
            this.saveDstFile.TabIndex = 5;
            this.saveDstFile.Text = "Обзор";
            this.saveDstFile.UseVisualStyleBackColor = true;
            this.saveDstFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // dstFile
            // 
            this.dstFile.Location = new System.Drawing.Point(82, 57);
            this.dstFile.Name = "dstFile";
            this.dstFile.Size = new System.Drawing.Size(224, 20);
            this.dstFile.TabIndex = 4;
            this.dstFile.Text = "E:\\Projekty\\BSK\\dane-testowe\\0.out";
            this.dstFile.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Результирующий файл";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // openSrcFile
            // 
            this.openSrcFile.Location = new System.Drawing.Point(318, 21);
            this.openSrcFile.Name = "openSrcFile";
            this.openSrcFile.Size = new System.Drawing.Size(73, 23);
            this.openSrcFile.TabIndex = 2;
            this.openSrcFile.Text = "Обзор";
            this.openSrcFile.UseVisualStyleBackColor = true;
            this.openSrcFile.Click += new System.EventHandler(this.openSrcFile_Click);
            // 
            // srcFile
            // 
            this.srcFile.Location = new System.Drawing.Point(82, 23);
            this.srcFile.Name = "srcFile";
            this.srcFile.Size = new System.Drawing.Size(224, 20);
            this.srcFile.TabIndex = 1;
            this.srcFile.Text = "E:\\Projekty\\BSK\\dane-testowe\\0.in";
            // 
            // performOperation
            // 
            this.performOperation.Location = new System.Drawing.Point(122, 348);
            this.performOperation.Name = "performOperation";
            this.performOperation.Size = new System.Drawing.Size(85, 28);
            this.performOperation.TabIndex = 3;
            this.performOperation.Text = "Выполнить";
            this.performOperation.UseVisualStyleBackColor = true;
            this.performOperation.Click += new System.EventHandler(this.performOperation_Click);
            // 
            // abortOperation
            // 
            this.abortOperation.Location = new System.Drawing.Point(222, 348);
            this.abortOperation.Name = "abortOperation";
            this.abortOperation.Size = new System.Drawing.Size(85, 28);
            this.abortOperation.TabIndex = 5;
            this.abortOperation.Text = "Прервать";
            this.abortOperation.UseVisualStyleBackColor = true;
            this.abortOperation.Click += new System.EventHandler(this.abortOperation_Click);
            // 
            // encryptWorker
            // 
            this.encryptWorker.WorkerReportsProgress = true;
            this.encryptWorker.WorkerSupportsCancellation = true;
            this.encryptWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.encryptWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.encryptWorker_ProgressChanged);
            this.encryptWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.encryptWorker_RunWorkerCompleted);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(397, 136);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Тестирование";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Проверить правильность";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Тест производительности";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(397, 136);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Расшифровка";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.decryptPassword);
            this.groupBox3.Location = new System.Drawing.Point(7, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 51);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Безопасность";
            // 
            // decryptPassword
            // 
            this.decryptPassword.Location = new System.Drawing.Point(71, 19);
            this.decryptPassword.Name = "decryptPassword";
            this.decryptPassword.Size = new System.Drawing.Size(304, 20);
            this.decryptPassword.TabIndex = 4;
            this.decryptPassword.TextChanged += new System.EventHandler(this.decryptPassword_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Ключ";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(397, 136);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Шифрование";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.segmentSize);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.operationMode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.keySize);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.blockSize);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 79);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры алгоритма";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Длина блока";
            // 
            // blockSize
            // 
            this.blockSize.Enabled = false;
            this.blockSize.Location = new System.Drawing.Point(121, 20);
            this.blockSize.Name = "blockSize";
            this.blockSize.Size = new System.Drawing.Size(39, 20);
            this.blockSize.TabIndex = 1;
            this.blockSize.Text = "128 b";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Длина ключа";
            // 
            // keySize
            // 
            this.keySize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keySize.FormattingEnabled = true;
            this.keySize.Items.AddRange(new object[] {
            "256 b",
            "192 b",
            "128 b"});
            this.keySize.Location = new System.Drawing.Point(121, 46);
            this.keySize.Name = "keySize";
            this.keySize.Size = new System.Drawing.Size(54, 21);
            this.keySize.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Режим работы";
            // 
            // operationMode
            // 
            this.operationMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationMode.FormattingEnabled = true;
            this.operationMode.Items.AddRange(new object[] {
            "ECB",
            "CBC",
            "CFB",
            "OFB"});
            this.operationMode.Location = new System.Drawing.Point(319, 20);
            this.operationMode.Name = "operationMode";
            this.operationMode.Size = new System.Drawing.Size(54, 21);
            this.operationMode.TabIndex = 5;
            this.operationMode.SelectedIndexChanged += new System.EventHandler(this.operationMode_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Длина подблока";
            // 
            // segmentSize
            // 
            this.segmentSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.segmentSize.FormattingEnabled = true;
            this.segmentSize.Items.AddRange(new object[] {
            "128 b",
            "120 b",
            "112 b",
            "104 b",
            "96 b",
            "88 b",
            "80 b",
            "72 b",
            "64 b",
            "56 b",
            "48 b",
            "40 b",
            "32 b",
            "24 b",
            "16 b",
            "8 b"});
            this.segmentSize.Location = new System.Drawing.Point(319, 47);
            this.segmentSize.Name = "segmentSize";
            this.segmentSize.Size = new System.Drawing.Size(54, 21);
            this.segmentSize.TabIndex = 7;
            this.segmentSize.SelectedIndexChanged += new System.EventHandler(this.segmentSize_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.password);
            this.groupBox4.Location = new System.Drawing.Point(6, 91);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(384, 79);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Безопасность";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(121, 19);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(252, 20);
            this.password.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Ключ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(11, 109);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(405, 162);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 411);
            this.Controls.Add(this.abortOperation);
            this.Controls.Add(this.performOperation);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(444, 450);
            this.MinimumSize = new System.Drawing.Size(444, 450);
            this.Name = "Form1";
            this.Text = "Шифрование файлов с помощью Serpent";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveDstFile;
        private System.Windows.Forms.TextBox dstFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button openSrcFile;
        private System.Windows.Forms.TextBox srcFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Button performOperation;
        private System.Windows.Forms.Button abortOperation;
        private System.ComponentModel.BackgroundWorker encryptWorker;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox decryptPassword;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox segmentSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox operationMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox keySize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox blockSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

