using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;
using ShopTARgv21.Models.Car;

namespace ShopTARgv21.Controllers
{
    public class CarController : Controller
    {
        private readonly ShopDbContext _dbContext;
        private readonly ICarServices _carServices;
        private readonly IFileServices _fileServices;

        public CarController
            (
                ShopDbContext context,
                ICarServices carServices,
                IFileServices fileServices
            )
        {
            _dbContext = context;
            _carServices = carServices;
            _fileServices = fileServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _dbContext.Car
                .OrderByDescending(y => y.Year)
                .Select(x => new CarListViewModel
                {
                    Id = x.Id,
                    Owner = x.Owner,
                    Model = x.Model,
                    Color = x.Color,
                    Year = x.Year,
                    Passengers = x.Passengers
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
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarId = x.CarId,
                }).ToArray(),
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

            var photos = await _dbContext.FileToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    ImageData = y.ImageData,
                    ImageId = y.Id,
                    Image = string.Format("data:image/gif;base64, {0}", Convert.ToBase64String(y.ImageData)),
                    ImageTitle = y.ImageTitle,
                    CarId = y.Id
                })
                .ToArrayAsync();

            var vm = new CarEditViewModel();

            vm.Id = car.Id;
            vm.Owner = car.Owner;
            vm.Model = car.Model;
            vm.Color = car.Color;
            vm.Year = car.Year;
            vm.Registration = car.Registration;
            vm.VINcode = car.VINcode;
            vm.Weight = car.Weight;
            vm.Fuel = car.Fuel;
            vm.Transmission = car.Transmission;
            vm.Additions = car.Additions;
            vm.Passengers = car.Passengers;
            vm.Image.AddRange(photos);

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarEditViewModel vm)
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
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarId = x.CarId,
                }).ToArray(),
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

            var photos = await _dbContext.FileToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    ImageData = y.ImageData,
                    ImageId = y.Id,
                    Image = string.Format("data:image/gif;base64, {0}", Convert.ToBase64String(y.ImageData)),
                    ImageTitle = y.ImageTitle,
                    CarId = y.Id
                })
                .ToArrayAsync();

            var vm = new CarViewModel();

            vm.Id = car.Id;
            vm.Owner = car.Owner;
            vm.Model = car.Model;
            vm.Color = car.Color;
            vm.Year = car.Year;
            vm.Registration = car.Registration;
            vm.VINcode = car.VINcode;
            vm.Weight = car.Weight;
            vm.Fuel = car.Fuel;
            vm.Transmission = car.Transmission;
            vm.Additions = car.Additions;
            vm.Passengers = car.Passengers;

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

        [HttpPost]
        public async Task<IActionResult> RemoveImage(ImageViewModel file)
        {
            var dto = new FileToDatabaseDto()
            {
                Id = file.ImageId
            };

            var image = await _fileServices.RemoveImage(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
