using DomainElements;
using Interfaces;
using System.Collections.Generic;

namespace Services
{
    class RentalService
    {
        private readonly IRentalStorage rentalStorage;
        private readonly IEquipmentStorage equipmentStorage;
        private readonly UserService userService;
        private readonly PenaltyService penaltyService;

        public RentalService(IRentalStorage rentalStorage, 
                            IEquipmentStorage equipmentStorage, 
                            UserService userService,
                            PenaltyService penaltyService)
        {
            this.rentalStorage = rentalStorage;
            this.equipmentStorage = equipmentStorage;
            this.userService = userService;
            this.penaltyService = penaltyService;
        }

        public void Rent(User user, Equipment equipment, int durationDays)
        {
            if (!equipment.IsAvailable) 
                throw new Exception("Sprzęt niedostępny");

            if (!userService.CanRent(user)) 
                throw new Exception("Limit wypożyczeń przekroczony");

            var rental = new Rental
            {
                User = user,
                Equipment = equipment,
                RentDate = DateTime.Now,
                DurationDays = durationDays
            };

            equipment.IsAvailable = false;
            rentalStorage.Add(rental);
        }

        public decimal Return(Rental rental)
        {
            if (!rental.ReturnDate.HasValue)
                rental.ReturnDate = DateTime.Now;
            rental.Equipment.IsAvailable = true;
            return penaltyService.CalculatePenalty(rental);
        }

        public List<Rental> GetActiveRentals() => rentalStorage.GetActiveRentals();
        public List<Rental> GetLateRentals() => rentalStorage.GetLateRentals();
    }
}