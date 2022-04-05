using LudumDare50.API.Models;
using RestSharp;

namespace LudumDare50.Web.Clients;

public class StatsClient
{
    private readonly RestClient _restClient;
    
    public StatsClient(RestClient restClient)
    {
        _restClient = restClient;
    }
    
    public async Task <List<Stats>> GetAll()
    {
        var request = new RestRequest("https://ludumdare50.azurewebsites.net/stats");
        var response = await _restClient.ExecuteGetAsync<List<Stats>>(request);
        return response.Data;
    }
}