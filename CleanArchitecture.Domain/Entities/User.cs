using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class User :BaseEntity
    {
        public string UserName { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
