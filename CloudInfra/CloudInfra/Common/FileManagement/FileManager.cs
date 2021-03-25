using CloudInfra.Common.Json;
using System.IO;
using System.Linq;

namespace CloudInfra.Common.FileManagement
{
    public class FileManager : IFileSystem
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
            CreateDirectory(subPath);
            var fileFullPath = FileFullPath(subPath, fileName);
            File.WriteAllText(fileFullPath, fileContent);
        }

        public void WriteJsonFile<T>(T obj,string subPath, string fileName)
        where T : class , new()
        {
            JsonSerializer _jsonData = new JsonSerializer();
            var jsonContent=_jsonData.Serialize(obj);
            
            WriteFile(subPath, fileName, jsonContent);
        }

        private bool DirectoryExists(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            return false;
        }

        public bool FileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            return false;
        }

        private string FileFullPath(string subPath, string fileName)
        {
            var filesCount= GetAllDirectory(subPath).Count();
            int fileNumber = ++filesCount;
            string newFileName = string.Concat(fileNumber.ToString(), "_", fileName);
            string fileFullPath = string.Concat(subPath, @"\", newFileName);
            return fileFullPath;
        }

        public void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        public void DeleteDirectory(string directoryPath)
        {
            Directory.Delete(directoryPath);
        }

        public string[] GetAllDirectory(string path)
        {
           return Directory.EnumerateDirectories(path).ToArray() ;
        }

        public string[] GetAllFile(string path)
        {
            return Directory.GetFiles(path).ToArray();
        }
    }
}
