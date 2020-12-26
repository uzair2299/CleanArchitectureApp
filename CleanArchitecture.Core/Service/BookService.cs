using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository,IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public void BookMapper(BookViewModelMapper bookViewModel)
        {
            Book book = new Book();
            book = mapper.Map<Book>(bookViewModel);
        }


        public BookViewModel GetBooks()
        {
            return new BookViewModel()
            {
                Books = bookRepository.GetBooks()
            };
        }
    }
}
