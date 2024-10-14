
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlaceChecklist.Models
{
    public class AddEstablishmentViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
        public List<SelectListItem> Category { get; set; }
        public List<SelectListItem> Tags { get; set; }
    }
}
