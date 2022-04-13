using Microsoft.Extensions.Logging;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using Blueprint.Models;

namespace Blueprint.Parser;

public class BlueprintParser
{
    private readonly ILogger<BlueprintParser> _logger;

    public BlueprintParser(ILogger<BlueprintParser> logger)
    {
        _logger = logger;
    }

    public bool TryParseAsBlueprint(JsonDocument jsonBlueprint, out Models.Blueprint? blueprint)
    {
        if (BlueprintIsBook(jsonBlueprint))
        {
            blueprint = null;
            return false;
        }

        try
        {
            blueprint = jsonBlueprint.Deserialize<Models.Blueprint>();
            return true;
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to parse blueprint string");
            blueprint = null;
            return false;
        }
    }

    public bool TryParseAsBlueprintBook(JsonDocument jsonBlueprint, out BlueprintBook? blueprintBook)
    {
        if (!BlueprintIsBook(jsonBlueprint))
        {
            blueprintBook = null;
            return false;
        }

        try
        {
            blueprintBook = jsonBlueprint.Deserialize<Models.BlueprintBook>();
            return true;
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to parse blueprint string");
            blueprintBook = null;
            return false;
        }
    }

    private bool BlueprintIsBook(JsonDocument document)
    {
        return document.RootElement.TryGetProperty("blueprint-book", out _);
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