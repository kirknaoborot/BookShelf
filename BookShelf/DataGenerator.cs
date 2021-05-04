using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShelf.Models;

namespace BookShelf
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookContext(
                serviceProvider.GetRequiredService<DbContextOptions<Models.BookContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Name = "Война и Мир",
                        Author = "Л.Н Толстой",
                        Given = false,
                        DatePublished = DateTime.ParseExact("01/01/1865", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)
            },
                   new Book
                   {
                       Id = Guid.NewGuid(),
                       Name = "Преступление и наказание",
                       Author = "Ф.М.Достоевский",
                       Given = false,
                       DatePublished = DateTime.ParseExact("01/01/1866", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)
                   },
                   new Book
                   {
                       Id = Guid.NewGuid(),
                       Name = "Евгений Онегин",
                       Author = "А.С Пушкин",
                       Given = false,
                       DatePublished = DateTime.ParseExact("01/01/1831", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)
                   },

                   new Book
                   {
                       Id = Guid.NewGuid(),
                       Name = "Мастер и маргарита",
                       Author = "М.А.Булгаков",
                       Given = false,
                       DatePublished = DateTime.ParseExact("01/01/1937", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)
                   });
                context.Readers.AddRange(
                   new Reader
                   {
                       Id = Guid.NewGuid(),
                       FirstName = "Иван",
                       LastName = "Иванов",
                       MiddleName = "Иванович",
                       Books = new List<Book>()
                   },
                   new Reader
                   {
                       Id = Guid.NewGuid(),
                       FirstName = "Петр",
                       LastName = "Петров",
                       MiddleName = "Петрович",
                       Books = new List<Book>()
                   },
                   new Reader
                   {
                       Id = Guid.NewGuid(),
                       FirstName = "Леонид",
                       LastName = "Гусев",
                       MiddleName = "Семенович",
                       Books = new List<Book>()
                   },
                   new Reader
                   {
                       Id = Guid.NewGuid(),
                       FirstName = "Сергей",
                       LastName = "Лебединский",
                       MiddleName = "Александрович",
                       Books = new List<Book>()
                   },
                   new Reader
                   {
                       Id = Guid.NewGuid(),
                       FirstName = "Артем",
                       LastName = "Кольцов",
                       MiddleName = "Михайлович",
                       Books = new List<Book>()
                   });


                context.SaveChanges();
            }
        }
    }
}
