using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src
{
    public interface IUsers
    {
        Client GetClientById(int id);
        Client GetClientByFirstName(String firstName);
        Client GetClientByLastName(String lastName);
        List<Client> GetAllClients();
        void AddClient(Client client);
        void AddClients(params Client[] clients);
        bool RemoveClient(int id);
        bool UpdateClient(Client client);
    }
}
