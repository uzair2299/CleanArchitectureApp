using CleanArchitecture.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.PageSet
{
    public class AutoSolutionPageSet<TEntity> where TEntity : class
    {
        public Pager pager { get; set; }
        public List<TEntity> Data { get; set; }
    }
}
