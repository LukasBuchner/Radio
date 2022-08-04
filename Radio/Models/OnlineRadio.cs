namespace Radio.Models;

public record OnlineRadio : RadioStation
{
    public string Url { get; set; }
}