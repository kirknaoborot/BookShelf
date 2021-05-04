using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.Models
{
    public class CardReader
    {
        /// <summary>
        /// Идентификатор абонемента
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Читатель
        /// </summary>       
        public Guid ReaderId { get; set; }
        public Reader Reader { get; set; }
        /// <summary>
        /// Список книг
        /// </summary>
        public List<Book> Books { get; set; }


    }
}
