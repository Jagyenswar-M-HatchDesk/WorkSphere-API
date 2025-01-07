using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.RegisterDTO;
using WorkSphere.Domain;

namespace WorkSphere.Application.Interfaces.IServices
{
    public interface IAccountService
    {
        Task<User> UpdateManagerAsync(User manager);
        Task<string> GeneratePasswordAsync(int l = 12);
        Task<IEnumerable<User>> GetUsersAllAsync();
        Task<IEnumerable<ManagerDto>> GetAllManagerAsync();
        Task<User> GetManagerByIdAsync(int id);
        Task<User> GetUserByIdAsync(int id);
    }
}
