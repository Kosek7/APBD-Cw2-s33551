using DomainElements;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IEquipmentStorage
    {
        void Add(Equipment equipment);
        List<Equipment> GetAll();
        List<Equipment> GetAvailable();
        Equipment? GetById(int id);
    }
}