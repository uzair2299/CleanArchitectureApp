using CleanArchitecture.Core.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels
{
    public class AutoManufacturerViewModel : AutoSolutionBaseViewModel
    {
        public string AutoManufacturerName { get; set; }
        public string ImagePath { get; set; }
        public string CurrentImagePath { get; set; }
        public bool IsPopular { get; set; } = true;
        //public SelectListItem IsPopular = new SelectListItem
        //{
        //    Text = "",
        //    Value = "",
        //    Selected = true
        //};
    }
} 
