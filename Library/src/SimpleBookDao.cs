using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SimpleBookDao : IBookDao
    {
        private List<Book> books = new List<Book>();

        public List<Book> GetBooks()
        {
            return books;
        }

        public List<Book> GetBooks(String query)
        {
            throw new NotSupportedException();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(int id)
        {
            foreach (Book book in books)
            {
                if (book.GetId() == id)
                {
                    books.Remove(book);
                    return;
                }
            }
        }
    }
}
