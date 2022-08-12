using MongoDB.Bson.Serialization.Attributes;
using Radio.Services;

namespace TestProject;

public class CrudTests
{
    private const string table = "TestTable";
    private MongoCRUD _mongoCrud;

    [SetUp]
    public void Setup()
    {
        _mongoCrud = new MongoCRUD("TestDataBase");
    }

    [TearDown]
    public void TearDown()
    {
        _mongoCrud.DeleteTable(table);
    }

    [Test]
    public void TestInsert()
    {
        var record = new TestRecord
        {
            Guid = Guid.NewGuid(),
            Name = "InsertTest"
        };

        var records = _mongoCrud.LoadRecords<TestRecord>(table);
        Assume.That(records, Does.Not.Contain(record));

        _mongoCrud.InsertRecord(table, record);

        records = _mongoCrud.LoadRecords<TestRecord>(table);

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

        _mongoCrud.InsertRecord(table, record);
        var records = _mongoCrud.LoadRecords<TestRecord>(table);
        Assume.That(records, Does.Contain(record));

        _mongoCrud.DeleteRecord<TestRecord>(table, record.Guid);

        records = _mongoCrud.LoadRecords<TestRecord>(table);

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

        _mongoCrud.InsertRecord(table, record1);
        _mongoCrud.InsertRecord(table, record2);
        var actualRecords = new List<TestRecord> { record1, record2 };

        var records = _mongoCrud.LoadRecords<TestRecord>(table);
        Assert.That(records, Is.EqualTo(actualRecords));
    }

    private record TestRecord
    {
        [BsonId] public Guid Guid { get; set; }
        public string Name { get; set; }
    }
}