using KittyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KittyApp.Data
{
    public class FakeDbContext // this would be Entity Framework Db context (or another ORM)
    {
        private static List<User> users = new List<User>()
        {
            new User { Id = 1, Firstname="James", Lastname="Bond", Username="james007", Password = "CasinoRoyale" }
        };

        public List<User> Users { get => users; }
    }
}
