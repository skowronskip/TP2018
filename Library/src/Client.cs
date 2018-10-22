using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Client
    {
        private int id;
        private String firstName;
        private String lastName;
        private List<Book> books = new List<Book>();

        public Client(String firstName, String lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int GetId()
        {
            return this.id;
        }

        public String GetName()
        {
            return this.firstName + ' ' + this.lastName;
        }

        public String GetFirstName()
        {
            return this.firstName;
        }

        public String GetLastName()
        {
            return  this.lastName;
        }

        public void AddBook(Book newBook)
        {
            books.Add(newBook);
        }

        public int GetAmountOfBooks()
        {
            return books.Count;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }
    }
}
