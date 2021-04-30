using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AutoVersion:BaseEntity
    {
        public string AutoVersionName { get; set; }
        public DateTime? StartProductionYear { get; set; }
        public DateTime? EndProductionYear { get; set; }
        public string ImagePath { get; set; }

        [ForeignKey("AutoModel")]
        public int AutoModelId { get; set; }
        public virtual AutoModel AutoModel { get; set; }

        [ForeignKey("AutoBodyType")]
        public int AutoBodyTypeId { get; set; }
        public virtual AutoBodyType AutoBodyType { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

    }
}
