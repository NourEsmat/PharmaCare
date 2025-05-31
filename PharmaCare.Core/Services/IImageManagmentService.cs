using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PharmaCare.Core.Services
{
    public interface IImageManagmentService
    {
        Task<List<string>> AddImage (IFormFileCollection files, string folderName);
        void DeleteImage(string foldername);
    }
}
