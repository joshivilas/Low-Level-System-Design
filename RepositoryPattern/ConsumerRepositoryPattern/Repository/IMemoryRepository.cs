namespace ConsumerRepositoryPattern.Repository;

public interface IMemoryRepository
{
    List<string> FetUsers(int limit, int offset);
}