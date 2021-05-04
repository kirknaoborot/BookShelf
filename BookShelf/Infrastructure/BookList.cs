using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Models
{
    public class BookList
    {
        private readonly BookContext _bookContext;
        /// <summary>
        /// Список книг(Полка)
        /// </summary>
        public List<Book> Books { get; set; }

        public BookList(BookContext bookContext)
        {
            _bookContext = bookContext;
            Books = _bookContext.Books.ToList();
        }

        /// <summary>
        /// Метод добавления книги
        /// </summary>
        /// <param name="book">Экземпляр книги</param>
        public void AddBook(Book book)
        {
            _bookContext.Books.Add(book);
            Save();
        }
        /// <summary>
        /// Удалиь книгу
        /// </summary>
        /// <param name="book">Экземпляр книги</param>
        public void DeleteBook(Book book)
        {
            Books.Remove(book);
            Save();
        }
        /// <summary>
        /// Метод возвращающий экземпляр книги
        /// </summary>
        /// <param name="IdBook">Идентификатор книги</param>
        /// <returns></returns>
        public Book GetBook(Guid IdBook)
        {
            return _bookContext.Books.FirstOrDefault(x => x.Id == IdBook);
        }

        public void Save()
        {
            _bookContext.SaveChanges();
        }
    }
}
