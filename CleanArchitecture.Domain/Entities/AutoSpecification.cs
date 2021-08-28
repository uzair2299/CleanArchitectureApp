using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AutoSpecification :BaseEntity
    {
        public AutoSpecification()
        {
            SpecificationSubParameter = new HashSet<AutoSpecification>();
        }
        public string SpecificationParameter { get; set; }

        [ForeignKey("AutoSpecification")]
        public int? ParentId { get; set; }
        public virtual AutoSpecification ParentNode { get; set; } 

        [ForeignKey("AutoLookUpType")]
        public int SpecificationTypeId { get; set; }
        public virtual AutoLookUpType SpecificationType { get; set; }

        public virtual ICollection<AutoVersionSpecification> AutoVersionSpecifications { get; set; }

        //public virtual ICollection<AutoSpecificationSub> AutoSpecificationSubs { get; set; }
        public virtual ICollection<AutoSpecification> SpecificationSubParameter { get; set; }


    }
}
