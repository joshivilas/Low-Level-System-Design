namespace ConsumerRepositoryPattern.Iterators;

public interface IIterator<T>
{
    bool HasNext();
    T Next();
}