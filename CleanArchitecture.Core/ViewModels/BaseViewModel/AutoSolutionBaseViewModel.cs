using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels.BaseViewModel
{
    public abstract class AutoSolutionBaseViewModel
    {
        public AutoSolutionBaseViewModel()
        {
            PageNo = 1;
            PageSize = 10;
        }
            
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string SearchTerm { get; set; }
        public int PageNo { get; set; }

        public int PageSize { get; set; }
    }
}
