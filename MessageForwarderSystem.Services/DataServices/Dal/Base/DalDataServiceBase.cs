namespace MessageForwarderSystem.Services.DataServices.Dal.Base;

public abstract class DalDataServiceBase<TEntity> : IDataServiceBase<TEntity>
    where TEntity : BaseModel, new()
{
    private readonly IDalServiceWrapperBase<TEntity> ServiceWrapper;

    protected DalDataServiceBase(IDalServiceWrapperBase<TEntity> serviceWrapper)
    {
        ServiceWrapper = serviceWrapper;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await ServiceWrapper.GetAllEntitiesAsync();

    public async Task<TEntity> FindAsync(int id)
        => await ServiceWrapper.GetEntityAsync(id);

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        await ServiceWrapper.UpdateEntityAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(TEntity entity)
        => await ServiceWrapper.DeleteEntityAsync(entity);

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await ServiceWrapper.AddEntityAsync(entity);
        return entity;
    }
}