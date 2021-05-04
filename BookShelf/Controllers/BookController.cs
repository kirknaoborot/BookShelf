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
        BookContext _context;

        public BookController(ILogger<BookController> logger, BookContext bookContext)
        {            
            _logger = logger;
            _context = bookContext;
        }

        // GET: BookController
        public ActionResult Index()
        {
            return View(_context.Books);
        }

        // GET: BookController/CreateBook
        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBook(Guid Id)
        {
            var book = _context.Books.First(x => x.Id == Id);
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
