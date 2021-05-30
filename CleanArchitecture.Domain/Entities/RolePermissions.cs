using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class RolePermissions: BaseEntity
    {
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey("Permission")]
        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}
