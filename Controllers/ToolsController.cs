using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using ToolsApi.Models;

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

    [HttpGet(Name = "TransformJson")]
    public string TransformJson()
    {
        using (StreamReader r = new StreamReader(@"C:\Users\yann.chedeville\Downloads\voitureListNew.json"))
        {
            string json = r.ReadToEnd();
            List<VoitureJson> items = JsonSerializer.Deserialize<List<VoitureJson>>(json);
            var result = items.GroupBy(x => x.Marque).Select(x => new VoitureListClean { Marque = x.Key, Model = x.Select(z => z.Model).ToList()});
            return JsonSerializer.Serialize(result);
        }
    }

    [HttpGet(Name = "GetCarModels")]
    public List<string> GetCarModels(string carBrand)
    {
        using (StreamReader r = new StreamReader(@"C:\Users\yann.chedeville\Downloads\voitureListNew.json"))
        {
            string json = r.ReadToEnd();
            IEnumerable<VoitureListClean> items = JsonSerializer.Deserialize<List<VoitureListClean>>(json);
            // var result = items.All(x => x.Marque == carBrand);
            return null;
        }
    }
}