namespace PatternsBusStorage.Bll.Observer;

public interface IObserver<T>
{
    void Update(T entity);
}