using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src
{
    public class Library
    {
        private ICatalog catalog;
        private ProcessState processState;
        private IUsers users;
        private IEvents events;

        public Library(IBookDao dao)
        {
            this.catalog = new Catalog(dao);
            this.processState = new ProcessState(dao);
            this.users = new Users();
            this.events = new Events();
        }

        public void AddClient(String firstName, String lastName)
        {
            int i = 0;
            while(users.GetClientById(i) != null)
            {
                i++;
            }
            Client newClient = new Client(firstName, lastName, i);
            users.AddClient(newClient);
            events.RegisterEvent(new NewUser(newClient));
        }

        public void AddBook(String title, String author)
        {
            int i = 0;
            while(catalog.GetBook(i) != null)
            {
                i++;
            }
            catalog.AddBooks(new Book(title, author, i));
        }

        public void PrintAllBooksWithStates()
        {
            List<Book> allBooks = catalog.GetBooks();
            foreach (Book book in allBooks) {
                bool isAvailable = book.GetClient() == null;
                Console.WriteLine("ID: " + book.GetId() + "| Title:" + book.GetTitle() + "| Author: " + book.GetAuthor() + "| isAvailable: " + isAvailable);
            }
        }

        public void PrintAllUsers()
        {
            List<Client> allUsers = users.GetAllUsers();
            foreach (Client client in allUsers)
            {
                Console.WriteLine("ID: " + client.GetId() + "| First name: " + client.GetFirstName() + "| Last name: " + client.GetLastName() + "| Borrowed books: " + client.GetAmountOfBooks());
            }
        }

        public void PrintAllBooksOfChoosenUser(int id)
        {
            Client client = users.GetClientById(id);
            List<Book> allBooks = client.GetAllBooks();
            if (allBooks != null)
            {
                foreach (Book book in allBooks)
                {
                    Console.WriteLine("ID: " + book.GetId() + "| Title:" + book.GetTitle() + "| Author: " + book.GetAuthor());
                }
            }
            else
            {
                Console.WriteLine("User has 0 books");
            }
        }

        public void BorrowBook(int clientId, int bookId)
        {
            Book book = catalog.GetBook(bookId);
            Client client = users.GetClientById(clientId);
            if(book != null)
            {
                if(client != null)
                {
                    if (book.GetClient() != null)
                    {
                        Console.WriteLine("Book is not available");
                        return;
                    }
                    else
                    {
                        events.RegisterEvent(new BorrowBook(client, book));
                    }
                }
                else
                {
                    Console.WriteLine("Client not found");
                }
            }     
            else
            {
                Console.WriteLine("Book not found");
            }
        }

        public void ReturnBook(int clientId, int bookId)
        {
            Book book = catalog.GetBook(bookId);
            Client client = users.GetClientById(clientId);
            if (book != null)
            {
                if (client != null)
                {
                    if (book.GetClient() != client)
                    {
                        Console.WriteLine("Book is not borrowed by this client");
                        return;
                    }
                    else
                    {
                        events.RegisterEvent(new ReturnBook(client, book));
                    }
                }
                else
                {
                    Console.WriteLine("Client not found");
                }
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }
    }
}
