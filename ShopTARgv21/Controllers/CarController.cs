using Microsoft.AspNetCore.Mvc;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;
using ShopTARgv21.Models.Car;

namespace ShopTARgv21.Controllers
{
    public class CarController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly ICarServices _carServices;

        public CarController
            (
                ShopDbContext context,
                ICarServices carServices
            )
        {
            _context = context;
            _carServices = carServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Car
                .OrderByDescending(y => y.Year)
                .Select(x => new CarListViewModel
                {
                    Id = x.Id,
                    Owner = x.Owner,
                    Model = x.Model,
                    Color = x.Color,
                    Year = x.Year,
                    Passangers = x.Passangers
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarEditViewModel car = new CarEditViewModel();

            return View("CreateUpdate", car);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Owner = vm.Owner,
                Model = vm.Model,
                Color = vm.Color,
                Year = vm.Year,
                Registration = vm.Registration,
                VINcode = vm.VINcode,
                Weight = vm.Weight,
                Fuel = vm.Fuel,
                Transmission = vm.Transmission,
                Additions = vm.Additions,
                Passengers = vm.Passengers,
                Files = vm.Files,
            };

            var result = await _carServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new carEditViewModel()
            {
                Id = car.Id,
                Owner = car.Owner,
                Model = car.Model,
                Color = car.Color,
                Year = car.Year,
                Registration = car.Registration,
                VINcode = car.VINcode,
                Weight = car.Weight,
                Fuel = car.Fuel,
                Transmission = car.Transmission,
                Additions = car.Additions,
                Passengers = car.Passengers,
            };

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarEditViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = car.Id,
                Owner = car.Owner,
                Model = car.Model,
                Color = car.Color,
                Year = car.Year,
                Registration = car.Registration,
                VINcode = car.VINcode,
                Weight = car.Weight,
                Fuel = car.Fuel,
                Transmission = car.Transmission,
                Additions = car.Additions,
                Passengers = car.Passengers,
            };

            var result = await _carServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarViewModel()
            {
                Id = car.Id,
                Owner = car.Owner,
                Model = car.Model,
                Color = car.Color,
                Year = car.Year,
                Registration = car.Registration,
                VINcode = car.VINcode,
                Weight = car.Weight,
                Fuel = car.Fuel,
                Transmission = car.Transmission,
                Additions = car.Additions,
                Passengers = car.Passengers,
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var product = await _carServices.Delete(id);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
