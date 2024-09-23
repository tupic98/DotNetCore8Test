using TOPCustomOrders.API.Models.Domain;

namespace TOPCustomOrders.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync(string? filterBy = null, string? filterValue = null, string? sortBy = null, string? sortOrder = null,
            int page = 1, int limit = 15);
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
