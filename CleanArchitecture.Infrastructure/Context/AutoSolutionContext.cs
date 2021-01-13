using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Context
{
   public class AutoSolutionContext:DbContext
    {
         public AutoSolutionContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
