using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.ClientDTO;
using WorkSphere.Domain;

namespace WorkSphere.Application.Interfaces.IRepo
{
    public interface IClientRepo
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> GetClientById(int id);
        Task<Client> UpdateClient(Client client);
        Task<Client> AddClient(ClientCreateDTO dto);
        Task DeleteClient(int id);

    }
}
