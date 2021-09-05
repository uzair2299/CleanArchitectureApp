using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.UI.Utility
{
    public interface IFileUploadUtility
    {   
        public string UplaodFile(IFormFile file);
        public string[] UplaodFile(List<IFormFile> files);
    }
}
