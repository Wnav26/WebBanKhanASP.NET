using btl1.Models;
using btl1.Repository;
using Microsoft.AspNetCore.Mvc;
namespace btl1.ViewComponents
{
    public class BrandViewComponent : ViewComponent
    {
        private readonly IBrandRepository _brand;
        public BrandViewComponent(IBrandRepository brand)
        {
            _brand = brand;
        }
        public IViewComponentResult Invoke()
        {
            var brand = _brand.GetAllBrand();
            return View(brand); 
        }
    }
}
