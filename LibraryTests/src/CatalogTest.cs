using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class CatalogTest
    {
        private Catalog catalog;

        [TestInitialize()]
        public void setUp()
        {
            BookDao dao = new BookDaoBasicImpl();
            this.catalog = new CatalogImpl(dao);
        }

        [TestCleanup()]
        public void tearDown()
        {
            this.catalog = null;
        }
        [TestMethod()]
        public void happyPath()
        {
            //given
            Book book = new Book("Test title", "Test author", 1);
            //when
            catalog.addBook(book);
            //then
            Assert.AreEqual(catalog.getBooks()[0], book);
        }
    }
}
