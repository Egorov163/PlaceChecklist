using Microsoft.EntityFrameworkCore;
using PlaceChecklist.DbStuff.Models;

namespace PlaceChecklist.DbStuff.Repositories
{
    public class EstablishmentRepository : BaseRepository<Establishment>
    {
        public EstablishmentRepository(WebDbContext dbContext) : base(dbContext)
        {
        }
        public override IEnumerable<Establishment> Get(int maxCount = 10)
        {
            return _entities             
                .Include(x => x.Category)
                .Include(x => x.Tags)
                .Take(maxCount)
                .ToList();
        }
    }
}
