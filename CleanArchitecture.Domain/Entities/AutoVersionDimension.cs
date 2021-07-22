using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AutoVersionDimension:BaseEntity
    {
        public int ExteriorLength { get; set; }
        public int ExteriorWidth { get; set; }
        public int ExteriorHeight { get; set; }
        public int InteriorLength { get; set; }
        public int InteriorWidth { get; set; }
        public int InteriorHeight { get; set; }
        public int Wheelbase { get; set; }
        public int MinimumGroundClearance { get; set; }
        public int TreadFront {get;set;}
        public int TreadRear { get; set; }
        public int OverhangFront { get; set; }
        public int OverhangRear { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        [ForeignKey("AutoVersion")]
        public int AutoVersionId { get; set; }
        public virtual AutoVersion AutoVersion { get; set; }

    }
}
