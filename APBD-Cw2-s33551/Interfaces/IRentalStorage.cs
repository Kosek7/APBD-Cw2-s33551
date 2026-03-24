using DomainElements;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRentalStorage
    {
        public void Add(Rental rental);
        public List<Rental> GetAll();
        public List<Rental> GetActiveRentals();
        public List<Rental> GetLateRentals();
        public List<Rental> GetByUser(User user);
    }
}