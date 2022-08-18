using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Radio.Models;

public record RadioStation
{
    [BsonId] public Guid Guid { get; set; }

    public string? Name { get; set; }
    public List<string> Genres { get; set; }
    public Genre Genre { get; set; }
}