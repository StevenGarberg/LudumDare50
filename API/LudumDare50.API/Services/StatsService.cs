using LudumDare50.API.Models;
using LudumDare50.API.Repositories.Interfaces;

namespace LudumDare50.API.Services;

public class StatsService
{
    private readonly IMongoRepository<Stats> _repository;

    public StatsService(IMongoRepository<Stats> repository)
    {
        _repository = repository;
    }
    
    public async Task<Stats> Create(string ownerId, string gameName, Stats request)
    {
        var stats = new Stats(ownerId, gameName, request);

        return await _repository.Create(stats);
    }
}