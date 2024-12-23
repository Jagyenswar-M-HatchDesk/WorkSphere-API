using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.ClientDTO;
using WorkSphere.Domain;

namespace WorkSphere.Application.Interfaces.IServices
{
    public interface IClientServices
    {
        Task<IEnumerable<Client>> GetClientsAsync();

        Task<Client> GetClientByIdAsync(int id);
        Task<Client> UpdateClientAsync(Client client);
        Task<Client> AddClientAsync(ClientCreateDTO dto);
        Task DeleteClientAsync(int id);
    }
}
