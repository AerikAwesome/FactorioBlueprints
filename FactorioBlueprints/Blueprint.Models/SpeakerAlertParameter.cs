namespace Blueprint.Models;

public class SpeakerAlertParameter
{
    public bool ShowAlert { get; set; }
    public bool ShowOnMap { get; set; }
    public Signal IconSignalId { get; set; }
    public string AlertMessage { get; set; }
}