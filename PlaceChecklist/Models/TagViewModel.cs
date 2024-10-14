namespace PlaceChecklist.Models
{
    public class TagViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<EstablishmentViewModel> Establishments { get; set; }
    }
}
