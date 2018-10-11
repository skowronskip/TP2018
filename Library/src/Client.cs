using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Client
    {
        private String firstName;
        private String lastName;
        private List<Book> books = new List<Book>();
       
        public Client(String firstName, String lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public String getName()
        {
            return this.firstName + ' ' + this.lastName;
        }

        public void addBook(Book newBook)
        {
            books.Add(newBook);
        }

        public int getAmountOfBooks()
        {
            return books.Count;
        }

        public List<Book> getAllBooks()
        {
            return books;
        }
    }
}
