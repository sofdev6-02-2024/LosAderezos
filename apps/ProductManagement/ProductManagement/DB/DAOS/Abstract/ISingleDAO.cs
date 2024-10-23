namespace DB;

public interface ISingleDAO<T> : IDAO<T>
{
    T? Read(Guid id);
    bool Delete(Guid id);
}