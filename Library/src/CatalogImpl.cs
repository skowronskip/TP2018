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
            return dao.GetBooks().Select(b=>b).Where(b=> b.GetAuthor().Equals(author)).ToList();
        }

        public List<Book> GetBooksByTitle(String title)
        {
            return dao.GetBooks().Select(b => b).Where(b => b.GetTitle().Equals(title)).ToList();
        }

        public List<Book> GetBooksByState(bool isAvailable)
        {
            return dao.GetBooks().Select(b => b).Where(b => (b.GetClient() == null) == isAvailable).ToList();
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
            dao.RemoveBook(id);
        }

        public void BorrowBook(int id, Client client)
        {
            this.GetBook(id).SetClient(client);
        }

        public void ReturnBook(int id, Client client)
        {
            if (client.Equals(GetBook(id).GetClient()))
            {
                this.GetBook(id).SetClient(null);
            }
        }
    }
}
