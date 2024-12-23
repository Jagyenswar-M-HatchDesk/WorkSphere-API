using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.ClientDTO;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Application.Interfaces.IServices;
using WorkSphere.Domain;

namespace WorkSphere.Application.Services
{
    public class ClientService : IClientServices
    {
        private readonly IClientRepo _clientRepo;
        public ClientService(IClientRepo repo) 
        {
            _clientRepo = repo;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            var getclientd = await _clientRepo.GetAllClients();
            return getclientd;
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _clientRepo.GetClientById(id);
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            return await _clientRepo.UpdateClient(client);
        }

        public async Task<Client> AddClientAsync(ClientCreateDTO dto)
        {
            return await _clientRepo.AddClient(dto);
        }

        public async Task DeleteClientAsync(int id)
        {
            await _clientRepo.DeleteClient(id);
        }
    }
}
