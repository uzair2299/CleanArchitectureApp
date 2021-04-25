using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AutoModel:BaseEntity
    {
        public string ModelName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        //public DateTime StartYear { get; set; }
        
        //public DateTime EndYear { get; set; }
        
        [ForeignKey("AutoManufacturer")]
        public int AutoManufacturerId { get; set; }
        
        public virtual AutoManufacturer AutoManufacturer { get; set; }

        public virtual ICollection<AutoVersion> AutoVersions { get; set; }
    }
}
