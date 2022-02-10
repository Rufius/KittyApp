using KittyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KittyApp.Contracts
{
    public interface IUserService
    {
        Task<bool> Authenticate(string username, string password);
        Task<User> Get(int id);
        Task<IEnumerable<User>> GetAll();
        Task Add(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
