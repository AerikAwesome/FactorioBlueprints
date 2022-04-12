namespace Blueprint.Models;

public class ScheduleRecord
{
    public string Station { get; set; }
    public List<WaitCondition> WaitConditions { get; set; }
}