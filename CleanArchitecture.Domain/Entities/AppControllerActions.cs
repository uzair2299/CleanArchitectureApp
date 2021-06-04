using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AppControllerActions : BaseEntity
    {
        public string ActionName { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("AppControllers")]
        public int ControllerId { get; set;}
        public virtual AppControllers AppControllers { get; set; }

    }
}
