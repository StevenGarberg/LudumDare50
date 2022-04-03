using LudumDare50.API.Models;
using LudumDare50.API.Repositories.Interfaces;
using MongoDB.Driver;

namespace LudumDare50.API.Repositories;

public class StatsRepository : IMongoRepository<Stats>
{
    private readonly IMongoClient _mongoClient;

    public StatsRepository(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }

    public Task<IEnumerable<Stats>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Stats> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Stats> Create(Stats data)
    {
        throw new NotImplementedException();
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
        IMongoDatabase database = _mongoClient.GetDatabase("LudumDare50 ");
        IMongoCollection<Stats> collection = database.GetCollection<Stats>("Stats");
        return collection;
    }
}