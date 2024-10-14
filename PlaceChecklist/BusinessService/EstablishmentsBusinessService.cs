using PlaceChecklist.DbStuff.Repositories;
using PlaceChecklist.Models;

namespace PlaceChecklist.BusinessService
{
    public class EstablishmentsBusinessService
    {
        private EstablishmentRepository _placeChecklistRepository;

        public EstablishmentsBusinessService(EstablishmentRepository placeChecklistRepository )
        {
            _placeChecklistRepository = placeChecklistRepository;
        }

        public List<EstablishmentViewModel> GetTop10EstablishmentsForMainPage()
        {
            var dbEstablishments = _placeChecklistRepository.Get(10);
            var establishmentVewModel = dbEstablishments.
                Select(dbEstablishments => new EstablishmentViewModel
                {
                    Name = dbEstablishments.Name,
                    Address = dbEstablishments.Address ?? "Неизвестный",
                    Description = dbEstablishments.Description ?? "Неизвестный",
                    Category = dbEstablishments.Category.Name ?? "Неизвестный",                    
                })
                .ToList();           
            return establishmentVewModel;
        }
    }
}
