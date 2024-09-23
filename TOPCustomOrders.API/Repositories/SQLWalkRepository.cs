using Microsoft.EntityFrameworkCore;
using TOPCustomOrders.API.Data;
using TOPCustomOrders.API.Models.Domain;

namespace TOPCustomOrders.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly AppDbContext dbContext;

        public SQLWalkRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await dbContext.Walks.FindAsync(id);

            if (existingWalk == null)
            {
                return null;
            }

            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterBy = null, string? filterValue = null, string? sortBy = null,
            string? sortOrder = null, int page = 1, int limit = 15)
        {
            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            // Filtering
            if (!string.IsNullOrWhiteSpace(filterBy) && !string.IsNullOrWhiteSpace(filterValue))
            {
                if(filterBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.ToLower().Contains(filterValue.ToLower()));
                }
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.OrderBy(x => x.Name);
                    if (!string.IsNullOrWhiteSpace(sortOrder))
                    {
                        walks = sortOrder.Equals("DESC", StringComparison.OrdinalIgnoreCase)
                            ? walks.OrderByDescending(x => x.Name)
                            : walks.OrderBy(x => x.Name);
                    }
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.OrderBy(x => x.LengthInKm);
                    if (!string.IsNullOrWhiteSpace(sortOrder))
                    {
                        walks = sortOrder.Equals("DESC", StringComparison.OrdinalIgnoreCase)
                            ? walks.OrderByDescending(x => x.LengthInKm)
                            : walks.OrderBy(x => x.LengthInKm);
                    }
                }
            }

            // Pagination
            var offset = (page - 1) * limit;

            return await walks.Skip(offset).Take(limit).ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FindAsync(id);

            if (existingWalk == null) {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await dbContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
