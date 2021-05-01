using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AutoEngineType
    {
        public int Id { get; set; }
        public string EngineTypeName { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public DateTime ModifiedOn { get; set; }
        
        public string CreatedBy { get; set; }
        
        public string ModifiedBy { get; set; }

        public string Description { get; set; }
        public virtual ICollection<AutoVersion> AutoVersions { get; set; }
    }
}
