using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Interfaces;
using Model;
using Client = DAL.Models.Client;

namespace DAL.Repository
{
  public  class ClientRepository:IRepository<Models.Client>
  {
      private readonly DataModelContainer _context;

      public ClientRepository(DataModelContainer context)
      {
          _context = context;
      }
      private Model.Client ObjectToEntity(Models.Client client)
      {
          return new Model.Client
          {
              FullName = client.FullName
          };
      }

      private Models.Client EntityToObject(Model.Client client)
      {
          return new Client
          {
              FullName = client.FullName
          };
      }
      public void Create(Client client)
      {
          _context.Clients.Add(ObjectToEntity(client));
      }

      public int? GetId(Client client)
      {
          var tmp = _context.Clients.FirstOrDefault(c => (c.FullName == client.FullName));
          if (tmp == null)
          {
              return null;
          }
          return tmp.Id;
      }

      public IEnumerable<Client> GetAll()
      {
          return _context.Clients.Select(x => new Client() {Id = x.Id, FullName = x.FullName});
      }

      public Client GetById(int id)
      {
          return EntityToObject(_context.Clients.FirstOrDefault(x => x.Id == id));
      }

      public void Update(Client client)
      {
      }
  }
}
