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

        public List<Book> GetBooks()
        {
            return catalog.GetBooks();
        }
        public Book GetBook(int id)
        {
            return catalog.GetBook(id);
        }
        public List<Book> GetBooksByAuthor(String author)
        {
            return catalog.GetBooksByAuthor(author);
        }
        public List<Book> GetBooksByTitle(String title)
        {
            return catalog.GetBooksByTitle(title);
        }
        public List<Book> GetBooksByState(bool isAvailable)
        {
            return catalog.GetBooksByState(isAvailable);
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
        public void RemoveBook(int id)
        {
            catalog.RemoveBook(id);
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


        public List<Client> GetClients()
        {
            return users.GetAllClients();
        }
        public Client GetClientById(int id)
        {
            return users.GetClientById(id);
        }
        public Client GetClientByFirstName(String firstName)
        {
            return users.GetClientByFirstName(firstName);
        }
        public Client GetClientByLastName(String lastName)
        {
            return users.GetClientByLastName(lastName);
        }
        public void AddClient(String firstName, String lastName)
        {
            int i = 0;
            while (users.GetClientById(i) != null)
            {
                i++;
            }
            Client newClient = new Client(firstName, lastName, i);
            users.AddClient(newClient);
            events.RegisterEvent(new NewUser(newClient));
        }
        public bool RemoveClient(int id)
        {
            return users.RemoveClient(id);
        }
        public bool UpdateClient(Client client)
        {
            return users.UpdateClient(client);
        }


        public List<Event> GetEvents()
        {
            return events.listEvents();
        }


        public List<Book> GetCurrentLibraryState()
        {
            return processState.GetCurrentLibraryState();
        }
    }
}
