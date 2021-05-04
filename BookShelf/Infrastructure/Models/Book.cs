using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.Models
{
    public class Book
    {
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        Guid id;
        /// <summary>
        /// Название книги
        /// </summary>
        string name;
        /// <summary>
        /// Автор книги
        /// </summary>
        string author;
        /// <summary>
        /// Дата публикации
        /// </summary>
        DateTime datePublished;
        /// <summary>
        /// Признак выдана книги или нет
        /// </summary>
        bool given;
        public Book() { }
        /// <summary>
        /// Конструктор книги
        /// </summary>
        /// <param name="_name">Название книги</param>
        /// <param name="_author">Автор книги</param>
        public Book(string _name,string _author, bool _given)
        {
            Id = Guid.NewGuid();
            Name = _name;
            Author = _author;
            Given = _given;
        }
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public Guid Id { get => id; set => id = value; }
        /// <summary>
        /// Название книги
        /// </summary>
        [DisplayName("Название книги")]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Автор книги
        /// </summary>
        [DisplayName("Автор книги")]
        public string Author { get => author; set => author = value; }
        /// <summary>
        /// Дата публикации
        /// </summary>
        [DisplayName("Дата публикации")]
        public DateTime DatePublished { get => datePublished; set => datePublished = value; }
        /// <summary>
        /// Признак выдачи
        /// </summary>
        [DisplayName("Выдана")]
        public bool Given { get => given; set => given = value; }

    }
}
