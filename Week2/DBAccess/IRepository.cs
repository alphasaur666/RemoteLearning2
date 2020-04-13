namespace DBAccess
{
    public interface IRepository<TTable> 
        where TTable : Table
    {
        string Delete(TTable entity);
        string Delete(int primaryId);
        string Insert(TTable entity);
        string Select();
        string Select(TTable entity);
        string Update(TTable entity);
    }
}