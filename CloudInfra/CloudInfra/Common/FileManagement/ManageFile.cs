using System.IO;

namespace CloudInfra.Common.FileManagement
{
    public class ManageFile : IFileSystem
    {
        public void CreateDirectory(string subPath)
        {
            if (!DirectoryExists(subPath))
            {
                Directory.CreateDirectory(subPath);
            }
        }
        private void WriteFile(string subPath, string fileName, string fileContent)
        {
            string fileFullPath = string.Concat(subPath, @"\", fileName);
            CreateDirectory(subPath);
            if (!FileExists(fileFullPath))
            {
                File.WriteAllText(fileFullPath, fileContent);
            }
        }
        public void WriteTextFile(string subPath, string fileName, string fileContent)
        {
            WriteFile(subPath, fileName, fileContent);
        }
        private bool DirectoryExists(string subPath)
        {
            if (Directory.Exists(subPath))
            {
                return true;
            }
            return false;
        }
        private bool FileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            return false;
        }
    }
}
