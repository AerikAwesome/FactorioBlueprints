using Microsoft.Extensions.Logging;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using Blueprint.Models;
using System.Text.Json.Serialization;

namespace Blueprint.Parser;

public class BlueprintParser
{
    private readonly ILogger<BlueprintParser> _logger;
    private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions{
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)},
        PropertyNameCaseInsensitive = true};

    public BlueprintParser(ILogger<BlueprintParser> logger)
    {
        _logger = logger;
    }

    public bool TryParse(JsonDocument jsonBlueprint, out Models.Container? result)
    {
        try
        {
            result = jsonBlueprint.Deserialize<Models.Container>(jsonSerializerOptions);
            return true;
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to parse blueprint string");
            result = null;
            return false;
        }
    }

    public JsonDocument DecodeString(string blueprintString)
    {
        var bytes = Convert.FromBase64String(blueprintString.Substring(1));

        using (var ms = new MemoryStream(bytes))
        {
            using (var compressed = new ZLibStream(ms, CompressionMode.Decompress))
            {
                var result = JsonDocument.Parse(compressed);

                return result;
            }
        }
    }
}