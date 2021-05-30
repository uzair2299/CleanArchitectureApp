using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
   public class Permission: BaseEntity
    {

        public string ActionName { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public bool IsActive { get; set; }
        public virtual ICollection<RolePermissions> RolePermissions { get; set; }
    }
}
