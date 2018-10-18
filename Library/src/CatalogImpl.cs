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
            return dao.GetBooks().Select(book => book).Where(book => id == book.GetId()).ToArray()[0];
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

        public void AddBooks(params Book[] books)
        {
            foreach(Book book in books){
                dao.AddBook(book);
            }
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
