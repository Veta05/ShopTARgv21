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
                {
                    Id = x.Id,
                    Address = x.Address,
                    City = x.City,
                    Contact = x.Contact,
                    Size = x.Size,
                    Price = x.Price,
                    RoomNumber = x.RoomNumber,
                    BuildingType = x.BuildingType,
                });
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
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _realEstateServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateCreateUpdateViewModel()
            {
                Id = realEstate.Id,
                Address = realEstate.Address,
                City = realEstate.City,
                County = realEstate.County,
                BuildingType = realEstate.BuildingType,
                Size = realEstate.Size,
                RoomNumber = realEstate.RoomNumber,
                Price = realEstate.Price,
                Contact = realEstate.Contact,
                CreatedAt = realEstate.CreatedAt,
                ModifiedAt = realEstate.ModifiedAt

            };

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
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
                RoomNumber = vm.RoomNumber
            };

            var result = await _realEstateServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

    }
}


//        [HttpGet]
//        public async Task<IActionResult> Delete(Guid id)
//        {
//            var car = await _realEstateServices.GetAsync(id);

//            if (car == null)
//            {
//                return NotFound();
//            }

//            var vm = new RealEstateListViewModel()
//            {
//                Id = realEstate.Id,
//                Address = realEstate.Address,
//                City = realEstate.City,
//                County = realEstate.County,
//                BuildingType = realEstate.BuildingType,
//                Size = realEstate.Size,
//                RoomNumber = realEstate.RoomNumber,
//                Price = realEstate.Price,
//                Contact = realEstate.Contact,
//                CreatedAt = realEstate.CreatedAt,
//                ModifiedAt = realEstate.ModifiedAt
//            };

//            return View(vm);
//        }

//        [HttpPost]
//        public async Task<IActionResult> DeleteConfirmation(Guid id)
//        {
//            var product = await _realEstateServices.Delete(id);

//            if (product == null)
//            {
//                return RedirectToAction(nameof(Index));
//            }

//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
