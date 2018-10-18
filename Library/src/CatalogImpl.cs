using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src
{
    class CatalogImpl : Catalog
    {
        private BookDao dao;
        public CatalogImpl(BookDao dao)
        {
            this.dao = dao;
        }

        public Book getBook(int id)
        {
            return null;
        }

        public List<Book> getBooksByAuthor(String author)
        {
            return null;
        }

        public List<Book> getBooksByTitle(String title)
        {
            return null;
        }

        public List<Book> getBooksByState(bool available)
        {
            return null;
        }

        public List<Book> getBooks()
        {
            return dao.getBooks();
        }

        public void addBook(Book book)
        {
            dao.addBook(book);
        }

        public void removeBook(int id)
        {

        }

        public void borrowBook(int id, Client client)
        {

        }

        public void returnBook(int id, Client client)
        {

        }
    }
}
