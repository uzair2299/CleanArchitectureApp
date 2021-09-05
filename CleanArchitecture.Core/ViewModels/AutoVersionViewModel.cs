using CleanArchitecture.Core.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.ViewModels
{
    public class AutoVersionViewModel:AutoSolutionBaseViewModel
    {
        public AutoVersionViewModel()
        {
            GallaryImages = new List<IFormFile>();
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
        public string InteriorSummary { get; set; }
        public string ExteriorSummary { get; set; }

        #region WheelTire
        public string SpareWheel { get; set; }
        public string TireSize { get; set; }
        #endregion

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
        public List<IFormFile> GallaryImages { get; set; }
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

        public int SelectedFrontBrakeSystem { get; set; }
        public int SelectedRearBrakeSystem { get; set; }
        public List<SelectListItem> BrakeSystem { get; set; }
        
        public int SelectedWheelType { get; set; }
        public List<SelectListItem> WheelAndTire { get; set; }

        public List<SelectListItem> AutoSpecification { get; set; }
        public string AutoSpecificationStr { get; set; }

        public int SelectSuspensionType { get; set; }
        public List<SelectListItem> SuspensionType { get; set; }
       
        public List<SelectListItem> SeatBelt { get; set; }
        public bool IsQuickAdd { get; set; } = true;

    }
}
