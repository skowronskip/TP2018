using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface IBookDao
    {
        List<Book> GetBooks();
        List<Book> GetBooks(String query);
        void AddBook(Book book);
        void RemoveBook(int id);
    }
}
