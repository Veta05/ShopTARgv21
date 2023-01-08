using Microsoft.AspNetCore.Mvc;

namespace ShopTARgv21.Models.Car
{
    public class CarViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
