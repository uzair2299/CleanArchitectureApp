using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.PageSet
{
    public class PageSet<TEntity> where TEntity : class
    {
        public int draw {get;set;}
        public int recordsTotal  { get; set;}
        public int recordsFiltered { get; set; }
        public List<TEntity> result { get; set; }
    }
}
