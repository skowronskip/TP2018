using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Visibility;
using Library;
using Library.src;

namespace LibraryUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LibraryClass library;
        public MainWindow()
        {
            SimpleBookDao bookDao = new SimpleBookDao();
            bookDao.AddBook(new Book("Book 1", "Author 1", 0));
            bookDao.AddBook(new Book("Book 2", "Author 2", 1));
            bookDao.AddBook(new Book("Book 3", "Author 3", 2));
            bookDao.AddBook(new Book("Book 4", "Author 4", 3));
            bookDao.AddBook(new Book("Book 5", "Author 5", 4));
            library = new LibraryClass(bookDao);
            library.AddClient("Cli", "Ent");
            library.AddClient("Tne", "Ilc");
            library.BorrowBook(1, 1); //todo debug - KILL ME PLEASE
            InitializeComponent();
            BooksLw.ItemsSource = LoadBooks(library);
            ClientsLw.ItemsSource = LoadClients(library);
            EventsLw.ItemsSource = LoadEvents(library);
        }
        
        public void Return_Click(object sender, RoutedEventArgs e)
        {
            ClientsPanel.Visibility = Collapsed;
            BooksPanel.Visibility = Collapsed;
            EventsPanel.Visibility = Collapsed;
            MainMenuPanel.Visibility = Visible;
        }

        // Books
        private void ListOfBooks_Click(object sender, RoutedEventArgs e)
        {
            MainMenuPanel.Visibility = Collapsed;
            BooksPanel.Visibility = Visible;
        }
        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            NewBookPanel.Visibility = Visible;
        }
        private void NewBook_ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string author = NewBook_AuthorBox.Text;
            string title = NewBook_TitleBox.Text;
            if(author == null || title == null)
            {
                MessageBox.Show("Both fields are required");
            }
            else
            {
                library.AddBook(title, author);
            }
            BooksLw.ItemsSource = LoadBooks(library);
            NewBookPanel.Visibility = Collapsed;
        }
        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            ListBook selectedBook = BooksLw.SelectedItem as ListBook;
            if (selectedBook != null)
            {
                library.RemoveBook(selectedBook.ID);
                BooksLw.ItemsSource = LoadBooks(library);
            }
            else
            {
                MessageBox.Show("Book is not choosen");
            }
        }
        public class ListBook
        {
            public int ID { get; set; }

            public string Title { get; set; }

            public string Author { get; set; }
        }
        public List<ListBook> LoadBooks(LibraryClass library)
        {
            List < ListBook > result = new List<ListBook>();
            foreach (Book book in library.GetBooks()) {
                result.Add(new ListBook()
                {
                    ID = book.GetId(),
                    Title = book.GetTitle(),
                    Author = book.GetAuthor()
                });
            }
            return result;
        }

        // Clients
        private void ListOfClients_Click(object sender, RoutedEventArgs e)
        {
            MainMenuPanel.Visibility = Collapsed;
            ClientsPanel.Visibility = Visible;
        }
        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            NewClientPanel.Visibility = Visible;
        }
        private void NewClient_ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = NewClient_FirstNameBox.Text;
            string LastName = NewClient_LastNameBox.Text;
            if (FirstName == null || LastName == null)
            {
                MessageBox.Show("Both fields are required");
            }
            else
            {
                library.AddClient(FirstName, LastName);
            }
            ClientsLw.ItemsSource = LoadClients(library);
            NewClientPanel.Visibility = Collapsed;
        }
        private void DeleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            ListClient selected = ClientsLw.SelectedItem as ListClient;
            if (selected != null)
            {
                library.RemoveClient(selected.ID);
                ClientsLw.ItemsSource = LoadClients(library);
            }
            else
            {
                MessageBox.Show("Client is not choosen");
            }

        }
        public class ListClient
        {
            public int ID { get; set; }
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public String Books { get; set; }
        }
        public List<ListClient> LoadClients(LibraryClass library)
        {
            List<ListClient> res = new List<ListClient>();
            foreach (Client client in library.GetClients())
            {
                res.Add(new ListClient()
                {
                    ID = client.GetId(),
                    FirstName = client.GetFirstName(),
                    LastName = client.GetLastName(),
                    Books = string.Join(",", client.GetAllBooks().Select(x => x.GetTitle()))
                });
            }
            return res;
        }

        // Events
        private void ListOfEvents_Click(object sender, RoutedEventArgs e)
        {
            MainMenuPanel.Visibility = Collapsed;
            EventsLw.ItemsSource = LoadEvents(library);
            EventsPanel.Visibility = Visible;
        }

        public class ListEvent
        {
            public String Type { get; set; }
            public String CreatedAt { get; set; }
            public String ClientFirstName { get; set; }
            public String ClientLastName { get; set; }
            public String Title { get; set; }
            public String Author { get; set; }
        }
        public List<ListEvent> LoadEvents(LibraryClass library)
        {
            List<ListEvent> res = new List<ListEvent>();
            foreach (Event e in library.GetEvents())
            {
                res.Add(new ListEvent()
                {
                    Type = e.Type,
                    CreatedAt = e.CreatedAt,
                    ClientFirstName = e.Client.GetFirstName(),
                    ClientLastName = e.Client.GetLastName(),
                    Title = e.Book == null ? "n/a" : e.Book.GetTitle(),
                    Author = e.Book == null ? "n/a" : e.Book.GetAuthor()
                });
            }
            return res;
        }
    }
}
