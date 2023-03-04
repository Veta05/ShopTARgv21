using System.ComponentModel.DataAnnotations;

namespace ShopTARgv21.Models.WeatherForecast
{
    public class SearchCityViewModel
    {
        [Required(ErrorMessage = "You must enter a city name!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text allowed!")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }
    }
}
