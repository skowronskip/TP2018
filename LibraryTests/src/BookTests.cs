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
    public class BookTests
    {
        [TestMethod()]
        public void BookTest() {
            Book testBook = new Book("Test title", "Test author", 1);
        }

        [TestMethod()]
        public void getTitleTest()
        {
            Book testBook = new Book("Test title", "Test author", 1);
            Assert.AreEqual(testBook.getTitle(), "Test title");
        }

        [TestMethod()]
        public void getAuthorTest()
        {
            Book testBook = new Book("Test title", "Test author", 1);
            Assert.AreEqual(testBook.getAuthor(), "Test author");
        }
    }
}