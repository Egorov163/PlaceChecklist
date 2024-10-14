using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaceChecklist.BusinessService;
using PlaceChecklist.DbStuff;
using PlaceChecklist.DbStuff.Models;
using PlaceChecklist.Models;

namespace PlaceChecklist.Controllers
{
    public class PlaceChecklistController : Controller
    {
        public PlaceChecklistController(EstablishmentsBusinessService establishmentsBusinessService,
            WebDbContext webDbContext)
        {
            _establishmentsBusinessService = establishmentsBusinessService;
            _dbContext = webDbContext;
        }
        private EstablishmentsBusinessService _establishmentsBusinessService;
        private WebDbContext _dbContext;
        
        public IActionResult Index()
        {           
            var viewModel = new IndexViewModel()
            {
                Establishments = _establishmentsBusinessService.GetTop10EstablishmentsForMainPage()
            };
            return View(viewModel);
        }
    }
}
