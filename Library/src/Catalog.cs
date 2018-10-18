using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface Catalog
    {
         Book getBook(int id);
         List<Book> getBooksByAuthor(String author);
         List<Book> getBooksByTitle(String title);
         List<Book> getBooksByState(bool available);
         List<Book> getBooks();
         void addBook(Book book);
         void removeBook(int id);
         void borrowBook(int id, Client client);
         void returnBook(int id, Client client);
    }
}
