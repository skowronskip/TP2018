using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Catalog : ICatalog
    {
        private IBookDao dao;
        public Catalog(IBookDao dao)
        {
            this.dao = dao;
        }

        public Book GetBook(int id)
        {
            return null;
        }

        public List<Book> GetBooksByAuthor(String author)
        {
            return null;
        }

        public List<Book> GetBooksByTitle(String title)
        {
            return null;
        }

        public List<Book> GetBooksByState(bool available)
        {
            return null;
        }

        public List<Book> GetBooks()
        {
            return dao.GetBooks();
        }

        public void AddBook(Book book)
        {
            dao.AddBook(book);
        }

        public void RemoveBook(int id)
        {

        }

        public void BorrowBook(int id, Client client)
        {

        }

        public void ReturnBook(int id, Client client)
        {

        }
    }
}
