using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src
{
    interface BookDao
    {
        List<Book> getBooks();
        List<Book> getBooks(String query);
        void addBook(Book book);
        void removeBook(int id);
    }
}
