using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.src;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src.Tests
{
    [TestClass()]
    public class EventsTests
    {
        private Events eventsList;
        [TestInitialize()]
        public void SetUp()
        {
            this.eventsList = new Events();
        }
        [TestCleanup()]
        public void TearDown()
        {
            this.eventsList = null;
        }
        [TestMethod()]
        public void ListEventsTest()
        {
            //given
            Book newBook1 = new Book("Tested Borrowed Book", "Developer", 1);
            Book newBook2 = new Book("Tested Next Book", "Developer", 2);
            Client newClient = new Client("Paul", "Bush", 1);
            //when
            eventsList.RegisterEvent(new BorrowBook(newClient, newBook1));
            eventsList.RegisterEvent(new BorrowBook(newClient, newBook2));
            eventsList.RegisterEvent(new ReturnBook(newClient, newBook2));
            //then
            Assert.AreEqual(newBook1.GetClient(), newClient);
            Assert.AreEqual(newBook2.GetClient(), null);
            Assert.IsTrue(newClient.GetAllBooks().Count == 1);
            Assert.IsTrue(eventsList.listEvents().Count == 3);

        }
    }
}