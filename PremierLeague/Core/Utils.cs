using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Core
{
    public static class Utils
    {
        public static string getPath(string path, IFormFile formFile)
        {
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetFileName(formFile.FileName);
            string filePath = Path.Combine(path, fileName);
            return filePath;
        }
    }
}
