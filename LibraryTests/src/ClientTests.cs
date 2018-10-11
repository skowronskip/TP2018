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
    public class ClientTests
    {
        [TestMethod()]
        public void ClientTest()
        {
            //TODO Implement this test
            Assert.Fail();
        }

        [TestMethod()]
        public void getNameTest()
        {
            String firstName = "Test";
            String lastName = "Client";
            String name = firstName + " " + lastName;
            Client testClient = new  Client(firstName, lastName);
            Assert.AreEqual(testClient.getName(), name);
        }

        [TestMethod()]
        public void addBookTest()
        {
            String firstName = "Test";
            String lastName = "Client";
            Client testClient = new Client(firstName, lastName);
            Assert.AreEqual(testClient.getAmountOfBooks(), 0);
            testClient.addBook(new Book("Test Book 1", "Test Author", 1));
            testClient.addBook(new Book("Test Book 2", "Test Author", 2));
            testClient.addBook(new Book("Test Book 3", "Test Author", 3));
            Assert.AreEqual(testClient.getAmountOfBooks(), 3);
        }
        
        [TestMethod()]
        public void getAllBooksTest()
        {
            //TODO Implement this test
            Assert.Fail();
        }
    }
}