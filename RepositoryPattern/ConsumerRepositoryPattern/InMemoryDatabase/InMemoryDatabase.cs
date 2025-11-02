
namespace ConsumerRepositoryPattern.InMemoryDataBase
{
    public class InMemoryDatabase
    {
        private readonly List<string> Users = new List<string>();

        public void SeedUser()
        {
            for (var i = 0; i < 200; i++)
            {
                Users.Add($"User {i}");
            }
        }

        public List<string> GetUsers()
        {
            return Users;
        }
    }
}

