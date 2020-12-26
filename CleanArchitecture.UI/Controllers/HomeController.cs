using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CleanArchitecture.UI.Models;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;

namespace CleanArchitecture.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService;

        public HomeController(IBookService bookService)
        { 
            this.bookService = bookService;
        }

        public IActionResult Index()
        {
            BookViewModel model = bookService.GetBooks();
            return View(model);
        }

        public IActionResult Privacy()
        {
            BookViewModelMapper bookViewModel = new BookViewModelMapper
            {
                Id = 1,
                Name = "aaa",
                AuthorName = "aaa",
                ISBN = "11111"
            };
            bookService.BookMapper(bookViewModel);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
