using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace wasiCore.Extensions
{
    public static class FileExtension
    {


        public static FileStream Create(string path)
        {
            DirectoryExtension.Create(path);
            return File.Create(path);
        }



        public static void Delete(this string path)
        {
            try
            {
                File.Delete(path);
            }
            catch { }
        }


        public static void Delete(this string path, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }


        public static void Copy(string sourceFileName, string destFileName, bool overwrite = false)
        {
            if (!File.Exists(sourceFileName)) return;
            DirectoryExtension.Create(destFileName);
            File.Copy(sourceFileName, destFileName, overwrite);
        }



        public static void Move(string sourceFileName, string destFileName, bool overwrite = false)
        {
            if (!File.Exists(sourceFileName)) return;
            DirectoryExtension.Create(destFileName);
            if (!overwrite && File.Exists(destFileName)) return;
            if (File.Exists(destFileName))
                File.Delete(destFileName);
            File.Move(sourceFileName, destFileName);
        }



        public static void AppendAllText(string path, string contents, Encoding encoding = null)
        {
            DirectoryExtension.Create(path);
            if (encoding is null)
                File.AppendAllText(path, contents);
            else
                File.AppendAllText(path, contents, encoding);
        }




        public static void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding = null)
        {
            DirectoryExtension.Create(path);
            if (encoding is null)
                File.AppendAllLines(path, contents);
            else
                File.AppendAllLines(path, contents, encoding);
        }




        public static string[] ReadAllLines(string path, Encoding encoding = null)
        {
            return !File.Exists(path) ? new string[] { } : File.ReadAllLines(path, encoding ?? Encoding.UTF8);
        }





        public static string ReadText(string path, Encoding encoding = null)
        {
            return !File.Exists(path) ? null : File.ReadAllText(path, encoding ?? Encoding.UTF8);
        }





        public static byte[] ReadAllBytes(string path)
        {
            return !File.Exists(path) ? new byte[] { } : File.ReadAllBytes(path);
        }




        public static IEnumerable<string> ReadLines(string path, Encoding encoding = null)
        {
            return !File.Exists(path) ? new List<string>() : File.ReadLines(path, encoding ?? Encoding.UTF8);
        }

    }
}
