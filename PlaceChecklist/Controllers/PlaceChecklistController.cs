using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlaceChecklist.BusinessService;
using PlaceChecklist.DbStuff;
using PlaceChecklist.DbStuff.Models;
using PlaceChecklist.DbStuff.Repositories;
using PlaceChecklist.Models;

namespace PlaceChecklist.Controllers
{
    public class PlaceChecklistController : Controller
    {
        public PlaceChecklistController(EstablishmentsBusinessService establishmentsBusinessService,
            WebDbContext webDbContext,
            TagRepository tagRepository,
            CategoryRepository categoryRepository)
        {
            _establishmentsBusinessService = establishmentsBusinessService;
            _tagRepository = tagRepository;
            _categoryRepository = categoryRepository;

        }
        private EstablishmentsBusinessService _establishmentsBusinessService;
        private TagRepository _tagRepository;
        private CategoryRepository _categoryRepository;
        private WebDbContext _dbContext;
        
        //Места
        public IActionResult Index()
        {           
            var viewModel = new IndexViewModel()
            {
                Establishments = _establishmentsBusinessService.GetTop10EstablishmentsForMainPage()
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddEstablishment()
        {
            var viewModel = new AddEstablishmentViewModel();
            viewModel.Tags = _tagRepository.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            viewModel.Category = _categoryRepository.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
          
            return View(viewModel);
        }


        //public IActionResult AddDividend()
        //{
        //    var viewModel = new AddDividendViewModel();

        //    viewModel.Stocks = _stockRepository.GetUserStocks(_authService.GetCurrentUserId())
        //        .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //        .ToList();

        //    return View(viewModel);
        //}



        //Теги
        [HttpGet]
        public IActionResult AddTag()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTag(AddTagViewModel addTagViewModel)
        {
            var tagDb = new Tag
            {
                Name = addTagViewModel.Name,
                Description = addTagViewModel.Description
            };
            _tagRepository.Add(tagDb);

            return RedirectToAction("Index");
        }

        //Категории
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel addCategoryViewModel)
        {
            var categoryDb = new Category
            {
                Name = addCategoryViewModel.Name,
                Description = addCategoryViewModel.Description
            };
            _categoryRepository.Add(categoryDb);

            return RedirectToAction("Index");
        }
    }
}
