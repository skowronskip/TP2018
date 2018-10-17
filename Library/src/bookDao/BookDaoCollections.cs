using System;

public class BookDaoCollection : BookDao
{
    private List<Book> books = new Array<Book>();

    public List<Book> getBooks()
    {
        return books;
    }

    public List<Book> getBooks(String query)
    {
        throw new UnsupportedOperationException();
    }

    public void addBook(Book book)
    {
        books.add(book);
    }

    public void removeBook(int id)
    {
        foreach(Book book in books)
        {
            if(book.getId() == id)
            {
                books.remove(book);
                return;
            }
        }
    }
}
