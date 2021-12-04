using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace NewsWebsite.ViewModels.Dashboard
{
    public class NumberOfVisitChartViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("y")]
        public int Value { get; set; }
    }
}
