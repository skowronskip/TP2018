using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src
{
    public class Event
    {//todo think about ids
        private Client user;
        private Book book;
        private String createdAt;

        public Event(Client user)
        {
            this.user = user;
            this.createdAt = DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy hh:mm:ss");
        }
    }

    public class NewUser : Event
    {
        public NewUser(Client user) : base(user)
        {

        }
    }

    public class BorrowBook : Event
    {
        private Book book;
        public BorrowBook(Client user, Book book) : base(user)
        {
            this.book = book;
            book.SetClient(user);
            user.AddBook(book);
        }
    }

    public class ReturnBook : Event
    {
        private Book book;
        public ReturnBook(Client user, Book book) : base(user)
        {
            this.book = book;
            book.SetClient(null);
            user.RemoveBook(book);
        }
    }
}
