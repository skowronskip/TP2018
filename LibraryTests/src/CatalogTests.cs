using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    [TestClass()]
    public class CatalogTests
    {
        private Catalog catalog;

        [TestInitialize()]
        public void setUp()
        {
            BookDao dao = new BookDaoCollections();
            this.catalog = new CatalogImpl(dao);
        }

        [TestCleanup()]
        public void tearDown()
        {
            this.catalog = null;
        }

        [TestMethod()]
        public void happyPath() {
            //given
            Book book = new Book("Test title", "Test author", 1);
            //when
            catalog.addBook(book);
            //then
            Assert.AreEqual(catalog.getBooks().get(0), book);
        }
    }
}