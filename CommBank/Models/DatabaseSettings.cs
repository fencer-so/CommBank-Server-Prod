namespace CommBank.Models;

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string UsersCollectionName { get; set; } = null!;

    public string ApplicationsCollectionName { get; set; } = null!;

    public string TagsCollectionName { get; set; } = null!;

    public string GoalsCollectionName { get; set; } = null!;

    public string TransactionsCollectionName { get; set; } = null!;

    public string AccountsCollectionName { get; set; } = null!;

}