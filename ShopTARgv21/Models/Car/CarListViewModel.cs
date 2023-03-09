﻿namespace ShopTARgv21.Models.Car
{
    public class CarListViewModel
    {
        public Guid? Id { get; set; }
        public string Owner { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public DateTime Year { get; set; }
        public int Passengers { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> Image { get; set; } = new List<ImageViewModel>();
    }
}