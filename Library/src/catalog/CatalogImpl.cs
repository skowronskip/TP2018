using System;

public class CatalogImpl : Catalog
{
    private BookDao dao;
	public CatalogImpl(BookDao dao)
	{
        this.dao = dao;
	}

    public Book getBook(int id)
    {

    }

    public List<Book> getBooksByAuthor(String author)
    {

    }

    public List<Book> getBooksByTitle(String title)
    {

    }

    public List<Book> getBooksByState(bool available)
    {

    }

    public List<Book> getBooks()
    {
        return dao.getBooks();
    }

    public void addBook(Book book)
    {
        dao.addBook(book);
    }

    public void removeBook(int id)
    {

    }

    public void borrowBook(int id, Client client)
    {

    }

    public void returnBook(int id, Client client)
    {

    }
}
