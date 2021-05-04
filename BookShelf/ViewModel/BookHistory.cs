using BookShelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.ViewModel
{
    public class BookHistory
    {
        public Book Book { get; set; }
        public List<History> Histories { get; set; }
        public List<Reader> Readers { get; set; }
    }
}
