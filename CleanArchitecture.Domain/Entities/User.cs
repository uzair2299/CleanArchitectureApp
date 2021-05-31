using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class User :BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public string DateOfBirth { get; set; }

        public bool IsActive { get; set; }
        public string ProfileImagePath { get; set; }

        public string PersonalAddress { get; set; }
        public string PrimaryMobile { get; set; }

        public string SecondaryMobile { get; set; }

        public string PrimaryPhone { get; set; }

        public string SecondaryPhone { get; set; }

        public string FaxNumber { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }


        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}