using BookShelf.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.Controllers
{
    
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        BookList _bookList;

        public BookController(ILogger<BookController> logger, BookContext bookContext)
        {
            _bookList = new BookList(bookContext);
            _logger = logger;
        }

        // GET: BookController
        public ActionResult Index()
        {
            return View(_bookList.Books);
        }

        // GET: BookController/CreateBook
        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            _bookList.AddBook(book);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBook(Guid Id)
        {
            _bookList.DeleteBook(_bookList.GetBook(Id));
            return RedirectToAction("Index");
        }

    }
}
