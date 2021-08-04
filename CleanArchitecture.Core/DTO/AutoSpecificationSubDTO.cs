using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTO
{
   public class AutoSpecificationSubDTO
    {
        public int Id { get; set; }
        public string SpecificationParameter { get; set; }
        public int SpecificationSubParameterId { get; set; }
        public string SpecificationSubParameter { get; set; }
        public string SpecificationType { get; set; }
    }
}
