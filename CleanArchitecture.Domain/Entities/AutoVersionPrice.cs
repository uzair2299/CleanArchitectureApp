using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AutoVersionPrice : BaseEntity
    {
        public Decimal Price { get; set; }
        public Decimal EndPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        [ForeignKey("AutoVersion")]
        public int AutoVersionId { get; set; }
        public virtual AutoVersion AutoVersion { get; set; }

    }
}
