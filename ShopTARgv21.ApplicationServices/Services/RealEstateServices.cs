using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.ApplicationServices.Services
{
    public class RealEstateServices : IRealEstateServices
    {
        private readonly ShopDbContext _context;
        public RealEstateServices(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new RealEstate();

            realEstate.Id = Guid.NewGuid();
            realEstate.Address = dto.Address;
            realEstate.City = dto.City;
            realEstate.Price = dto.Price;
            realEstate.Contact = dto.Contact;
            realEstate.BuildingType = dto.BuildingType;
            realEstate.RoomNumber = dto.RoomNumber;
            realEstate.County = dto.County;
            realEstate.Size = dto.Size;
            realEstate.CreatedAt = dto.CreatedAt;
            realEstate.ModifiedAt = dto.ModifiedAt;

            await _context.RealEstate.AddAsync(realEstate);
            await _context.SaveChangesAsync();
            return realEstate;
        }
    }
}
