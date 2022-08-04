using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelperManager : IFileHelper
    {
        public string Add(IFormFile formFile, string root)
        {
            if (formFile != null)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string imageExtension = Path.GetExtension(formFile.FileName);
                string imageName = Guid.NewGuid().ToString() + imageExtension;
                using (FileStream fileStream = File.Create(root + imageName))
                {
                    formFile.CopyTo(fileStream);
                    fileStream.Flush();
                    return imageName;
                }
            }
            return null;
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile formFile, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Add(formFile, root);
        }
    }
}
