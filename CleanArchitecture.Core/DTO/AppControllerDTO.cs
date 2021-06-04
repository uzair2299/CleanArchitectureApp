using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTO
{
    public class AppControllerDTO
    {
        public AppControllerDTO()
        {
            Action = new List<AppControllerActionDTO>();
        }
        public int ControllerId { get; set; }
        public string ControllerName { get; set; }
        public List<AppControllerActionDTO> Action { get; set; }
    }
}
