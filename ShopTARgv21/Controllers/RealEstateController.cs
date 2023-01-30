using Microsoft.AspNetCore.Mvc;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;
using ShopTARgv21.Models.RealEstate;

namespace ShopTARgv21.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IRealEstateServices _realEstateServices;
        public RealEstateController(ShopDbContext context, IRealEstateServices realEstate)
        {
            _context = context;
            _realEstateServices = realEstate;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.RealEstate
                .OrderByDescending(x => x.Id)
                .Select(x => new RealEstateListViewModel
                    {Id = x.Id,
                    Address = x.Address,
                    City = x.City,
                    Contact = x.Contact,
                    Size = x.Size,
                    Price = x.Price,
                    RoomNumber = x.RoomNumber,
                    BuildingType = x.BuildingType,});
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel realEstate = new RealEstateCreateUpdateViewModel();

            return View("CreateUpdate", realEstate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                Contact = vm.Contact,
                Size = vm.Size,
                Price = vm.Price,
                BuildingType = vm.BuildingType,
                County = vm.County,
                RoomNumber = vm.RoomNumber,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.MofiedAt
            };

            var result = await _realEstateServices.Create(dto);

            if(result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
