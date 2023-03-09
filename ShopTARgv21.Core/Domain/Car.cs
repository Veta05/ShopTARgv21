﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace ShopTARgv21.Core.Domain
{
    public class Car
    {
        [Key]
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
        public IEnumerable<FileToDatabase> FileToDatabases { get; set; } = new List<FileToDatabase>();
    }
}