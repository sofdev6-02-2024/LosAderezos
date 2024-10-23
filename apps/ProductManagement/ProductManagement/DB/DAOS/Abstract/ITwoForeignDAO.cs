namespace DB;

public interface ITwoForeignDAO <T> : IDAO<T>
{
    T? Read(Guid id1, Guid id2);
    bool Delete(Guid id1,Guid id2);
}