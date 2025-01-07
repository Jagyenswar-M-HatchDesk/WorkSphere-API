using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.RegisterDTO;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Application.Interfaces.IServices;
using WorkSphere.Domain;

namespace WorkSphere.Application.Services
{
    public class AccountServices : IAccountService
    {
        private readonly IAccountRepo accountRepo;
        public AccountServices(IAccountRepo accountRepo) 
        {
            this.accountRepo = accountRepo;
        }

        public async Task<User> UpdateManagerAsync(User manager)
        {
            return await accountRepo.UpdateManager(manager);
        }

        public async Task<string> GeneratePasswordAsync(int l = 12)
        {
            return await accountRepo.GenerateRandomPassword(l);
        }

        public async Task<IEnumerable<User>> GetUsersAllAsync()
        {
            return await accountRepo.GetAllUser();
        }

        public async Task<IEnumerable<ManagerDto>> GetAllManagerAsync()
        {
            return await accountRepo.GetManagers();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await accountRepo.GetUserById(id);
        }
    }
}
