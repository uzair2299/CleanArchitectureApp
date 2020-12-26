using CleanArchitecture.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
   public interface IBookService
    {
        BookViewModel GetBooks();
        void BookMapper(BookViewModelMapper bookViewModel);
    }
}
