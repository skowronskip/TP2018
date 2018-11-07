using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src
{
    public class Event
    {
        private Client user;
        private Book book;
        private String createdAt;

        public Event(Client user, Book book)
        {
            this.user = user;
            this.book = book;
            this.createdAt = DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy hh:mm:ss");
        }
    }

    public class BorrowBook : Event
    {
        public BorrowBook(Client user, Book book) : base(user, book)
        {
            book.SetClient(user);
            user.AddBook(book);
        }
    }

    public class ReturnBook : Event
    {
        public ReturnBook(Client user, Book book) : base(user, book)
        {
            book.SetClient(null);
            user.RemoveBook(book);
        }
    }
}
