using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AutoVersionWeightCapacity: BaseEntity
    {
        public int SeatingCapacity { get; set; }
        public int FuelTankCapacity { get; set; }
        public int CrubWeight { get; set; }
        public int GrossVehicleWeigth { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        [ForeignKey("AutoVersion")]
        public int AutoVersionId { get; set; }
        public virtual AutoVersion AutoVersion { get; set; }
    }
}
