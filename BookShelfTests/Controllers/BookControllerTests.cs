using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookShelf.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using BookShelf.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShelf.Controllers.Tests
{
    [TestClass()]
    public class BookControllerTests
    {
        DbContextOptions<BookContext> options;
        public BookControllerTests()
        {
            options = new DbContextOptionsBuilder<BookContext>()
           .UseInMemoryDatabase(databaseName: "test")
           .Options;
        }

        [Fact]
        public void IndexTest()
        {
            // Use a clean instance of the context to run the test
            using (var context = new BookContext(options))
            {
                var controller = new BookController(null, context);
                List<Book> books = context.Books.ToList();

                Xunit.Assert.Equal(4, books.Count);

            }
        }

        [Fact]
        public void CreateBookTest()
        {
            using (var context = new BookContext(options))
            {
                ///Arrange
                var controller = new BookController(null, context);
                
                Book book = new Book()
                {
                    Id = Guid.NewGuid(),
                    Name = "Тест",
                    Author = "Тест",
                    Given = false,
                    DatePublished = DateTime.ParseExact("01/01/1866", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)
                };
                //Act
                var tag = controller.CreateBook(book);
                var result = context.Books.ToList();
                //Assert
                Xunit.Assert.Equal(5, result.Count);

            }
        }
    }
}

    
