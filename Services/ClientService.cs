using GAP.Insurance.Context;
using GAP.Insurance.Entities;
using GAP.Insurance.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Services
{
    public class ClientService : IClientService
    {
        private readonly InsuranceContext _insuranceContext;

        public ClientService(InsuranceContext insuranceContext)
        {
            _insuranceContext = insuranceContext;
        }

        public Client AddClient(Client client)
        {
            var newClient = _insuranceContext.Clients.Add(client);

            return newClient.Entity;
        }

        public Client GetClientById(int id)
        {
            return _insuranceContext.Clients.FirstOrDefault(r => r.Id == id);
        }

        public List<Client> GetClients()
        {
            return _insuranceContext.Clients.ToList<Client>();
        }

        public void DeleteClient(Client client)
        {
            _insuranceContext.Clients.Remove(client);
        }

        public void UpdateClient(Client client)
        {
            _insuranceContext.Clients.Update(client);
        }

        public bool ClientExists(int id)
        {
            return _insuranceContext.Clients.Any(r => r.Id == id);
        }

        public bool Save()
        {
            return (_insuranceContext.SaveChanges() >= 0);
        }
    }
}
