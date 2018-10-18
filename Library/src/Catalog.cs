using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface ICatalog
    {
         Book GetBook(int id);
         List<Book> GetBooksByAuthor(String author);
         List<Book> GetBooksByTitle(String title);
         List<Book> GetBooksByState(bool isAvailable);
         List<Book> GetBooks();
         void AddBooks(params Book[] books);
         void RemoveBook(int id);
         void BorrowBook(int id, Client client);
         void ReturnBook(int id, Client client);
    }
}
