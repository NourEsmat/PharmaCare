using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using PharmaCare.Core.Services;

namespace PharmaCare.infrastructure.Repositories.Service
{
    public class ImageManagmentService : IImageManagmentService
    {
        public readonly IFileProvider fileProvider;
        public ImageManagmentService(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }
        public async Task<List<string>> AddImage(IFormFileCollection files, string folderName)
        {
            List<string> fileList = new List<string>();
            var filedirectory = Path.Combine("wwwroot", "images", folderName);

            if (!Directory.Exists(filedirectory))
            {
                Directory.CreateDirectory(filedirectory);
            }

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var fileName = file.FileName;
                    var fileSrc = $"images/{folderName}/{fileName}";
                    var filePath = Path.Combine(filedirectory, fileName);
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    fileList.Add(fileSrc);
                }
            }
            return fileList;
        }


        public void DeleteImage(string foldername)
        {
            var info = fileProvider.GetFileInfo(foldername);
            var root = info.PhysicalPath;
            if (File.Exists(root))
            {
                File.Delete(root);
            }
            else
            {
                throw new DirectoryNotFoundException($"The directory {foldername} does not exist.");
            }
        }
    }
}
