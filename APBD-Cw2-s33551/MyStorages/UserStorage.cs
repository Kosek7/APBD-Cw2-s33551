using DomainElements;
using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyStorages
{
    class UserStorage : IUserStorage
    {
        private List<User> users = new List<User>();

        public void Add(User user) => users.Add(user);
        public List<User> GetAll() => users;
        public User? GetById(int id) => users.FirstOrDefault(u => u.Id == id);
    }
}