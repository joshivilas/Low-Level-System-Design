using ConsumerRepositoryPattern.Iterators;
using ConsumerRepositoryPattern.Repository;

namespace ConsumerRepositoryPattern.Services;

public class UserService
{
    private readonly IMemoryRepository _memoryRepository;
    private IIterator<List<string>> _userIterator;

    public UserService(IMemoryRepository memoryRepository)
    {
        _memoryRepository = memoryRepository;
        _userIterator = new UserIterator(_memoryRepository, 10);
    }

    public void GetUserFromPlatform()
    {
        while (_userIterator.HasNext())
        {
            var user = _userIterator.Next();
            foreach (var i in user)
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine();
        }
    }
    
    
}