using DomainElements;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IUserStorage
    {
        public void Add(User user);
        public List<User> GetAll();
        public User? GetById(int id);
    }
}