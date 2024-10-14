using PlaceChecklist.DbStuff.Models;

namespace PlaceChecklist.DbStuff.Repositories
{
    public class TagRepository : BaseRepository<Tag>
    {
        public TagRepository(WebDbContext dbContext) : base(dbContext)
        {
        }
    }
}
