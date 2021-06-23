using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AutoSpecification :BaseEntity
    {
        public string SpecificationParameter { get; set; }

        [ForeignKey("AutoLookUpType")]
        public int SpecificationTypeId { get; set; }
        public virtual AutoLookUpType SpecificationType { get; set; }
    }
}
