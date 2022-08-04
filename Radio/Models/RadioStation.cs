using System.Collections.Generic;

namespace Radio.Models;

public class RadioStation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Genres { get; set; }    
}