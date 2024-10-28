namespace DB;

public interface IDAO<T>
{
    int Create(T element);
    List<T> ReadAll();
    int Update(T element);
}