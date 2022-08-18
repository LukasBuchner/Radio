using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Radio.Models;

public record Genre
{
    [BsonId] public Guid Guid { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}