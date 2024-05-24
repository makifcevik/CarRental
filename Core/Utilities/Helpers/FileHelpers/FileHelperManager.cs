using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelpers
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string fileName, string root)
        {
            string fullPath = Path.Combine(root, fileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if(file.Length > 0)
            {
                if(!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid();
                string fileName = guid + extension;
                string fullPath = Path.Combine(root, fileName);

                using(FileStream fileStream = File.Create(fullPath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return fileName;
                }
            }
            return null;
        }
    }
}
