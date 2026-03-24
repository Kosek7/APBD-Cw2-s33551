class EquipmentStorage : IEquipmentStorage
{
    private List<Equipment> items = new List<Equipment>();

    public void Add(Equipment equipment) => items.Add(equipment);
    List<Equipment> GetAll() => items;
    List<Equipment> GetAvailable() => items.Where(e => e.IsAvailable).ToList();
    Equipment? GetById(int id) => items.FirstOrDefault(e => e.Id == id);
}