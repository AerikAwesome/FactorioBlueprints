namespace Blueprint.Models;

public class Entity
{
    public int EntityNumber { get; set; }
    public string Name { get; set; }
    public Position Position { get; set; }
    public uint? Direction { get; set; }
    public float? Orientation { get; set; }
    public List<Connection>? Connections { get; set; }
    public object ControlBehavior { get; set; }
    public Dictionary<string, int>? Items { get; set; }
    public string? Recipe { get; set; }
    public int? Bar { get; set; }
    public Inventory? Inventory { get; set; }
    public InfinitySettings? InfinitySettings { get; set; }
    public string? Type { get; set; }
    public string? InputPriority { get; set; }
    public string? OutputPriority { get; set; }
    public string? Filter { get; set; }
    public Dictionary<string, int>? Filters { get; set; }
    public string? FilterMode { get; set; }
    public short? OverrideStackSize { get; set; }
    public Position? DropPosition { get; set; }
    public Position? PickupPosition { get; set; }
    public List<LogisticFilter>? RequestFilters { get; set; }
    public bool RequestFromBuffers { get; set; }
    public SpeakerParameter? Parameters { get; set; }
    public SpeakerAlertParameter? AlertParameters { get; set; }
    public bool? AutoLaunch { get; set; }
    public short? Variation { get; set; }
    public Color? Color { get; set; }
    public string? Station { get; set; }
}