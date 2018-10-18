using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;

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
        public void shouldGetBookById()
        {
            //given
            Book book1 = new Book("Title", "Test", 1);
            Book book2 = new Book("Eltit", "Tset", 2);
            Book book3 = new Book("Tit", "Le", 3);
            catalog.AddBooks(book1, book2, book3);
            //then
            Assert.AreEqual(catalog.GetBook(book2.GetId()), book2);
        }

    }
}
