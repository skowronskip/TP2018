using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BookDaoBasicImpl : BookDao
    {
        private List<Book> books = new List<Book>();

        public List<Book> getBooks()
        {
            return books;
        }

        public List<Book> getBooks(String query)
        {
            throw new NotSupportedException();
        }

        public void addBook(Book book)
        {
            books.Add(book);
        }

        public void removeBook(int id)
        {
            foreach (Book book in books)
            {
                if (book.getId() == id)
                {
                    books.Remove(book);
                    return;
                }
            }
        }
    }
}
