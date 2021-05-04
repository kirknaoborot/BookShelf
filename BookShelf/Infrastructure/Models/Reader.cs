using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.Models
{
    public class Reader
    {
        /// <summary>
        /// Идентификатор читателя
        /// </summary>
        Guid id;
        /// <summary>
        /// Имя
        /// </summary>
        string firstName;
        /// <summary>
        /// Фамилия
        /// </summary>
        string lastName;
        /// <summary>
        /// Отчество
        /// </summary>
        string middleName;
        /// <summary>
        /// Экземпляр читателя
        /// </summary>
        /// <param name="_firstName">Имя</param>
        /// <param name="_lastName">Фамилия</param>
        /// <param name="_middleName">Отчетсво</param>

        public Reader() {}
        public Reader(string _firstName, string _lastName, string _middleName)
        {
            Id = Guid.NewGuid();
            FirstName = _firstName;
            LastName = _lastName;
            MiddleName = _middleName;
        }
        /// <summary>
        /// Идентификатор читатели
        /// </summary>
        public Guid Id { get => id; set => id = value; }
        /// <summary>
        /// Имя
        /// </summary>
        [DisplayName("Имя")]
        public string FirstName { get => firstName; set => firstName = value; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [DisplayName("Фамилия")]
        public string LastName { get => lastName; set => lastName = value; }
        /// <summary>
        /// Отчество
        /// </summary>
        [DisplayName("Отчество")]
        public string MiddleName { get => middleName; set => middleName = value; }

        public List<Book> Books { get; set; } = new List<Book>();


    }
}
