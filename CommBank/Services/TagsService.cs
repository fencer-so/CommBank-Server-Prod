using Microsoft.Extensions.Options;
using CommBank.Models;
using MongoDB.Driver;

namespace CommBank.Services;

public class TagsService
{
    private readonly IMongoCollection<CommBank.Models.Tag> _tagsCollection;

    public TagsService(
        IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        _tagsCollection = mongoDatabase.GetCollection<CommBank.Models.Tag>(
            databaseSettings.Value.TagsCollectionName
        );
    }

    public async Task<List<CommBank.Models.Tag>> GetAsync() =>
        await _tagsCollection.Find(_ => true).ToListAsync();

    public async Task<CommBank.Models.Tag?> GetAsync(string id) =>
        await _tagsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(CommBank.Models.Tag newTag) =>
        await _tagsCollection.InsertOneAsync(newTag);

    public async Task UpdateAsync(string id, CommBank.Models.Tag updatedTag) =>
        await _tagsCollection.ReplaceOneAsync(x => x.Id == id, updatedTag);

    public async Task RemoveAsync(string id) =>
        await _tagsCollection.DeleteOneAsync(x => x.Id == id);
}