using System.Text.Json.Serialization;

namespace Blueprint.Models;

public class Connection
{
    [JsonPropertyName("1")]
    public ConnectionPoint FirstConnectionPoint { get; set; }
    [JsonPropertyName("2")]
    public ConnectionPoint SecondConnectionPoint { get; set; }
}