using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.RegisterDTO;
using WorkSphere.Domain;

namespace WorkSphere.Application.Interfaces.IRepo
{
    public interface IAccountRepo
    {
        Task<string> GenerateRandomPassword(int length = 12);
        Task<User> UpdateManager(User manager);
        Task<IEnumerable<ManagerDto>> GetManagers();
        Task<IEnumerable<User>> GetAllUser();
        Task<User> GetUserById(int id);

    }
}
