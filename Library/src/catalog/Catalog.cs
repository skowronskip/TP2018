using System;

public interface Catalog
{
    public Book getBook(int id);
    public List<Book> getBooksByAuthor(String author);
    public List<Book> getBooksByTitle(String title);
    public List<Book> getBooksByState(bool available);
    public List<Book> getBooks();
    public void addBook(Book book);
    public void removeBook(int id);
    public void borrowBook(int id, Client client);
    public void returnBook(int id, Client client);
}
