using Microsoft.Extensions.Options;
using CommBank.Models;
using MongoDB.Driver;

namespace CommBank.Services;

public class AuthService
{
    private readonly IMongoCollection<User> _usersCollection;

    public AuthService(
        IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        _usersCollection = mongoDatabase.GetCollection<User>(
            databaseSettings.Value.UsersCollectionName
        );
    }

    public async Task<User?> Login(string email, string password)
    {
        var user = await _usersCollection
            .Find(x => x.Email == email)
            .FirstOrDefaultAsync();

        if (user is not null)
        {
            Console.WriteLine("Password", user.Password);
            var isCorrectPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);


            if (isCorrectPassword)
            {
                return user;
            }
        }

        return null;
    }
}