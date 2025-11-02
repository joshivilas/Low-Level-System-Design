using ConsumerRepositoryPattern.InMemoryDataBase;

namespace ConsumerRepositoryPattern.Repository;

public class MyRepository : IMemoryRepository
{
    private readonly InMemoryDatabase db;

    public MyRepository(InMemoryDatabase _db)
    {
        db = _db;
    }

    public List<string> FetUsers(int limit, int offset)
    {
        List<string> fetUsers = db.GetUsers();
        int start = limit * (offset - 1);
        int end = Math.Min(start + limit, db.GetUsers().Count);
        if (start >= end)
        {
            return new List<string>();
        }
        return fetUsers.Skip(start).Take(end - start).ToList();  
    }
}