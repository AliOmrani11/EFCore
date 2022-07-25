namespace EFCore_Sample.Repository;

public interface IRepository<TEntity> 
    where TEntity : class
{
    Task<List<TEntity>> GetAll();

    Task<TEntity?> Get(int id);

    Task Insert(TEntity entity);

    void Update(TEntity entity);

    void Delete(int id);

    Task Save();
}