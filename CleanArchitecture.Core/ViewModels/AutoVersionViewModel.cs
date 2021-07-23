using CleanArchitecture.Core.DTO;
using CleanArchitecture.Core.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels
{
    public class AutoVersionViewModel:AutoSolutionBaseViewModel
    {
        public string AutoVersionName { get; set; }
        public string ModelName { get; set; }
        public string AutoManufacturerName { get; set; }
        public DateTime? StartProductionYear { get; set; }
        public DateTime? EndProductionYear { get; set; }
        public string ImagePath { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal PreviousPrice { get; set; }
        public int EngineCapacity { get; set; }
        public int GroundClearance { get; set; }
        public int RunningGroundClearance { get; set; }
        public string SpareWheel { get; set; }
        public string WheelType { get; set; }
        public string TyreSize { get; set; }
        #region Dimension
        public int ExteriorLength { get; set; }
        public int ExteriorWidth { get; set; }
        public int ExteriorHeight { get; set; }
        public int InteriorLength { get; set; }
        public int InteriorWidth { get; set; }
        public int InteriorHeight { get; set; }
        public int Wheelbase { get; set; }
        public int MinimumGroundClearance { get; set; }
        public int TreadFront { get; set; }
        public int TreadRear { get; set; }
        public int OverhangFront { get; set; }
        public int OverhangRear { get; set; }
        #endregion

        #region
        public int SeatingCapacity { get; set; }
        public int FuelTankCapacity { get; set; }
        public int CrubWeight { get; set; }
        public int GrossVehicleWeigth { get; set; }
        #endregion

        public string SelectedAutoModel { get; set; }
        public List<SelectListItem> AutoModelLookup { get; set; }
        
        public string SelectedManufacturer { get; set; }
        public List<SelectListItem> AutoManufacturerLookup { get; set; }
        public List<SelectListItem> AutoBodyTypeLookup { get; set; }

        public List<SelectListItem> AutoEngineTypeLookup { get; set; }


    }
}
