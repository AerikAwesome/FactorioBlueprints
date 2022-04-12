namespace Blueprint.Models;

public class WaitCondition
{
    public string Type { get; set; }
    public string CompareType { get; set; }
    public short? Ticks { get; set; }
    public object? CircuitCondition { get; set; }
}