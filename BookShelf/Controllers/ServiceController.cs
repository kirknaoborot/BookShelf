using BookShelf.Models;
using BookShelf.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.Controllers
{
    public class ServiceController : Controller
    {
        private readonly BookContext _context;

        public ServiceController(BookContext context)
        {
            _context = context;
        }

        // GET: ServiceController
        public ActionResult Index(Guid Id)
        {
            CardReader cardReader = new CardReader()
            {
                Reader = _context.Readers.Include(b => b.Books).FirstOrDefault(x => x.Id == Id),
                Books = _context.Books.Where(x => x.Given == false).ToList()
            };
            return View(cardReader);
        }

        public IActionResult ActionBook(Guid ReaderId, Guid BookId, bool ToTake)
        {
            var reader = _context.Readers.First(x => x.Id == ReaderId);
            var book = _context.Books.FirstOrDefault(x => x.Id == BookId);
            if (ToTake)
            {
                book.Given = true;
                reader.Books.Add(book);
                History history = new History()
                {
                    BookId = book.Id,
                    ReaderId = reader.Id,
                    DateOfCapture = DateTime.Now
                };
                _context.Histories.Add(history);
            }
            else
            {
                book.Given = false;
                reader.Books.Remove(book);
                var history = _context.Histories.Where(x => x.ReaderId == ReaderId && x.BookId == BookId && x.ReturnDate == null).FirstOrDefault();
                history.ReturnDate = DateTime.Now;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", new { Id = ReaderId });
        }

        public IActionResult ReadersHistory(Guid Id)
        {
     
            var reader = _context.Readers.FirstOrDefault(x => x.Id == Id);
            var history = _context.Histories.Where(x => x.ReaderId == Id);
            var books = _context.Books.Where(x =>history.Any(y=>y.BookId == x.Id));

            ReaderHistory readerHistory = new ReaderHistory()
            {
                Reader = reader,
                Histories = history.ToList(),
                Books = books.ToList()
            };

            return View(readerHistory);
        }

        public IActionResult BooksHistory(Guid Id)
        {

            var book = _context.Books.FirstOrDefault(x => x.Id == Id);
            var history = _context.Histories.Where(x => x.BookId == Id);
            var readers = _context.Readers.Where(x => history.Any(y => y.ReaderId == x.Id));

            BookHistory bookHistory = new BookHistory()
            {
                Book = book,
                Histories = history.ToList(),
                Readers = readers.ToList()
            };

            return View(bookHistory);
        }

        // GET: ServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
