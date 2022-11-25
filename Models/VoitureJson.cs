namespace ToolsApi.Models
{
    public class VoitureJson
    {
        public string Marque { get; set; }
        public string Model { get; set; }
    }

    public class VoitureListClean{
        public string Marque { get; set; }
        public List<string> Model { get; set; }
    }
}