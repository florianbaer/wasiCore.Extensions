using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace wasiCore.Extensions
{
    public static class DirectoryExtension
    {
        public static void Create(string directory)
        {
            if (string.IsNullOrEmpty(Path.GetExtension(directory)))
                directory += @"\";

            var directoryPath = Path.GetDirectoryName(directory);
            var dir = directoryPath?.Split('\\').First();

            directoryPath?.Split('\\').Skip(1).ToList().ForEach(item =>
            {
                dir += $@"\{item}";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            });
        }




        public static void Delete(string path, bool deleteRecursive = false)
        {
            if (!string.IsNullOrEmpty(Path.GetExtension(path))) return;
            
            path += @"\";

            if (deleteRecursive)
            {
                Directory.GetFiles(path).ToList().ForEach(file =>
                {
                    file.Delete();
                });
                Directory.GetDirectories(path).ToList().ForEach(dir =>
                {
                    Delete(dir, true);
                });

            }
            else if (!Directory.GetDirectories(path).Any() && !Directory.GetFiles(path).Any())
            {
                Directory.Delete(path);
            }
        }

    }
}
