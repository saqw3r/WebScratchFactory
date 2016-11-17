using System;
using System.IO;
using System.Reflection;

namespace DownloadLib
{
    public class FileManager
    {
        public static string GetCurrentFolderPath()
        {
            string currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return currentPath;
        }

        public static bool SaveContent(string content, string pathToSave = null)
        {
            try
            {
                if (pathToSave == null)
                    pathToSave = GetCurrentFolderPath();
                
                File.WriteAllText(pathToSave, content);
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        public static bool SaveContent(byte[] content, string pathToSave = null)
        {
            if (pathToSave == null)
                pathToSave = GetCurrentFolderPath();

            using (FileStream fs = new FileStream(pathToSave, FileMode.Create))
            {
                fs.Write(content, 0, content.Length);
            }

            return true;
        }

        public static string EncodeUriToFileSystemName(string uri)
        {
            throw new NotImplementedException();
        }

        public static string DecodeFileSystemNameToUri(string fileSystemName)
        {
            throw new NotImplementedException();
        }
    }
}
