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


        [Fact]
        public void IndexTest()
        {
            var options = new DbContextOptionsBuilder<BookContext>()
           .UseInMemoryDatabase(databaseName: "test")
           .Options;

            // Use a clean instance of the context to run the test
            using (var context = new BookContext(options))
            {
                var controller = new BookController(null, context);
                List<Book> books = context.Books.ToList();

                Xunit.Assert.Equal(4, books.Count);

            }
        }
    }
}

    
