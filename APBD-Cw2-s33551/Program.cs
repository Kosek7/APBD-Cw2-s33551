using DomainElements;
using MyStorages;
using Services;
using Interfaces;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var userStorage = new UserStorage();
        var equipmentStorage = new EquipmentStorage();
        var rentalStorage = new RentalStorage();

        var penaltyService = new PenaltyService();
        var userService = new UserService(userStorage, rentalStorage);
        var deviceService = new DeviceService(equipmentStorage);
        var rentalService = new RentalService(rentalStorage, equipmentStorage, userService, penaltyService);

        var laptop1 = new Laptop { Id = 1, Name = "Dell XPS", Cpu = "i7", Ram = 16 };
        var laptop2 = new Laptop { Id = 2, Name = "HP Elite", Cpu = "i5", Ram = 8 };
        var camera1 = new Camera { Id = 3, Name = "Canon EOS", Megapixels = 24, Lens = "18-55mm" };

        deviceService.AddDevice(laptop1);
        deviceService.AddDevice(laptop2);
        deviceService.AddDevice(camera1);

        var student1 = new Student { Id = 1, FirstName = "Jan", LastName = "Kowalski" };
        var employee1 = new Employee { Id = 2, FirstName = "Anna", LastName = "Nowak" };

        userService.AddUser(student1);
        userService.AddUser(employee1);

        rentalService.Rent(student1, laptop1, 7);
        rentalService.Rent(employee1, camera1, 3);

        try
        {
            rentalService.Rent(student1, laptop1, 5);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Niepowodzenie wypożyczenia: {ex.Message}");
        }

        var rentalLaptop = rentalStorage.GetByUser(student1).First();
        rentalLaptop.ReturnDate = rentalLaptop.DueDate;
        rentalService.Return(rentalLaptop);

        var rentalCamera = rentalStorage.GetByUser(employee1).First();
        rentalCamera.ReturnDate = rentalCamera.DueDate.AddDays(2);
        var penalty = rentalService.Return(rentalCamera);
        Console.WriteLine($"Kara za opóźnienie: {penalty} PLN");

        Console.WriteLine("\n=== Raport końcowy ===");
        foreach (var equipment in deviceService.GetAllDevices())
        {
            Console.WriteLine($"{equipment.Name} - {(equipment.IsAvailable ? "Dostępny" : "Niedostępny")}");
        }

        var activeRentals = rentalService.GetActiveRentals();
        if (activeRentals.Any())
        {
            Console.WriteLine("\nAktywne wypożyczenia:");
            foreach (var rental in activeRentals)
            {
                Console.WriteLine($"{rental.User.FirstName} {rental.User.LastName} -> {rental.Equipment.Name}");
            }
        }
        else
        {
            Console.WriteLine("\nBrak aktywnych wypożyczeń.");
        }
    }
}