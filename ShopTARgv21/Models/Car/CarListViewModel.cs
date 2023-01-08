using Microsoft.AspNetCore.Mvc;

namespace ShopTARgv21.Models.Car
{
    public class CarListViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
