using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System.Collections.Generic;

namespace LibraryTests
{
    [TestClass]
    public class ProcessStateTest
    {
        private ProcessState processState;
        private IBookDao dao;

        [TestInitialize()]
        public void SetUp()
        {
            this.dao = new SimpleBookDao();
            this.processState = new ProcessState(dao);
        }

        [TestCleanup()]
        public void TearDown()
        {
            this.processState = null;
            this.dao = null;
        }

        [TestMethod()]
        public void ShouldGetProcessState()
        {
            //given
            Book book1 = new Book("Title", "Test", 1);
            Book book2 = new Book("Eltit", "Tset", 2);
            Book book3 = new Book("Title", "Le", 3);
            dao.AddBook(book1);
            dao.AddBook(book2);
            dao.AddBook(book3);
            //when
            List<Book> result = processState.GetCurrentLibraryState();
            //then
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result.Contains(book1));
            Assert.IsTrue(result.Contains(book2));
            Assert.IsTrue(result.Contains(book3));
        }

    }
}
