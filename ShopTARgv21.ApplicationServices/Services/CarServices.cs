using Microsoft.EntityFrameworkCore;
using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;
using System.Reflection.Metadata.Ecma335;

namespace ShopTARgv21.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly ShopDbContext _dbContext;
        private readonly IFileServices _files;

        public CarServices
            (
                ShopDbContext context,
                IFileServices files
            )
        {
            _dbContext = context;
            _files = files;
        }

        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car();
            FileToDatabase file = new FileToDatabase();

            car.Id = Guid.NewGuid();
            car.Owner = dto.Owner;
            car.Model = dto.Model;
            car.Color = dto.Color;
            car.Year = dto.Year;
            car.Registration = dto.Registration;
            car.VINcode = dto.VINcode;
            car.Weight = dto.Weight;
            car.Fuel = dto.Fuel;
            car.Transmission = dto.Transmission;
            car.Additions = dto.Additions;
            car.Passengers = dto.Passengers;

            if (dto.Files != null)
            {
                _files.UploadFilesToDatabase(dto, car);
            }

            await _dbContext.Car.AddAsync(car);
            await _dbContext.SaveChangesAsync();

            return car;
        }

        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _dbContext.Car
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Car> Update(CarDto dto)
        {
            FileToDatabase file = new FileToDatabase();

            var car = new Car()
            {
                Id = dto.Id,
                Owner = dto.Owner,
                Model = dto.Model,
                Color = dto.Color,
                Year = dto.Year,
                Registration = dto.Registration,
                VINcode = dto.VINcode,
                Weight = dto.Weight,
                Fuel = dto.Fuel,
                Transmission = dto.Transmission,
                Additions = dto.Additions,
                Passengers = dto.Passengers
            };

            if (dto.Files != null)
            {
                _files.UploadFilesToDatabase(dto, car);
            }

            _dbContext.Car.Update(car);
            await _dbContext.SaveChangesAsync();
            return car;
        }

        public async Task<Car> Delete(Guid id)
        {
            var carId = await _dbContext.Car
                .Include(x => x.FileToDatabases)
                .FirstOrDefaultAsync(x => x.Id == id);

            var photos = await _dbContext.FileToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new FileToDatabaseDto
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    CarId = y.CarId
                })
                .ToArrayAsync();

            await _files.RemoveImagesFromDatabase(photos);
            _dbContext.Car.Remove(carId);
            await _dbContext.SaveChangesAsync();

            return carId;
        }
    }
}
