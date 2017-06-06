using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Interfaces;
using Model;

namespace DAL.Repository
{
  public  class ClientRepository:IRepository<Client>
  {
      private readonly DataModelContainer _context;

      public ClientRepository(DataModelContainer context)
      {
          _context = context;
      }
      public void Add(Client client)
      {
          _context.Clients.Add(client);
      }

      public void Delete(int id)
      {
          Client client = _context.Clients.Find(id);
          if (client != null)
          {
              _context.Clients.Remove(client);
          }
      }
      public IEnumerable<Client> GetAll()
      {
          return _context.Clients;
      }

      public IEnumerable<Client> Find(Func<Client, bool> predicate)
      {
          return _context.Clients.Where((predicate)).ToList();
      }

      public Client GetById(int id)
      {
          return _context.Clients.Find(id);
      }
      public void Update(Client client)
      {
          _context.Entry(client).State=EntityState.Modified;
      }
    }
}
