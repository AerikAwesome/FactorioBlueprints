using System.Text.Json.Serialization;

namespace Blueprint.Models;

public class Color
{
    [JsonPropertyName("r")]
    public float Red { get; set; }
    [JsonPropertyName("g")]
    public float Green { get; set; }
    [JsonPropertyName("b")]
    public float Blue { get; set; }
    [JsonPropertyName("a")]
    public float Transparency { get; set; }
}