using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using btl1.Models;
using btl1.Models.ProductModels;

namespace btl1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreAPIController : ControllerBase
    {
        QlbanKhanContext db = new QlbanKhanContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var sanPham = (from p in db.Sanphams select new Product
            {
                Masp = p.Masp,
                Tensp = p.Tensp,
                Giatien = p.Giatien,
                Anhbia = p.Anhbia,
                Mahang = p.Mahang,
                MaCl = p.MaCl
            }).ToList();
            return sanPham;
        }
        [HttpGet("{MaCl}")]
        public IEnumerable<Product> GetProductsByCategory(int maCl)
        {
            var sanPham = (from p in db.Sanphams
                where p.MaCl == maCl
                select new Product
                {
                    Masp = p.Masp,
                    Tensp = p.Tensp,
                    Giatien = p.Giatien,
                    Anhbia = p.Anhbia,
                    Mahang = p.Mahang,
                    MaCl = p.MaCl
                }).ToList();
            return sanPham;
        }
    }
}
