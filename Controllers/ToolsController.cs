using Microsoft.AspNetCore.Mvc;

namespace ToolsApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ToolsController : ControllerBase
{
    [HttpGet(Name = "GetInfo")]
    public string GetInfo()
    {
        return "hello";
    }

    [HttpGet(Name = "GetName/{name}")]
    public string GetName(string name)
    {
        var list = new List<string> { "Pierre", "Jean", "Marcelle" };
        var query = list.FirstOrDefault(x => x == name);
        if (query == null)
            return "Aucun nom trouvé";
        else
            return query;
    }
}