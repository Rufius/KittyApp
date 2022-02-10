using KittyApp.Contracts;
using KittyApp.Data;
using KittyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KittyApp.Services
{
    public class UserService : IUserService
    {
        private FakeDbContext _dbContext;

        public UserService(FakeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> Authenticate(string username, string password)
        {
            var doesExist = _dbContext.Users.Any(u => u.Username == username && u.Password == password);
            return Task.FromResult(doesExist); // simulate async calls to db
        }

        public Task<User> Get(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user); // simulate async calls to db
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return Task.FromResult(_dbContext.Users.AsEnumerable());
        }

        public Task Add(User user)
        {
            Validate(user);
            user.Id = GenerateId();
            _dbContext.Users.Add(user);
            return Task.CompletedTask;
        }

        public Task Update(User user)
        {
            Validate(user);

            var u = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            if (u == null)
                throw new Exception($"The user with id = {user.Id} is not found");

            // for object with more fields would use AutoMapper or something similar.
            u.Firstname = user.Firstname;
            u.Lastname = user.Lastname;
            u.Username = user.Username;
            u.Password = user.Password;

            return Task.CompletedTask; // simulate async calls to db
        }

        public Task Delete(int id)
        {
            var u = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            _dbContext.Users.Remove(u);
            return Task.CompletedTask; // simulate async calls to db
        }

        private void Validate(User user)
        {
            if (user == null)
                throw new Exception("The user object is null");

            if (string.IsNullOrWhiteSpace(user.Username))
                throw new Exception("The username is empty");

            if (string.IsNullOrWhiteSpace(user.Password))
                throw new Exception("The password is empty");

            // other validations would be here
        }

        private int GenerateId() // normally id would be generated on db side
        {
            var id = _dbContext.Users.Max(u => u.Id);
            return ++id;
        }

    }
}
