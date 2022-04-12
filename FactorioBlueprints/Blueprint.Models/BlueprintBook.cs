using System.Text.Json.Serialization;

namespace Blueprint.Models;

public class BlueprintBook
{
    [JsonPropertyName("item")]
    public string Item { get; set; }
    [JsonPropertyName("label")]
    public string Label { get; set; }
    [JsonPropertyName("label_color")]
    public Color Color { get; set; }
    [JsonPropertyName("blueprints")]
    public List<Blueprint> Blueprints { get; set; }
    [JsonPropertyName("active_index")]
    public int ActiveIndex { get; set; }
    [JsonPropertyName("version")]
    public long Version { get; set; }
}