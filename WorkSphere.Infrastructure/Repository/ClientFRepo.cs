using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.ClientDTO;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Domain;

namespace WorkSphere.Infrastructure.Repository
{
    public class ClientFRepo : IClientRepo
    {
        private readonly WorkSphereDbContext _db;
        public ClientFRepo(WorkSphereDbContext db) 
        {
            this._db = db;
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            var clients = await _db.tbl_Clients.Where(e => e.IsActive == true).ToListAsync();
            return clients;
        }

        public async Task<Client> GetClientById(int id)
        {
            var client = await _db.tbl_Clients.FindAsync(id);
            return client;
        }

        public async Task<Client> UpdateClient(Client client)
        {
            _db.tbl_Clients.Update(client);
            await _db.SaveChangesAsync();
            return client;
        }

        public async Task<Client> AddClient(ClientCreateDTO dto)
        {
            var client = new Client()
            {
                ClientName = dto.ClientName,
                PhoneNumber = dto.PhnoneNumber,
                Email = dto.Email,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                CreatedBy = 1,
                IsActive = true,
                IsDelete = false
            };

            _db.tbl_Clients.Add(client);
            await _db.SaveChangesAsync();

            return client;
        
        }

        public async Task DeleteClient(int id)
        {
            var client = await GetClientById(id);
            if(client != null) 
            {
                client.IsDelete = true;
                client.IsActive = false;
            }

            _db.tbl_Clients.Update(client);
            await _db.SaveChangesAsync();
        }
    }
}
