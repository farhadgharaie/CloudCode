namespace CloudInfra.Common.FileManagement
{
    public interface IFileManager
    {
        void WriteJsonFile<T>(T obj, string subPath, string fileName)
        where T : class, new();
        void DeleteFile(string filePath);
        void DeleteDirectory(string directoryPath);
        string[] GetAllDirectory(string path);
        string[] GetAllFile(string path);
        bool FileExists(string filePath);
    }
}
