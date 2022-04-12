namespace Blueprint.Models;

public class Blueprint
{
    public string Item { get; set; }
    public string Label { get; set; }
    public Color? LabelColor { get; set; }
    public List<Entity> Entities { get; set; }
    public List<Tile> Tiles { get; set; }
    public List<Icon> Icons { get; set; }
    public List<Schedule> Schedules { get; set; }
    public long Version { get; set; }
}