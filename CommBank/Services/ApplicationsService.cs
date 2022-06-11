using Microsoft.Extensions.Options;
using CommBank.Models;
using MongoDB.Driver;

namespace CommBank.Services;

public class ApplicationsService : IApplicationsService
{
    private readonly IMongoCollection<Application> _applicationsCollection;

    public ApplicationsService(IMongoDatabase mongoDatabase)
    {
        _applicationsCollection = mongoDatabase.GetCollection<Application>("Applications");
    }

    public async Task<List<Application>> GetAsync() =>
        await _applicationsCollection.Find(_ => true).ToListAsync();


    public async Task<Application?> GetAsync(string id) =>
    await _applicationsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Application newApplication) =>
        await _applicationsCollection.InsertOneAsync(newApplication);
}