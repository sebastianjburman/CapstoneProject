namespace MessageForwarderSystem.Services.DataServices.Interfaces;

public interface IDataServiceBase<TEntity> where TEntity : BaseModel, new()
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> FindAsync(int id);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<TEntity> AddAsync(TEntity entity);
}