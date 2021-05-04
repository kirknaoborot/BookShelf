using BookShelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.ViewModel
{
    public class ReaderHistory
    {
        public Reader Reader { get; set; }
        public List<History> Histories { get; set; }
        public List<Book> Books { get; set; }
    }
}
