using ConsumerRepositoryPattern.Repository;

namespace ConsumerRepositoryPattern.Iterators;

public class UserIterator : IIterator<List<string>>
{
    private readonly IMemoryRepository _myRepository;
    private int limit = 1;
    private int offset = 1;
    private List<string> current;

    public UserIterator(IMemoryRepository memoryRepository, int limit = 1)
    {
        _myRepository = memoryRepository;
        this.limit = limit;
        this.current = _myRepository.FetUsers(limit, offset);
    }
    
    
    public bool HasNext()
    {
        return current != null && current.Count > 0;
    }

    public List<string> Next()
    {
        var result = this.current;
        this.offset ++;
        this.current = _myRepository.FetUsers(limit, offset);
        return result;
    }
}