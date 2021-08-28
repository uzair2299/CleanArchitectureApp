using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AutoVersionSpecification
    {
        [Key ,Column(Order=1)]
        public int AutoVersionId { get; set; }

        [Key, Column(Order = 2)]
        public int AutoSpecificationId { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual AutoVersion AutoVersion { get; set; }
        public virtual AutoSpecification AutoSpecification { get; set; }
    }
}
