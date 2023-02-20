using Microsoft.AspNetCore.Mvc;
using Shop.Models.RealEstate;

namespace ShopTARgv21.Models.RealEstate
{
    public class RealEstateDeleteViewModel
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string BuildingType { get; set; }
        public double Size { get; set; }
        public int RoomNumber { get; set; }
        public int Price { get; set; }
        public string Contact { get; set; }

        public List<FileToApiViewModel> FileToApis { get; set; } = new List<FileToApiViewModel>();

        // Only in DB
        public DateTime ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
