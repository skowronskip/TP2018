using System;

public interface BookDao
{
    public List<Book> getBooks();
    public List<Book> getBooks(String query);
    public void addBook(Book book);
    public void removeBook(int id);
}
