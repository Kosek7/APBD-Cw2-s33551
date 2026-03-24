using DomainElements;
using Interfaces;
using System.Collections.Generic;

namespace Services
{
    class UserService
    {
        private readonly IUserStorage userStorage;
        private readonly IRentalStorage rentalStorage;

        public UserService(IUserStorage userStorage, IRentalStorage rentalStorage)
        {
            this.userStorage = userStorage;
            this.rentalStorage = rentalStorage;
        }

        public void AddUser(User user) => userStorage.Add(user);

        public int GetActiveRentalsCount(User user) => rentalStorage.GetByUser(user).Count(r => r.ReturnDate == null);

        public bool CanRent(User user)
        {
            int limit = user is Student ? 2 : 5;
            return GetActiveRentalsCount(user) < limit;
        }
    }
}