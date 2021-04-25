using CleanArchitecture.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AutoVersion:BaseEntity
    {
        public string AutoVersionName { get; set; }

        [ForeignKey("AutoModel")]
        public int AutoModelId { get; set; }
        public virtual AutoModel AutoModel { get; set; }

        [ForeignKey("AutoBodyType")]
        public int AutoBodyTypeId { get; set; }
        public virtual AutoBodyType AutoBodyType { get; set; }
    }
}
