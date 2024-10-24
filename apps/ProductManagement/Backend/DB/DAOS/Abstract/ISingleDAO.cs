namespace DB;

public interface ISingleDAO<T>
{
    T? Read(Guid id);
    bool Delete(Guid id);
}
