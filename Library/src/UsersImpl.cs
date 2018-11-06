using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src
{
    public class Users : IUsers
    {
        List<Client> clientList = new List<Client>();

        public void AddClient(Client client)
        {
            clientList.Add(client);
        }

        public void AddClients(params Client[] clients)
        {
            foreach (Client client in clients)
            {
                clientList.Add(client);
            }
        }

        public List<Client> GetAllUsers()
        {
            return clientList;
        }

        public Client GetClientByFirstName(string firstName)
        {
            foreach (Client client in clientList)
            {
                if (client.GetFirstName() == firstName) return client;
            }
            return null;
        }

        public Client GetClientById(int id)
        {
            foreach (Client client in clientList)
            {
                if (client.GetId() == id) return client;
            }
            return null;
        }

        public Client GetClientByLastName(string lastName)
        {
            foreach (Client client in clientList)
            {
                if (client.GetLastName() == lastName) return client;
            }
            return null;
        }

        public bool RemoveClient(int id)
        {
            Client clientToRemove = clientList.Single(client => client.GetId() == id);
            if (clientToRemove != null)
            {
                clientList.Remove(clientToRemove);
                return true;
            }
            return false;
            
        }

        public bool UpdateClient(Client updatedClient)
        {
            Client clientToUpdate = clientList.Single(client => client.GetId() == updatedClient.GetId());
            if(clientToUpdate != null)
            {
                clientToUpdate.Update(updatedClient);
                return true;
            }
            return false;
        }
    }
}
