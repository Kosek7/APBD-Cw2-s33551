interface IEquipmentStorage
{
    void Add(Equipment equipment);
    List<Equipment> GetAll();
    List<Equipment> GetAvailable();
    Equipment? GetById(User user);
}