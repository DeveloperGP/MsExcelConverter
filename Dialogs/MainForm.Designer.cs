namespace MsExcelConverter.Dialogs
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.destLabel = new System.Windows.Forms.Label();
            this.sourcePathTextBox = new System.Windows.Forms.TextBox();
            this.destPathTextBox = new System.Windows.Forms.TextBox();
            this.sourceBrowserButton = new System.Windows.Forms.Button();
            this.destBrowserButton = new System.Windows.Forms.Button();
            this.progressTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.overwriteCheckBox = new System.Windows.Forms.CheckBox();
            this.converterBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.progressBar, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.sourceLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.destLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.sourcePathTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.destPathTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.sourceBrowserButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.destBrowserButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.progressTextBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.startButton, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.overwriteCheckBox, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(978, 704);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // progressBar
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.progressBar, 2);
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 614);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(972, 23);
            this.progressBar.TabIndex = 8;
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceLabel.Location = new System.Drawing.Point(3, 0);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(483, 30);
            this.sourceLabel.TabIndex = 0;
            this.sourceLabel.Text = "Источник:";
            this.sourceLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // destLabel
            // 
            this.destLabel.AutoSize = true;
            this.destLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.destLabel.Location = new System.Drawing.Point(492, 0);
            this.destLabel.Name = "destLabel";
            this.destLabel.Size = new System.Drawing.Size(483, 30);
            this.destLabel.TabIndex = 1;
            this.destLabel.Text = "Конечная директория:";
            this.destLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // sourcePathTextBox
            // 
            this.sourcePathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourcePathTextBox.Location = new System.Drawing.Point(3, 34);
            this.sourcePathTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sourcePathTextBox.Multiline = true;
            this.sourcePathTextBox.Name = "sourcePathTextBox";
            this.sourcePathTextBox.Size = new System.Drawing.Size(483, 87);
            this.sourcePathTextBox.TabIndex = 2;
            this.sourcePathTextBox.TextChanged += new System.EventHandler(this.SourcePathTextBox_TextChanged);
            // 
            // destPathTextBox
            // 
            this.destPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.destPathTextBox.Location = new System.Drawing.Point(492, 34);
            this.destPathTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.destPathTextBox.Multiline = true;
            this.destPathTextBox.Name = "destPathTextBox";
            this.destPathTextBox.ReadOnly = true;
            this.destPathTextBox.Size = new System.Drawing.Size(483, 87);
            this.destPathTextBox.TabIndex = 3;
            // 
            // sourceBrowserButton
            // 
            this.sourceBrowserButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.sourceBrowserButton.Location = new System.Drawing.Point(384, 129);
            this.sourceBrowserButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sourceBrowserButton.Name = "sourceBrowserButton";
            this.sourceBrowserButton.Size = new System.Drawing.Size(102, 40);
            this.sourceBrowserButton.TabIndex = 4;
            this.sourceBrowserButton.Tag = "source";
            this.sourceBrowserButton.Text = "Обзор...";
            this.sourceBrowserButton.UseVisualStyleBackColor = true;
            this.sourceBrowserButton.Click += new System.EventHandler(this.BrowserButton_Click);
            // 
            // destBrowserButton
            // 
            this.destBrowserButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.destBrowserButton.Location = new System.Drawing.Point(853, 129);
            this.destBrowserButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.destBrowserButton.Name = "destBrowserButton";
            this.destBrowserButton.Size = new System.Drawing.Size(122, 40);
            this.destBrowserButton.TabIndex = 5;
            this.destBrowserButton.Tag = "dest";
            this.destBrowserButton.Text = "Обзор...";
            this.destBrowserButton.UseVisualStyleBackColor = true;
            this.destBrowserButton.Click += new System.EventHandler(this.BrowserButton_Click);
            // 
            // progressTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.progressTextBox, 2);
            this.progressTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressTextBox.Location = new System.Drawing.Point(3, 177);
            this.progressTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressTextBox.Multiline = true;
            this.progressTextBox.Name = "progressTextBox";
            this.progressTextBox.ReadOnly = true;
            this.progressTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.progressTextBox.Size = new System.Drawing.Size(972, 429);
            this.progressTextBox.TabIndex = 6;
            // 
            // startButton
            // 
            this.startButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.startButton.Location = new System.Drawing.Point(811, 657);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(164, 43);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "#";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // overwriteCheckBox
            // 
            this.overwriteCheckBox.AutoSize = true;
            this.overwriteCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.overwriteCheckBox.Location = new System.Drawing.Point(16, 657);
            this.overwriteCheckBox.Margin = new System.Windows.Forms.Padding(16, 4, 3, 4);
            this.overwriteCheckBox.Name = "overwriteCheckBox";
            this.overwriteCheckBox.Size = new System.Drawing.Size(299, 43);
            this.overwriteCheckBox.TabIndex = 10;
            this.overwriteCheckBox.Text = "Перезаписывать конечные файлы";
            this.overwriteCheckBox.UseVisualStyleBackColor = true;
            this.overwriteCheckBox.CheckedChanged += new System.EventHandler(this.OverwriteCheckBox_CheckedChanged);
            // 
            // converterBackgroundWorker
            // 
            this.converterBackgroundWorker.WorkerReportsProgress = true;
            this.converterBackgroundWorker.WorkerSupportsCancellation = true;
            this.converterBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ConverterBackgroundWorker_DoWork);
            this.converterBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ConverterBackgroundWorker_ProgressChanged);
            this.converterBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ConverterBackgroundWorker_RunWorkerCompleted);
            // 
            // progressTimer
            // 
            this.progressTimer.Tick += new System.EventHandler(this.ProgressTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 704);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "#";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label destLabel;
        private System.Windows.Forms.TextBox sourcePathTextBox;
        private System.Windows.Forms.TextBox destPathTextBox;
        private System.Windows.Forms.Button sourceBrowserButton;
        private System.Windows.Forms.Button destBrowserButton;
        private System.Windows.Forms.TextBox progressTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox overwriteCheckBox;
        private System.ComponentModel.BackgroundWorker converterBackgroundWorker;
        private System.Windows.Forms.Timer progressTimer;
    }
}

