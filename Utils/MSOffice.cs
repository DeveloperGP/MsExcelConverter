using System;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace MsExcelConverter.Utils
{
    static class MSOffice
    {
        public const long CONVERT_FILE_ERROR_CODE = 600;

        public static long ConvertFile(
            ref Excel.Application app,
            FileInfo source,
            string destFileName
        )
        {
            try
            {
                Excel._Workbook book = null;

                FileInfo tmpFile = new FileInfo(FileSystem.GetTempFileName());

                if (FileSystem.CopyFile(source, tmpFile) == 0)
                {
                    book = app.Workbooks.Open(tmpFile.FullName, Type.Missing, true);

                    book.SaveAs(
                        destFileName,
                        Excel.XlFileFormat.xlOpenXMLWorkbook,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Excel.XlSaveAsAccessMode.xlNoChange,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing
                    );

                    book.Close(false, Type.Missing, Type.Missing);

                    FileSystem.DeleteFile(tmpFile);

                    book = null;
                    tmpFile = null;

                    return 0;
                }
                else
                {
                    return FileSystem.COPY_FILE_ERROR_CODE;
                }
            }
            catch (Exception)
            {
                app = null;
                return CONVERT_FILE_ERROR_CODE;
            }
        }
    }
}
