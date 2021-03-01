using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }
    }
}
