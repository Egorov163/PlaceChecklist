namespace PlaceChecklist.Models
{
    public class CategoryViewModel
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public List<EstablishmentViewModel> Establishments { get; set; }
    }
}
