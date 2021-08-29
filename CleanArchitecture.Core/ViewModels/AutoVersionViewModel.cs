using CleanArchitecture.Core.DTO;
using CleanArchitecture.Core.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels
{
    public class AutoVersionViewModel:AutoSolutionBaseViewModel
    {
        public AutoVersionViewModel()
        {
            //AutoSpecification = new List<AutoSpecificationSubDTO>();
            //AutoManufacturerLookup
        }
        public string AutoVersionName { get; set; }
        public string ModelName { get; set; }
        public string AutoManufacturerName { get; set; }
        public DateTime? StartProductionYear { get; set; }
        public DateTime? EndProductionYear { get; set; }
        public string ImagePath { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal PreviousPrice { get; set; }
        public int EngineCapacity { get; set; }
        public double GroundClearance { get; set; }
        public double RunningGroundClearance { get; set; }
        public string SpareWheel { get; set; }
        public string WheelType { get; set; }
        public string TyreSize { get; set; }
        #region Dimension
        public double ExteriorLength { get; set; }
        public double ExteriorWidth { get; set; }
        public double ExteriorHeight { get; set; }
        public double InteriorLength { get; set; }
        public double InteriorWidth { get; set; }
        public double InteriorHeight { get; set; }
        public double Wheelbase { get; set; }
        public double MinimumGroundClearance { get; set; }
        public double TreadFront { get; set; }
        public double TreadRear { get; set; }
        public double OverhangFront { get; set; }
        public double OverhangRear { get; set; }
        #endregion

        #region
        public int SeatingCapacity { get; set; }
        public int FuelTankCapacity { get; set; }
        public int CrubWeight { get; set; }
        public int GrossVehicleWeigth { get; set; }
        #endregion


        #region uploads
        public IFormFile DefaultImage { get; set; }
        public IFormFileCollection GallaryImages { get; set; }
        #endregion
        public int SelectedAutoModel { get; set; }

        public string SelectedAutoModelText { get; set; }
        public List<SelectListItem> AutoModelLookup { get; set; }
        
        public int SelectedManufacturer { get; set; }
        public List<SelectListItem> AutoManufacturerLookup { get; set; }
        public int SelectedBodyType { get; set; }
        public List<SelectListItem> AutoBodyTypeLookup { get; set; }

        public List<SelectListItem> AutoEngineTypeLookup { get; set; }
        public List<SelectListItem> AirBag { get; set; }
        public int SelectedStabilityControlSystem { get; set; }
        public List<SelectListItem> StabilityControlSystem { get; set; }
        public int SelectedTransmissionType { get; set; }

        public List<SelectListItem> TransmissionType { get; set; }
        public List<SelectListItem> AutoSpecification { get; set; }
        public string AutoSpecificationStr { get; set; } 

        public List<SelectListItem> SeatBelt { get; set; }
        public bool IsQuickAdd { get; set; } = true;

    }
}
