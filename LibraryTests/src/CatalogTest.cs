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
            catalog.AddBook(book);
            //then
            Assert.AreEqual(catalog.GetBooks()[0], book);
        }
    }
}
