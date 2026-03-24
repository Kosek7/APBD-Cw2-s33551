using DomainElements;
using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyStorages
{
    public class EquipmentStorage : IEquipmentStorage
    {
        private List<Equipment> items = new List<Equipment>();

        public void Add(Equipment equipment) => items.Add(equipment);
        public List<Equipment> GetAll() => items;
        public List<Equipment> GetAvailable() => items.Where(e => e.IsAvailable).ToList();
        public Equipment? GetById(int id) => items.FirstOrDefault(e => e.Id == id);
    }
}