using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Radio.Services;

public class MongoCRUD
{
    private IMongoDatabase _mongoDatabase;

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
        var filter = Builders<T>.Filter.Eq("Id", guid);
        collection.DeleteOne(filter);
    }

    public List<T> LoadRecords<T>(string table)
    {
        var collection = _mongoDatabase.GetCollection<T>(table);

        return collection.Find(new BsonDocument()).ToList();
    }
}