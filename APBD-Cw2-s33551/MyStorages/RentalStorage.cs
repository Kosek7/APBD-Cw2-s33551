using DomainElements;
using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyStorages
{
    class RentalStorage : IRentalStorage
    {
    private List<Rental> rentals = new List<Rental>();
        public void Add(Rental rental) => rentals.Add(rental);
        public List<Rental> GetAll() => rentals;
        public List<Rental> GetActiveRentals() => rentals.Where(r => r.ReturnDate == null).ToList();
        public List<Rental> GetLateRentals() => rentals.Where(r => r.ReturnDate == null && r.DueDate < DateTime.Now).ToList();
        public List<Rental> GetByUser(User user) => rentals.Where(r => r.User == user).ToList();
    }
}