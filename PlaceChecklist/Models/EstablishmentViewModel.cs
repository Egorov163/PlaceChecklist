
namespace PlaceChecklist.Models
{
    public class EstablishmentViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public List<TagViewModel> Tags { get; set; }
    }
}
