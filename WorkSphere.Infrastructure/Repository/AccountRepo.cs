using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.RegisterDTO;
using WorkSphere.Application.DTOs.UserDTO;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Domain;

namespace WorkSphere.Infrastructure.Repository
{
    public class AccountRepo : IAccountRepo
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly WorkSphereDbContext _dbcontext;


        public AccountRepo(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, WorkSphereDbContext dbcontext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this._dbcontext = dbcontext;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            var users = await _dbcontext.Users.Include(e => e.RoleNavigation).Include(e => e.DepartmentNavigation).Where(e => e.IsActive == true).ToListAsync();
            return users;

        }

        public Task<string> GenerateRandomPassword(int length = 12)
        {
            // Define password options
            var options = new PasswordOptions
            {
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
                RequireNonAlphanumeric = true,
                RequiredLength = length
            };

            string[] randomChars = new[]
            {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ", // Uppercase
            "abcdefghijkmnopqrstuvwxyz", // Lowercase
            "0123456789",                // Digits
            "!@$?_-",                    // Non-alphanumeric
        };

            Random random = new Random();
            StringBuilder password = new StringBuilder();


            // Ensure the password meets all requirements
            if (options.RequireUppercase)
                password.Append(randomChars[0][random.Next(randomChars[0].Length)]);
            if (options.RequireLowercase)
                password.Append(randomChars[1][random.Next(randomChars[1].Length)]);
            if (options.RequireDigit)
                password.Append(randomChars[2][random.Next(randomChars[2].Length)]);
            if (options.RequireNonAlphanumeric)
                password.Append(randomChars[3][random.Next(randomChars[3].Length)]);

            // Fill the rest of the password length with random characters
            while (password.Length < options.RequiredLength)
            {
                string randomSet = randomChars[random.Next(randomChars.Length)];
                password.Append(randomSet[random.Next(randomSet.Length)]);

            }

            // Shuffle the password to make it more secure
            //return Shuffle(password);
            return Task.FromResult(Shuffle(password.ToString()));
        }

        private static string Shuffle(string input)
        {
            char[] array = input.ToCharArray();
            Random random = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
            return new string(array);
        }

        public async Task<User> UpdateManager(User manager)
        {
            _dbcontext.Users.Update(manager);
            await _dbcontext.SaveChangesAsync();

            return manager;

        }

        public async Task<IEnumerable<ManagerDto>> GetManagers()
        {
            var getusers = await _dbcontext.Users.Include(e => e.RoleNavigation).Include(e=>e.DepartmentNavigation).Where(e => e.IsActive == true && e.Rollid == 2)
                .Select(manager => new ManagerDto()
                {
                    FullName = manager.FirstName + " " + manager.LastName,
                    Id = manager.Id,
                    projects = manager.Projects.Select(p => new ProjectsName() { Title = p.Title}).ToList(),
                }).ToListAsync();
            return getusers;
        }

        public async Task<User> GetManagerById(int id)
        {
            var manager = await _dbcontext.Users.Include(e => e.RoleNavigation).Include(e => e.DepartmentNavigation).Where(e => e.Id == id && e.Rollid == 2 && e.IsActive == true).FirstAsync();
            return manager;
        }

        public async Task<User> GetUserById(int id)
        {
            var manager = await _dbcontext.Users.Include(e => e.RoleNavigation).Include(e => e.DepartmentNavigation).Where(e => e.Id == id && e.IsActive==true).FirstAsync();
            return manager;
        }

    }
}
