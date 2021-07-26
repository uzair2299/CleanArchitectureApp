using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AutoSpecificationSub :BaseEntity
    {
        public string SpecificationSubParameter { get; set; }

        //[ForeignKey("AutoSpecification")]
        //public int AutoSpecificationId { get; set; }
        //public virtual AutoSpecification AutoSpecification { get; set; }
    }
}
