using System.Text.Json.Serialization;

namespace Blueprint.Models;

public class Schedule
{
    [JsonPropertyName("schedule")]
    public List<ScheduleRecord> Schedules { get; set; }
    public List<int> Locomotives { get; set; }
}