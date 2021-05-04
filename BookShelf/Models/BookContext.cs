using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.Models
{
    public class BookContext :DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) :base(options)
        {
            Database.EnsureCreated();
        }

       public DbSet<Book> Books { get; set; }
       public DbSet<Reader> Readers { get; set; }

       public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

                
        }

    }
}
