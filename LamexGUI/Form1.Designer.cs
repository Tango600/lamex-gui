namespace LamexGUI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chShutdownWhenDone = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbScript = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.spCodecParams = new System.Windows.Forms.ToolStripStatusLabel();
            this.spProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.spProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.chRecursive = new System.Windows.Forms.CheckBox();
            this.chDeleteOrigin = new System.Windows.Forms.CheckBox();
            this.lbQualityPreset = new System.Windows.Forms.Label();
            this.btConvert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chCBR = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbExcludePatterns = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbExcludePattern = new System.Windows.Forms.TextBox();
            this.trbQuality = new System.Windows.Forms.TrackBar();
            this.btChangeDir = new System.Windows.Forms.Button();
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chShutdownWhenDone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbScript);
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.Controls.Add(this.chRecursive);
            this.groupBox1.Controls.Add(this.chDeleteOrigin);
            this.groupBox1.Controls.Add(this.lbQualityPreset);
            this.groupBox1.Controls.Add(this.btConvert);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chCBR);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbExcludePatterns);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbExcludePattern);
            this.groupBox1.Controls.Add(this.trbQuality);
            this.groupBox1.Controls.Add(this.btChangeDir);
            this.groupBox1.Controls.Add(this.tbDirectory);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 327);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chShutdownWhenDone
            // 
            this.chShutdownWhenDone.AutoSize = true;
            this.chShutdownWhenDone.Location = new System.Drawing.Point(118, 280);
            this.chShutdownWhenDone.Name = "chShutdownWhenDone";
            this.chShutdownWhenDone.Size = new System.Drawing.Size(163, 17);
            this.chShutdownWhenDone.TabIndex = 18;
            this.chShutdownWhenDone.Text = "Выключить по завершении";
            this.chShutdownWhenDone.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Создать скрипт";
            // 
            // cbScript
            // 
            this.cbScript.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScript.FormattingEnabled = true;
            this.cbScript.Items.AddRange(new object[] {
            "Не создавать",
            "Создать",
            "Только скрипт"});
            this.cbScript.Location = new System.Drawing.Point(105, 251);
            this.cbScript.Name = "cbScript";
            this.cbScript.Size = new System.Drawing.Size(82, 21);
            this.cbScript.TabIndex = 16;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spCodecParams,
            this.spProgressLabel,
            this.spProgress});
            this.statusStrip1.Location = new System.Drawing.Point(3, 302);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(290, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // spCodecParams
            // 
            this.spCodecParams.Name = "spCodecParams";
            this.spCodecParams.Size = new System.Drawing.Size(0, 17);
            // 
            // spProgressLabel
            // 
            this.spProgressLabel.Name = "spProgressLabel";
            this.spProgressLabel.Size = new System.Drawing.Size(62, 17);
            this.spProgressLabel.Text = "Осталось:";
            // 
            // spProgress
            // 
            this.spProgress.Name = "spProgress";
            this.spProgress.Size = new System.Drawing.Size(23, 17);
            this.spProgress.Text = "<>";
            // 
            // chRecursive
            // 
            this.chRecursive.AutoSize = true;
            this.chRecursive.Checked = true;
            this.chRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chRecursive.Location = new System.Drawing.Point(89, 15);
            this.chRecursive.Name = "chRecursive";
            this.chRecursive.Size = new System.Drawing.Size(74, 17);
            this.chRecursive.TabIndex = 12;
            this.chRecursive.Text = "в глубину";
            this.chRecursive.UseVisualStyleBackColor = true;
            // 
            // chDeleteOrigin
            // 
            this.chDeleteOrigin.AutoSize = true;
            this.chDeleteOrigin.Location = new System.Drawing.Point(123, 153);
            this.chDeleteOrigin.Name = "chDeleteOrigin";
            this.chDeleteOrigin.Size = new System.Drawing.Size(119, 17);
            this.chDeleteOrigin.TabIndex = 11;
            this.chDeleteOrigin.Text = "Удалить оригинал";
            this.chDeleteOrigin.UseVisualStyleBackColor = true;
            this.chDeleteOrigin.CheckedChanged += new System.EventHandler(this.chDeleteOrigin_CheckedChanged);
            // 
            // lbQualityPreset
            // 
            this.lbQualityPreset.AutoSize = true;
            this.lbQualityPreset.Location = new System.Drawing.Point(86, 64);
            this.lbQualityPreset.Name = "lbQualityPreset";
            this.lbQualityPreset.Size = new System.Drawing.Size(19, 13);
            this.lbQualityPreset.TabIndex = 10;
            this.lbQualityPreset.Text = "<>";
            // 
            // btConvert
            // 
            this.btConvert.Location = new System.Drawing.Point(206, 251);
            this.btConvert.Name = "btConvert";
            this.btConvert.Size = new System.Drawing.Size(75, 23);
            this.btConvert.TabIndex = 9;
            this.btConvert.Text = "Запустить";
            this.btConvert.UseVisualStyleBackColor = true;
            this.btConvert.Click += new System.EventHandler(this.btConvert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Директория";
            // 
            // chCBR
            // 
            this.chCBR.AutoSize = true;
            this.chCBR.Location = new System.Drawing.Point(240, 131);
            this.chCBR.Name = "chCBR";
            this.chCBR.Size = new System.Drawing.Size(48, 17);
            this.chCBR.TabIndex = 7;
            this.chCBR.Text = "CBR";
            this.chCBR.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Качество";
            // 
            // lbExcludePatterns
            // 
            this.lbExcludePatterns.FormattingEnabled = true;
            this.lbExcludePatterns.Location = new System.Drawing.Point(10, 176);
            this.lbExcludePatterns.Name = "lbExcludePatterns";
            this.lbExcludePatterns.Size = new System.Drawing.Size(271, 69);
            this.lbExcludePatterns.TabIndex = 5;
            this.lbExcludePatterns.DoubleClick += new System.EventHandler(this.lbExcludePatterns_DoubleClick);
            this.lbExcludePatterns.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbExcludePatterns_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Маска для исключения";
            // 
            // tbExcludePattern
            // 
            this.tbExcludePattern.Location = new System.Drawing.Point(10, 151);
            this.tbExcludePattern.Name = "tbExcludePattern";
            this.tbExcludePattern.Size = new System.Drawing.Size(100, 20);
            this.tbExcludePattern.TabIndex = 3;
            this.tbExcludePattern.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbExcludePattern_KeyUp);
            // 
            // trbQuality
            // 
            this.trbQuality.LargeChange = 2;
            this.trbQuality.Location = new System.Drawing.Point(10, 80);
            this.trbQuality.Maximum = 15;
            this.trbQuality.Minimum = 1;
            this.trbQuality.Name = "trbQuality";
            this.trbQuality.Size = new System.Drawing.Size(271, 45);
            this.trbQuality.TabIndex = 2;
            this.trbQuality.Value = 10;
            this.trbQuality.Scroll += new System.EventHandler(this.trbQuality_Scroll);
            // 
            // btChangeDir
            // 
            this.btChangeDir.Location = new System.Drawing.Point(264, 30);
            this.btChangeDir.Name = "btChangeDir";
            this.btChangeDir.Size = new System.Drawing.Size(24, 23);
            this.btChangeDir.TabIndex = 1;
            this.btChangeDir.Text = "...";
            this.btChangeDir.UseVisualStyleBackColor = true;
            this.btChangeDir.Click += new System.EventHandler(this.btChangeDir_Click);
            // 
            // tbDirectory
            // 
            this.tbDirectory.Location = new System.Drawing.Point(10, 32);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(252, 20);
            this.tbDirectory.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1307;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 327);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LamexGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbQuality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chCBR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbExcludePatterns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbExcludePattern;
        private System.Windows.Forms.TrackBar trbQuality;
        private System.Windows.Forms.Button btChangeDir;
        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Button btConvert;
        private System.Windows.Forms.Label lbQualityPreset;
        private System.Windows.Forms.CheckBox chDeleteOrigin;
        private System.Windows.Forms.CheckBox chRecursive;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel spCodecParams;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel spProgress;
        private System.Windows.Forms.ToolStripStatusLabel spProgressLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbScript;
        private System.Windows.Forms.CheckBox chShutdownWhenDone;
    }
}

