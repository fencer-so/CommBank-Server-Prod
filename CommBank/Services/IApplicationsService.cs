using CommBank.Models;

namespace CommBank.Services
{
    public interface IApplicationsService
    {
        Task CreateAsync(Application newApplication);
        Task<List<Application>> GetAsync();
        Task<Application?> GetAsync(string id);
    }
}