using MessageForwarderSystem.Services.DalWrapper.Interfaces;

namespace MessageForwarderSystem.Services.DalWrapper.Base;

public class DalServiceWrapperBase<TEntity> : IDalServiceWrapperBase<TEntity>
    where TEntity : BaseModel, new()
{
    private readonly string _filePath;

    protected DalServiceWrapperBase(IConfiguration config)
    {
        var basePath = Directory.GetCurrentDirectory();
        var files = Directory.GetFiles(basePath, config["DataPath"]??"Data.json", SearchOption.TopDirectoryOnly);
        _filePath = files[0];
    }

    private async Task<IList<TEntity>> ReadFromFileAsync()
    {
        if (!File.Exists(_filePath))
        {
            return new List<TEntity>();
        }

        using (FileStream fs = File.OpenRead(_filePath))
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = null
            };

            return await JsonSerializer.DeserializeAsync<IList<TEntity>>(fs, options) ?? new List<TEntity>();
        }
    }

    private async Task WriteToFileAsync(IList<TEntity> entities)
    {
        using (FileStream fs = File.Create(_filePath))
        {
            await JsonSerializer.SerializeAsync(fs, entities);
        }
    }

    public async Task<IList<TEntity>> GetAllEntitiesAsync()
    {
        return await ReadFromFileAsync();
    }

    public async Task<TEntity> GetEntityAsync(int id)
    {
        var entities = await ReadFromFileAsync();
        return entities.FirstOrDefault(e => e.Id == id);
    }

    public async Task<TEntity> AddEntityAsync(TEntity entity)
    {
        var entities = await ReadFromFileAsync();
        entities.Add(entity);
        await WriteToFileAsync(entities);
        return entity;
    }

    public async Task<TEntity> UpdateEntityAsync(TEntity entity)
    {
        try
        {
            var entities = await ReadFromFileAsync();
            // Use LINQ to find the index of the entity with the matching Id
            var index = entities.Select((e, i) => new { Entity = e, Index = i })
                .FirstOrDefault(ei => ei.Entity.Id == entity.Id)?.Index;

            if (index.HasValue && index != -1)
            {
                entities[index.Value] = entity;
                await WriteToFileAsync(entities.ToList()); // Convert back to List if needed by WriteToFileAsync
            }
            else
            {
                // Handle the case where the entity is not found, if necessary
                throw new KeyNotFoundException($"Entity with Id {entity.Id} not found.");
            }
            return entity;
        }
        catch (Exception ex)
        {
            // Log the exception, throw it, or handle it as needed
            throw new Exception("An error occurred while updating the entity.", ex);
        }
    }

    public async Task DeleteEntityAsync(TEntity entity)
    {
        var entities = await ReadFromFileAsync();
        var itemToRemove = entities.FirstOrDefault(e => e.Id == entity.Id);
        if (itemToRemove != null)
        {
            entities.Remove(itemToRemove);
            await WriteToFileAsync(entities);
        }
    }
}