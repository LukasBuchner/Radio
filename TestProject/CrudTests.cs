using MongoDB.Bson.Serialization.Attributes;
using Radio.Services;

namespace TestProject;

public class CrudTests
{
    private const string Table = "TestTable";
    private MongoCRUD _mongoCrud;

    [SetUp]
    public void Setup()
    {
        _mongoCrud = new MongoCRUD("TestDataBase");
    }

    [TearDown]
    public void TearDown()
    {
        _mongoCrud.DeleteTable(Table);
    }

    [Test]
    public void TestInsert()
    {
        var record = new TestRecord
        {
            Guid = Guid.NewGuid(),
            Name = "InsertTest"
        };

        var records = _mongoCrud.LoadRecords<TestRecord>(Table);
        Assume.That(records, Does.Not.Contain(record));

        _mongoCrud.InsertRecord(Table, record);

        records = _mongoCrud.LoadRecords<TestRecord>(Table);

        Assert.That(records, Does.Contain(record));
    }

    [Test]
    public void TestDelete()
    {
        var record = new TestRecord
        {
            Guid = Guid.NewGuid(),
            Name = "InsertTest"
        };

        _mongoCrud.InsertRecord(Table, record);
        var records = _mongoCrud.LoadRecords<TestRecord>(Table);
        Assume.That(records, Does.Contain(record));

        _mongoCrud.DeleteRecord<TestRecord>(Table, record.Guid);

        records = _mongoCrud.LoadRecords<TestRecord>(Table);

        Assert.That(records, Does.Not.Contain(record));
    }

    [Test]
    public void TestLoadRecords()
    {
        var record1 = new TestRecord
        {
            Guid = Guid.NewGuid(),
            Name = "Record 1"
        };
        var record2 = new TestRecord
        {
            Guid = Guid.NewGuid(),
            Name = "Record 2"
        };

        _mongoCrud.InsertRecord(Table, record1);
        _mongoCrud.InsertRecord(Table, record2);
        var actualRecords = new List<TestRecord> { record1, record2 };

        var records = _mongoCrud.LoadRecords<TestRecord>(Table);
        Assert.That(records, Is.EqualTo(actualRecords));
    }

    [Test]
    public void TestUpsert()
    {
        var record = new TestRecord
        {
            Guid = Guid.NewGuid(),
            Name = "Record"
        };
        _mongoCrud.InsertRecord(Table, record);

        var records = _mongoCrud.LoadRecords<TestRecord>(Table);
        Assume.That(records, Does.Contain(record));

        var editedRecord = new TestRecord
        {
            Guid = record.Guid,
            Name = "Edited Record"
        };

        _mongoCrud.UpsertRecord(Table, record.Guid, editedRecord);

        records = _mongoCrud.LoadRecords<TestRecord>(Table);
        Assert.That(records, Does.Contain(editedRecord));
        Assert.That(records, Does.Not.Contain(record));
    }

    private record TestRecord
    {
        [BsonId] public Guid Guid { get; init; }
        public string Name { get; set; }
    }
}