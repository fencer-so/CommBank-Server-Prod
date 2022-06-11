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

    [BsonRepresentation(BsonType.ObjectId)]
    public string? AccountId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public List<string>? TransactionIds { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public List<string>? TagIds { get; set; }

    public string? IconName { get; set; }
}