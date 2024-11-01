using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MsExcelConverter.Utils;
using Button = System.Windows.Forms.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using Excel = Microsoft.Office.Interop.Excel;
using TextBox = System.Windows.Forms.TextBox;

namespace MsExcelConverter.Dialogs
{
    public partial class MainForm : Form
    {
        private const string APP_TITLE = "Конвертирование файлов MS Office Excel";
        private const string CONVERT = "Конвертировать";
        private const string CANCEL = "Отмена";

        private string sourcePath = string.Empty;
        private string destPath = string.Empty;
        private bool overwriteFiles = false;

        private bool convertMode = false;

        private string progressText = string.Empty;
        private int progressPercentage = 0;

        public MainForm()
        {
            InitializeComponent();
            Text = APP_TITLE;
            startButton.Text = CONVERT;
            startButton.Enabled = (
                !string.IsNullOrEmpty(sourcePath) && !string.IsNullOrEmpty(destPath)
            );
        }

        private void BrowserButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = button.Tag.Equals("source")
                    ? "Выбор папки источника:"
                    : "Выбор папки назначения:",
                ShowNewFolderButton = !button.Tag.Equals("source"),
            };

            if (Directory.Exists(button.Tag.Equals("source") ? sourcePath : destPath))
            {
                dialog.SelectedPath = button.Tag.Equals("source") ? sourcePath : destPath;
            }

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (button.Tag.Equals("source"))
                {
                    sourcePath = dialog.SelectedPath;
                    sourcePathTextBox.Text = sourcePath;
                }
                else
                {
                    destPath = dialog.SelectedPath;
                    destPathTextBox.Text = destPath;
                }
            }
            startButton.Enabled = (
                !string.IsNullOrEmpty(sourcePath) && !string.IsNullOrEmpty(destPath)
            );
        }

        private void OverwriteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            overwriteFiles = checkBox.Checked;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!convertMode)
            {
                if (!string.IsNullOrEmpty(sourcePath) && !string.IsNullOrEmpty(destPath))
                {
                    progressText = string.Empty;
                    progressTextBox.Text = string.Empty;
                    sourceBrowserButton.Enabled = false;
                    sourcePathTextBox.ReadOnly = true;
                    sourcePathTextBox.BackColor = SystemColors.Control;
                    destBrowserButton.Enabled = false;
                    overwriteCheckBox.Enabled = false;

                    startButton.Text = CANCEL;
                    convertMode = true;
                    progressTimer.Start();

                    converterBackgroundWorker.RunWorkerAsync(
                        new object[] { sourcePath, destPath, overwriteFiles }
                    );
                }
            }
            else
            {
                converterBackgroundWorker.CancelAsync();
            }
        }

        #region Converter

        private void ConverterBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            string source = (string)((object[])e.Argument)[0];
            string dest = (string)((object[])e.Argument)[1];
            bool overwrite = (bool)((object[])e.Argument)[2];

            worker.ReportProgress(0, "Подготовка к конвертированию...");

            IList<string> files = new List<string>(FileSystem.GetFilesName(source));
            IList<ConvertResult.ErrorFile> errors = new List<ConvertResult.ErrorFile>();

            worker.ReportProgress(0, string.Format("Обнаружено {0} файлов(а)...", files.Count));

            Excel.Application appExcel = null;

            try
            {
                appExcel = new Excel.Application { Visible = false };

                long position = 0;
                foreach (string fullFileName in files)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    position += 1;
                    long percent = position * 100 / files.Count;

                    FileInfo file = new FileInfo(fullFileName);

                    if ((file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                        continue;

                    if (
                        file
                            .Extension.ToLower()
                            .Equals(".xls", StringComparison.CurrentCultureIgnoreCase)
                    )
                    {
                        FileInfo destFile = FileSystem.GetDestFile(source, dest, file, true);

                        if (destFile.Exists && !overwrite)
                        {
                            worker.ReportProgress(
                                (int)percent,
                                string.Format("Файл {0} пропущен...", file.Name)
                            );
                        }
                        else
                        {
                            if (destFile.Exists)
                                destFile.Delete();

                            FileSystem.CreateDirectory(destFile.Directory);

                            if (appExcel == null)
                            {
                                appExcel = new Excel.Application { Visible = false };
                            }

                            long code = MSOffice.ConvertFile(ref appExcel, file, destFile.FullName);

                            if (code == 0)
                            {
                                worker.ReportProgress(
                                    (int)percent,
                                    string.Format(
                                        "Конвертирование файла {0} выполнено...",
                                        file.Name
                                    )
                                );
                            }
                            else
                            {
                                errors.Add(
                                    new ConvertResult.ErrorFile
                                    {
                                        ErrorCode = code,
                                        SourceFileName = file.FullName,
                                        DestFileName = destFile.FullName,
                                    }
                                );
                                worker.ReportProgress(
                                    (int)percent,
                                    string.Format(
                                        "Ошибка при конвертировании файла {0}!",
                                        file.Name
                                    )
                                );
                            }
                        }
                    }
                    else
                    {
                        FileInfo destFile = FileSystem.GetDestFile(source, dest, file, false);

                        if (destFile.Exists && !overwrite)
                        {
                            worker.ReportProgress(
                                (int)percent,
                                string.Format("Файл {0} пропущен...", file.Name)
                            );
                        }
                        else
                        {
                            long code = FileSystem.CopyFile(file, destFile);
                            if (code == 0)
                            {
                                worker.ReportProgress(
                                    (int)percent,
                                    string.Format("Копирование файла {0} выполнено...", file.Name)
                                );
                            }
                            else
                            {
                                errors.Add(
                                    new ConvertResult.ErrorFile
                                    {
                                        ErrorCode = code,
                                        SourceFileName = file.FullName,
                                        DestFileName = destFile.FullName,
                                    }
                                );
                                worker.ReportProgress(
                                    (int)percent,
                                    string.Format("Ошибка при копировании файла {0}!", file.Name)
                                );
                            }
                        }
                    }
                }
                e.Result = new ConvertResult()
                {
                    Message =
                        errors.Count == 0
                            ? "Процесс конвертирования успешно окончен."
                            : string.Format(
                                "В процессе конвертирования обнаружено {0} ошибок!",
                                errors.Count
                            ),
                    Errors = errors,
                };
            }
            catch (Exception ex)
            {
                e.Result = "Ошибка: " + ex.Message;
                return;
            }
            finally
            {
                appExcel?.Quit();
                appExcel = null;
            }
        }

        private void ConverterBackgroundWorker_ProgressChanged(
            object sender,
            ProgressChangedEventArgs e
        )
        {
            string state = e.UserState as string;
            AppendText(state);
            progressPercentage = e.ProgressPercentage;
        }

        private void AppendText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (!string.IsNullOrEmpty(progressText))
                {
                    progressText += Environment.NewLine;
                }
                progressText += text;
            }
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            WriteToConsole(progressText);
            SetProgress(progressPercentage);
        }

        private void WriteToConsole(object text)
        {
            if (progressTextBox.InvokeRequired)
                progressTextBox.Invoke(new Action<object>(WriteToConsole), text);
            else
            {
                progressTextBox.Text = text as string;
                progressTextBox.SelectionStart = progressTextBox.Text.Length;
                progressTextBox.ScrollToCaret();
            }
        }

        private void SetProgress(object value)
        {
            if (progressBar.InvokeRequired)
                progressBar.Invoke(new Action<object>(SetProgress), value);
            else
            {
                progressBar.Value = (int)value;
                Text = string.Format("{0} - Конвертирование: {1} %", APP_TITLE, value);
            }
        }

        private void ConverterBackgroundWorker_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e
        )
        {
            if (e.Error != null)
            {
                AppendText(text: e.Error.Message);
            }
            else if (e.Cancelled)
            {
                AppendText(text: "Процесс конвертирования прерван пользователем.");
            }
            else
            {
                ConvertResult convertResult = e.Result as ConvertResult;

                AppendText(text: convertResult.Message);

                if (convertResult.Errors.Count != 0)
                {
                    foreach (ConvertResult.ErrorFile item in convertResult.Errors)
                    {
                        AppendText(
                            text: string.Format(
                                "Код ошибки: {0}; [{1}] => [{2}]",
                                item.ErrorCode,
                                item.SourceFileName,
                                item.DestFileName
                            )
                        );
                    }
                }
            }

            progressTimer.Stop();

            WriteToConsole(progressText);
            Text = APP_TITLE;
            progressBar.Value = 0;
            sourceBrowserButton.Enabled = true;
            sourcePathTextBox.ReadOnly = false;
            sourcePathTextBox.BackColor = SystemColors.Window;
            destBrowserButton.Enabled = true;
            overwriteCheckBox.Enabled = true;
            startButton.Text = CONVERT;
            convertMode = false;
        }

        #endregion

        private void SourcePathTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            sourcePath = textBox.Text;
            startButton.Enabled = (
                !string.IsNullOrEmpty(sourcePath) && !string.IsNullOrEmpty(destPath)
            );
        }

        private class ConvertResult
        {
            public string Message;

            public IList<ErrorFile> Errors;

            public class ErrorFile
            {
                public long ErrorCode;
                public string SourceFileName;
                public string DestFileName;
            }
        }
    }
}
