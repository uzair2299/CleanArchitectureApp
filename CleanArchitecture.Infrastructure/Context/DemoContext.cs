using CleanArchitectureDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Context
{
   public class DemoContext:DbContext
    {
         public DemoContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
