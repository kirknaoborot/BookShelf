using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Models
{
    public class Visitors
    {
        private readonly BookContext bookContext;
        public List<Reader> Readers { get; set; }

        public Visitors(BookContext _bookContext)
        {
            bookContext = _bookContext;
            Readers = bookContext.Readers.Include(b=>b.Books).ToList();
        }

        /// <summary>
        /// Добавить читателя
        /// </summary>
        /// <param name="reader"></param>
        public void AddReader(Reader reader)
        {
            bookContext.Readers.Add(reader);
            Save();
        }
        /// <summary>
        /// Удалить читателя
        /// </summary>
        /// <param name="reader"></param>
        public void DeleteReader(Reader reader)
        {
            bookContext.Readers.Remove(reader);
        }
        /// <summary>
        /// Получить экземпляр читателя
        /// </summary>
        /// <param name="Id">Идентификтор читателя</param>
        public Reader GetReader(Guid Id)
        {
          return Readers.FirstOrDefault(x => x.Id == Id);
        }

        public void Save()
        {
            bookContext.SaveChanges();
        }
    }
}
