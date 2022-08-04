using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        string Add(IFormFile formFile,string root);
        string Update(IFormFile formFile,string filePath,string root);
        void Delete(string filePath);
    }
}
