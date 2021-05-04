using System;
using BookShelf.Models;

namespace BookShelf.Interfaces
{
    public interface IBookRepository
    {
        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book);
        /// <summary>
        /// Удалить книгу
        /// </summary>
        /// <param name="book"></param>
        public void DeleteBook(Book book);
        /// <summary>
        /// Получить экземпляр книги
        /// </summary>
        /// <param name="Id">Идентификатор книги</param>
        /// <returns></returns>
        public Book GetBook(Guid Id);
        public void Save();
    }
}
