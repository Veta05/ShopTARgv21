namespace ShopTARgv21.Models.Car
{
    public class CarEditViewModel
    {
        public Guid? Id { get; set; }
        public string Owner { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public DateTime Year { get; set; }
        public DateTime Registration { get; set; }
        public string VINcode { get; set; }
        public int Weight { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public string Additions { get; set; }
        public int Passengers { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> Image { get; set; } = new List<ImageViewModel>();
    }
}
