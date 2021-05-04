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
    public class VisitorController : Controller
    {
        private readonly ILogger<VisitorController> _logger;
        BookContext _bookContext;

        public VisitorController(ILogger<VisitorController> logger, BookContext bookContext)
        {
            _logger = logger;
            _bookContext = bookContext;
        }

        // GET: VisitorController
        public ActionResult Index()
        {
            return View(_bookContext.Readers);
        }


        // GET: VisitorController/Create
        public IActionResult CreateReader()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateReader(Reader reader)
        {
            _bookContext.Readers.Add(reader);
            _bookContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteReader(Guid Id)
        {
            var reader = _bookContext.Readers.First(x=>x.Id==Id);
            _bookContext.Readers.Remove(reader);
            _bookContext.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
