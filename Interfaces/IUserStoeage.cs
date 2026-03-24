using System.Reflection.Metadata;

interface IUserStorage
{
    void Add(User user);
    List<User> GetAll();
    User? GetById(int id);
}