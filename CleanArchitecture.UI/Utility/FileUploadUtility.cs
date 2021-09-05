using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CleanArchitecture.UI.Utility
{
    public class FileUploadUtility: IFileUploadUtility
    {
        private readonly IWebHostEnvironment env;
        private string uploadDirecotroy = "Images/";
        public FileUploadUtility(IWebHostEnvironment env)
        {
            this.env = env;
        }
        public string UplaodFile(IFormFile file)
        {
            var path = Path.Combine(env.WebRootPath, uploadDirecotroy);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(path, fileName);
            using (var stream = File.Create(filePath))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }

        public string[] UplaodFile(List<IFormFile> files)
        {
            if (files.Count>0 && !object.ReferenceEquals(files,null))
            {
                List<string> list = new List<string>();

                foreach (IFormFile formFile in files)
                {
                    var path = Path.Combine(env.WebRootPath, uploadDirecotroy);
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    var fileName_ = Guid.NewGuid() + Path.GetExtension(formFile.FileName);
                    list.Add(fileName_);
                    var filePath = Path.Combine(path, fileName_);
                    using (var stream = File.Create(filePath))
                    {
                        formFile.CopyTo(stream);
                    }
                }
                return list.ToArray();
            }
            else
            {
                return null;
            }

        }
    }
}
