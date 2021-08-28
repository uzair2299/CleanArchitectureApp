using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AutoVersion : BaseEntity
    {
        public string AutoVersionName { get; set; }
        public DateTime? StartProductionYear { get; set; }
        public DateTime? EndProductionYear { get; set; }
        public string ImagePath { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? PreviousPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int EngineCapacity { get; set; }
        public int GroundClearance { get; set; }
        public int RunningGroundClearance { get; set; }


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

        #region Capacity
        public int SeatingCapacity { get; set; }
        public int FuelTankCapacity { get; set; }
        public int CrubWeight { get; set; }
        public int GrossVehicleWeigth { get; set; }
        #endregion

        #region Navigational Properties

        [ForeignKey("AutoModel")]
        public int AutoModelId { get; set; }
        public virtual AutoModel AutoModel { get; set; }

        [ForeignKey("AutoBodyType")]
        public int? AutoBodyTypeId { get; set; }
        public virtual AutoBodyType AutoBodyType { get; set; }

        [ForeignKey("AutoEngineType")]
        public int? AutoEngineTypeId { get; set; }
        public virtual AutoEngineType AutoEngineType { get; set; }


        public virtual ICollection<AutoVersionDimension> AutoVersionDimensions { get; set; }
        public virtual ICollection<AutoVersionWeightCapacity> AutoVersionWeightCapacities { get; set; }

        public virtual ICollection<AutoVersionSpecification> AutoVersionSpecifications { get; set; }
        #endregion
    }
}
