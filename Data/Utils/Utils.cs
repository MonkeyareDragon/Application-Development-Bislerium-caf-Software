using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafé.Data.Utils
{
    public class Utils
    {
        public static string ApplicationDirectoryPath()
        {
            string folderPath = @"C:\Users\Public\Documents\BisleriumCafé";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                return folderPath;
            }
            else
            {
                return folderPath;
            }
        }

        public static string ApplicationFilePath(string fileName)
        {
            string folderPath = ApplicationDirectoryPath();
            string filePath = Path.Combine(folderPath, fileName);
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
                return filePath;
            }
            else
            {
                return filePath;
            }
        }   
    }
}
