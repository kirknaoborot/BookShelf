using System;
using BookShelf.Models;

namespace BookShelf.Interfaces
{
    public interface IVisitorRepository
    {
        public void AddReader(Reader reader);
        public void DeleteReader(Reader reader);
        public Reader GetReader(Guid Id);
        public void Save();
    }
}
