using System;
using System.Collections.Generic;
using System.Text;

namespace CloudInfra.Common.FileManagement
{
    public interface IFileSystem
    {
        void WriteTextFile(string subPath, string fileName, string fileContent);
    }
}
