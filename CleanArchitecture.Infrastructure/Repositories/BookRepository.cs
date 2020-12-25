using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return  new List<Book>{
                new Book{Id=1,Name="Programming Fundametals",ISBN="ABC123",AuthorName="D&D"},
                new Book{Id=1,Name="Operating System",ISBN="ABC789",AuthorName="Dummies"}
            };
        }
    }
}
