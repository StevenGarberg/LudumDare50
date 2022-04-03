using LudumDare50.API.Models;
using LudumDare50.API.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace LudumDare50.API.Repositories;

public class StatsRepository : IMongoRepository<Stats>
{
    private readonly IMongoClient _mongoClient;

    public StatsRepository(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }

    public async Task<IEnumerable<Stats>> GetAll()
    {
        List<Stats> statsCollection = await GetCollection().AsQueryable().ToListAsync();
        return statsCollection;
    }
    
    public async Task<IEnumerable<Stats>> GetByGameName(string gameName)
    {
        var stats = await GetCollection().AsQueryable()
            .Where(s => s.GameName == gameName).ToListAsync();
        return stats;
    }
    
    public async Task<IEnumerable<Stats>> GetByOwnerId(string ownerId)
    {
        var stats = await GetCollection().AsQueryable()
            .Where(s => s.OwnerId == ownerId).ToListAsync();
        return stats;
    }

    public async Task<Stats> GetById(string id)
    {
        var stats = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(s => s.Id == id);
        return stats;
    }

    public async Task<Stats> Create(Stats data)
    {
        data.CreatedAt = DateTime.UtcNow;
        data.UpdatedAt = DateTime.UtcNow;
        await GetCollection().InsertOneAsync(data);
        var statsList = await GetCollection().AsQueryable().ToListAsync();
        return statsList.FirstOrDefault(x => x.Id == data.Id);
    }

    public Task<Stats> Update(string id, Stats data)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id, bool hardDelete = false)
    {
        throw new NotImplementedException();
    }
    
    private IMongoCollection<Stats> GetCollection()
    {
        IMongoDatabase database = _mongoClient.GetDatabase("LudumDare50");
        IMongoCollection<Stats> collection = database.GetCollection<Stats>("Stats");
        return collection;
    }
}