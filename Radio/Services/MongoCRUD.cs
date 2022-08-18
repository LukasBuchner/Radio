using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Radio.Services;

public class MongoCRUD
{
    private readonly IMongoDatabase _mongoDatabase;

    public MongoCRUD(string database)
    {
        var client = new MongoClient();
        _mongoDatabase = client.GetDatabase(database);
    }

    public void InsertRecord<T>(string table, T record)
    {
        var collection = _mongoDatabase.GetCollection<T>(table);
        collection.InsertOne(record);
    }

    public void UpsertRecord<T>(string table, Guid guid, T record)
    {
        var collection = _mongoDatabase.GetCollection<T>(table);
        var result = collection.ReplaceOne(
            new BsonDocument("_id", guid),
            record,
            new UpdateOptions { IsUpsert = true });
    }

    public void DeleteRecord<T>(string table, Guid guid)
    {
        var collection = _mongoDatabase.GetCollection<T>(table);
        var filter = Builders<T>.Filter.Eq("_id", guid);
        collection.DeleteOne(filter);
    }

    public List<T> LoadRecords<T>(string table)
    {
        var collection = _mongoDatabase.GetCollection<T>(table);

        return collection.Find(new BsonDocument()).ToList();
    }

    public List<T> Find<T, T1>(string table, string attribute, T1 value)
    {
        var collection = _mongoDatabase.GetCollection<BsonDocument>(table);
        var builder = Builders<BsonDocument>.Filter;
        var filter = builder.Eq(attribute, value);

        //return collection.Find(new BsonDocument()).ToList();
        var documents = collection.Find(filter).ToList();
        var list = new List<T>();
        foreach (var document in documents)
        {
            list.Add(BsonSerializer.Deserialize<T>(document));
        }

        return list;
    }

    public void DeleteTable(string table)
    {
        _mongoDatabase.DropCollection(table);
    }
}