using PlaceChecklist.DbStuff.Models;

namespace PlaceChecklist.DbStuff.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(WebDbContext dbContext) : base(dbContext)
        {
        }
    }
}
