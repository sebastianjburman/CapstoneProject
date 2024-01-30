namespace MessageForwarderSystem.Services.DalWrapper.Interfaces;

public interface IDalServiceWrapperBase <TEntity> where TEntity : BaseModel, new()
{
    Task<IList<TEntity>> GetAllEntitiesAsync();
    Task<TEntity> GetEntityAsync(int id);
    Task<TEntity> AddEntityAsync(TEntity entity);
    Task<TEntity> UpdateEntityAsync(TEntity entity);
    Task DeleteEntityAsync(TEntity entity);
}