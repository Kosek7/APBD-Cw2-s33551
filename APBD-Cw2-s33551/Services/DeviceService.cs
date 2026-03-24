using DomainElements;
using Interfaces;
using System.Collections.Generic;

namespace Services
{
    class DeviceService
    {
        private readonly IEquipmentStorage equipmentStorage;

        public DeviceService(IEquipmentStorage equipmentStorage)
        {
            this.equipmentStorage = equipmentStorage;
        }

        public void AddDevice(Equipment device) => equipmentStorage.Add(device);

        public List<Equipment> GetAllDevices() => equipmentStorage.GetAll();

        public List<Equipment> GetAvailableDevices() => equipmentStorage.GetAvailable();

        public void MarkAsUnavailable(Equipment device) => device.IsAvailable = false;
    }
}