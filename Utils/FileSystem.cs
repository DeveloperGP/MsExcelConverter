using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MsExcelConverter.Utils
{
    static class FileSystem
    {
        public const long COPY_FILE_ERROR_CODE = 500;
        public const long DELETE_FILE_ERROR_CODE = 501;

        public static IEnumerable<string> GetFilesName(string path)
        {
            return (
                from dir in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                select dir
            );
        }

        public static string GetTempFileName()
        {
            return Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".tmp");
        }

        public static void CreateDirectory(DirectoryInfo directory)
        {
            if (!directory.Exists)
            {
                directory.Create();
            }
        }

        public static FileInfo GetDestFile(string source, string dest, FileInfo file, bool isXls)
        {
            string fileName = file.FullName.Substring(source.Length);
            if (fileName.IndexOf(Path.DirectorySeparatorChar) == 0)
            {
                fileName = fileName.Substring(1);
            }

            if (isXls)
                fileName = fileName.Substring(0, fileName.Length - "xls".Length) + "xlsx";

            fileName = fileName
                .Replace(
                    new string(new char[] { (char)32, Path.DirectorySeparatorChar }),
                    new string(new char[] { Path.DirectorySeparatorChar })
                )
                .Replace(
                    new string(new char[] { Path.DirectorySeparatorChar, (char)32 }),
                    new string(new char[] { Path.DirectorySeparatorChar })
                );

            return new FileInfo(Path.Combine(dest, fileName));
        }

        public static long CopyFile(FileInfo source, FileInfo dest)
        {
            try
            {
                CreateDirectory(dest.Directory);
                source.CopyTo(dest.FullName, true);
                return 0;
            }
            catch (Exception)
            {
                return COPY_FILE_ERROR_CODE;
            }
        }

        public static long DeleteFile(FileInfo file)
        {
            try
            {
                file.IsReadOnly = false;
                file.Delete();
                return 0;
            }
            catch (Exception)
            {
                return DELETE_FILE_ERROR_CODE;
            }
        }
    }
}
