using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels
{
    public class AutoModelViewModel
    {
        public AutoModelViewModel()
        {
            PageNo = 1;
            PageSize = 10;
        }

        public int Id { get; set; }
        public string ModelName { get; set; }
        public string SelectedManufacturer { get; set; }
        public string AutoManufacturerName { get; set; }
        public List<SelectListItem> AutoManufacturerLookup { get; set; }

        //public DateTime CreatedOn { get; set; }

        //public DateTime ModifiedOn { get; set; }

        //public string CreatedBy { get; set; }

        //public string ModifiedBy { get; set; }

        //public DateTime StartYear { get; set; }

        //public DateTime EndYear { get; set; }

        public string SearchTerm { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int AutoManufacturerId { get; set; }

    }
}
