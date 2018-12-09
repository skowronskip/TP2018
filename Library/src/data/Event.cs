using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src
{
    public class Event
    {
        public Client Client { get; set; }
        public Book Book { get; set; }
        public String CreatedAt { get; set; }
        public String Type { get; set; }

        public Event(Client client)
        {
            this.Client = client;
            this.CreatedAt = DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy hh:mm:ss");
        }
    }

    public class NewUser : Event
    {
        public NewUser(Client client) : base(client)
        {
            this.Type = "NewUser";
        }
    }

    public class BorrowBook : Event
    {
        private Book book;
        public BorrowBook(Client client, Book book) : base(client)
        {
            this.Book = book;
            Book.SetClient(client);
            client.AddBook(book);
            this.Type = "BorrowBook";
        }
    }

    public class ReturnBook : Event
    {
        private Book book;
        public ReturnBook(Client client, Book book) : base(client)
        {
            this.Book = book;
            Book.SetClient(null);
            client.RemoveBook(Book);
            this.Type = "ReturnBook";
        }
    }
}
