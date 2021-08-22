using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.PageSet
{
    public class AutoSolutionPageSet<TEntity> where TEntity : class
    {
        public Pager Pager { get; set; }
        public List<TEntity> Data { get; set; }
        public List<SelectListItem> AutoManufacturerLookup { get; set; }
    }
}
