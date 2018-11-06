using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System.Collections.Generic;

namespace LibraryTests
{
    [TestClass]
    public class CatalogTest
    {
        private ICatalog catalog;

        [TestInitialize()]
        public void SetUp()
        {
            IBookDao dao = new SimpleBookDao();
            this.catalog = new Catalog(dao);
        }

        [TestCleanup()]
        public void TearDown()
        {
            this.catalog = null;
        }
        [TestMethod()]
        public void HappyPath()
        {
            //given
            Book book = new Book("Test title", "Test author", 1);
            //when
            catalog.AddBooks(book);
            //then
            Assert.AreEqual(catalog.GetBooks()[0], book);
        }

        [TestMethod()]
        public void ShouldGetBookById()
        {
            //given
            Book book1 = new Book("Title", "Tset", 1);
            Book book2 = new Book("Eltit", "Tset", 2);
            Book book3 = new Book("Title", "Le", 3);
            catalog.AddBooks(book1, book2, book3);
            //then
            Assert.AreEqual(catalog.GetBook(book2.GetId()), book2);
        }

        [TestMethod()]
        public void ShouldGetBookByAuthor()
        {
            //given
            Book book1 = new Book("Title", "Tset", 1);
            Book book2 = new Book("Eltit", "Tset", 2);
            Book book3 = new Book("Title", "Le", 3);
            catalog.AddBooks(book1, book2, book3);
            //when
            List<Book> result = catalog.GetBooksByAuthor(book1.GetAuthor());
            //then
            Assert.IsTrue(result.Count == 2);     
            Assert.IsTrue(result.Contains(book1));
            Assert.IsTrue(result.Contains(book2));
        }

        [TestMethod()]
        public void ShouldGetBookByTitle()
        {
            //given
            Book book1 = new Book("Title", "Test", 1);
            Book book2 = new Book("Eltit", "Tset", 2);
            Book book3 = new Book("Title", "Le", 3);
            catalog.AddBooks(book1, book2, book3);
            //when
            List<Book> result = catalog.GetBooksByTitle(book1.GetTitle());
            //then
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(book1));
            Assert.IsTrue(result.Contains(book3));
        }

        [TestMethod()]
        public void ShouldBorrowBook()
        {
            //given
            Book book1 = new Book("Title", "Test", 1);
            Client client = new Client("George", "Bush", 1);
            catalog.AddBooks(book1);
            //when
            catalog.BorrowBook(book1.GetId(), client);
            //then
            Assert.AreEqual(catalog.GetBook(book1.GetId()).GetClient(), client);
        }

        [TestMethod()]
        public void ShouldReturnBook()
        {
            //given
            Book book1 = new Book("Title", "Test", 1);
            Client client = new Client("George", "Bush", 1);
            catalog.AddBooks(book1);
            catalog.BorrowBook(book1.GetId(), client);
            //when
            catalog.ReturnBook(book1.GetId(), client);
            //then
            Assert.AreEqual(catalog.GetBook(book1.GetId()).GetClient(), null);
        }

        [TestMethod()]
        public void ShouldGetBookByState()
        {
            //given
            Book book1 = new Book("Title", "Test", 1);
            Book book2 = new Book("Eltit", "Tset", 2);
            Book book3 = new Book("Title", "Le", 3);
            Client client = new Client("George", "Bush", 1);
            catalog.AddBooks(book1, book2, book3);
            catalog.BorrowBook(book1.GetId(), client);
            //when
            List<Book> available = catalog.GetBooksByState(true);
            List<Book> taken = catalog.GetBooksByState(false);
            //then
            Assert.IsTrue(available.Count == 2);
            Assert.IsTrue(available.Contains(book2));
            Assert.IsTrue(available.Contains(book3));
            Assert.IsTrue(taken.Count == 1);
            Assert.IsTrue(taken.Contains(book1));
        }

        [TestMethod()]
        public void ShouldRemoveBook()
        {
            //given
            Book book1 = new Book("Title", "Test", 1);
            Book book2 = new Book("Eltit", "Tset", 2);
            Book book3 = new Book("Title", "Le", 3);
            catalog.AddBooks(book1, book2, book3);
            //when
            catalog.RemoveBook(book2.GetId());
            //then
            List<Book> result = catalog.GetBooks();
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(book1));
            Assert.IsTrue(result.Contains(book3));
        }

    }
}
