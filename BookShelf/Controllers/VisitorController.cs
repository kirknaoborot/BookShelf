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
        Visitors _visitors;

        public VisitorController(ILogger<VisitorController> logger, BookContext bookContext)
        {
            _logger = logger;
            _visitors = new Visitors(bookContext);
        }

        // GET: VisitorController
        public ActionResult Index()
        {
            return View(_visitors.Readers);
        }

        // GET: VisitorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VisitorController/Create
        public IActionResult CreateReader()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateReader(Reader reader)
        {
            _visitors.AddReader(reader);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteReader(Guid Id)
        {
            var reader = _visitors.GetReader(Id);
            _visitors.DeleteReader(reader);
            return RedirectToAction("Index");
        }



    }
}
