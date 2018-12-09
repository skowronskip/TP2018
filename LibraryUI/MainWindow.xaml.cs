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
            InitializeComponent();
            BooksLw.ItemsSource = LoadBooks(library);
        }

        private void ListOfClients_Click(object sender, RoutedEventArgs e)
        {
            MainMenuPanel.Visibility = Collapsed;
        }
        
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
    }
}
