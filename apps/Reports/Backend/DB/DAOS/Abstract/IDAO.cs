namespace DB;

public interface IDAO<T>
{
    void Write(T entity);
}
