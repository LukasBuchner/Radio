namespace Radio.Models;

public record FmRadio : RadioStation
{
    public string? Frequency { get; set; }
    public string Region { get; set; }
}