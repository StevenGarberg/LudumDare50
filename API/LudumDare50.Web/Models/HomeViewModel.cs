using LudumDare50.API.Models;

namespace LudumDare50.Web.Models;

public class HomeViewModel
{
    public IReadOnlyList<Stats> StatsList { get; set; } = new List<Stats>();
}