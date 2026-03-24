class UserStorage : IUserStorage
{
    private List<UserStorage> users = new List<UserStorage>();

    void Add(User user) => users.Add(user);
    List<User> GetAll() => users;
    User? GetById(int id) => users.FirstOrDefault(u => u.Id == id);
}