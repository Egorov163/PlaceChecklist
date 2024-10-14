namespace PlaceChecklist.DbStuff.Models
{
    public class Tag : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual List<Establishment>? Establishments { get; set; }
    }
}
