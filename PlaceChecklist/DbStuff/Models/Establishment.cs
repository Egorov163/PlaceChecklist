namespace PlaceChecklist.DbStuff.Models
{
    public class Establishment : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Tag>? Tags { get; set; }
    }
}
