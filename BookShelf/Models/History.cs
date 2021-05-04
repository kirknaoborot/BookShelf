using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.Models
{
    public class History
    {
        public Guid Id { get; set; }

        public Guid ReaderId { get; set; }

        public Reader Reader { get; set; }
        public Guid BookId { get; set; }

        public Book Book { get; set; }
        /// <summary>
        /// Дата взятия книги
        /// </summary>
        public DateTime? DateOfCapture { get; set; }
        /// <summary>
        /// Дата возврата книги
        /// </summary>
        public DateTime? ReturnDate { get; set; }

    }
}
