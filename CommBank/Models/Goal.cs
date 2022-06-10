using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CommBank.Models;

public class Goal
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string? Name { get; set; }

    public Int64 TargetAmount { get; set; } = 0;

    public DateTime TargetDate { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;

    public ObjectId? AccountId { get; set; }

    public List<ObjectId>? TransactionIds { get; set; }

    public List<ObjectId>? TagIds { get; set; }

    public string? IconName { get; set; }
}