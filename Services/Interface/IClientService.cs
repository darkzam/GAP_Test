using GAP.Insurance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Services.Interface
{
    public interface IClientService
    {
        List<Client> GetClients();

        Client GetClientById(int id);

        Client AddClient(Client Client);

        void UpdateClient(Client Client);

        void DeleteClient(Client Client);

        bool ClientExists(int id);

        bool Save();
    }
}
