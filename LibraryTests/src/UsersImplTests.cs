using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src.Tests
{
    [TestClass()]
    public class UsersTests
    {
        private Users usersList;
        [TestInitialize()]
        public void SetUp()
        {
            this.usersList = new Users();
        }
        [TestCleanup()]
        public void TearDown()
        {
            this.usersList = null;
        }

        [TestMethod()]
        public void ShouldAddClient()
        {
            //given
            Client client = new Client("John", "Bush", 1);
            //when
            usersList.AddClient(client);
            //them
            Assert.AreEqual(usersList.GetAllClients()[0], client);

        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            //given
            Client client1 = new Client("John", "Bush", 1);
            Client client2 = new Client("Andrew", "Bush", 2);
            Client client3 = new Client("Peter", "Bush", 3);
            //when
            usersList.AddClients(client1, client2, client3);
            //then
            List<Client> allUsers = usersList.GetAllClients();
            Assert.IsTrue(allUsers.Count == 3);
            Assert.IsTrue(allUsers.Contains(client1));
            Assert.IsTrue(allUsers.Contains(client2));
            Assert.IsTrue(allUsers.Contains(client3));
        }

        [TestMethod()]
        public void GetClientByFirstNameTest()
        {
            //given
            Client client1 = new Client("John", "Bush", 1);
            Client client2 = new Client("Andrew", "Bush", 2);
            Client client3 = new Client("Peter", "Bush", 3);
            usersList.AddClients(client1, client2, client3);
            //when
            Client testClient = usersList.GetClientByFirstName(client2.GetFirstName());
            //then
            Assert.AreEqual(testClient, client2);
        }

        [TestMethod()]
        public void GetClientByIdTest()
        {
            //given
            Client client1 = new Client("John", "Bush", 1);
            Client client2 = new Client("Andrew", "Bush", 2);
            Client client3 = new Client("Peter", "Bush", 3);
            usersList.AddClients(client1, client2, client3);
            //when
            Client testClient = usersList.GetClientById(client1.GetId());
            //then
            Assert.AreEqual(testClient, client1);
        }

        [TestMethod()]
        public void GetClientByLastNameTest()
        {
            //given
            Client client1 = new Client("John", "Bush", 1);
            Client client2 = new Client("Andrew", "Forest", 2);
            Client client3 = new Client("Peter", "Tree", 3);
            usersList.AddClients(client1, client2, client3);
            //when
            Client testClient = usersList.GetClientByLastName(client3.GetLastName());
            //then
            Assert.AreEqual(testClient, client3);
        }

        [TestMethod()]
        public void RemoveClientTest()
        {
            //given
            Client client1 = new Client("John", "Bush", 1);
            Client client2 = new Client("Andrew", "Bush", 2);
            Client client3 = new Client("Peter", "Bush", 3);
            usersList.AddClients(client1, client2, client3);
            //when
            usersList.RemoveClient(2);
            //then
            List<Client> allUsers = usersList.GetAllClients();
            Assert.IsTrue(allUsers.Count == 2);
            Assert.IsTrue(allUsers.Contains(client1));
            Assert.IsFalse(allUsers.Contains(client2));
            Assert.IsTrue(allUsers.Contains(client3));
        }

        [TestMethod()]
        public void UpdateClientTest()
        {
            //given
            Client client1 = new Client("John", "Bush", 1);
            Client client2 = new Client("Andrew", "Bush", 2);
            Client client3 = new Client("Peter", "Bush", 3);
            usersList.AddClients(client1, client2, client3);
            //when
            Client updatedClient = usersList.GetClientById(2);
            updatedClient.setFirstName("Paul");
            usersList.UpdateClient(updatedClient);
            //then
            Assert.AreEqual(usersList.GetClientById(2), updatedClient);
        }
    }
}