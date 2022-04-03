using LudumDare50.API.Models;

namespace LudumDare50.API.Repositories.Interfaces;

public interface IMongoRepository<T> where T : BaseResource
{
    public Task<IEnumerable<T>> GetAll();
    public Task<IEnumerable<Stats>> GetByGameName(string gameName);
    public Task<IEnumerable<Stats>> GetByOwnerId(string ownerId);
    public Task<T> GetById(string id);
    public Task<T> Create(T data);
    public Task<T> Update(string id, T data);
    public Task Delete(string id);
}