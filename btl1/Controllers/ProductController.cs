using btl1.Models;
using btl1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace btl1.Controllers
{
	public class ProductController : Controller
	{
		QlbanKhanContext db = new QlbanKhanContext();
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ChiTietSP(int maSp)
		{
			var sanPham = db.Sanphams.SingleOrDefault(x => x.Masp == maSp);
			var lstsanpham = db.Sanphams.Where(x => x.MaCl == sanPham.MaCl).ToList();
			var anhSanPham = db.AnhSps.Where(x => x.Masp == maSp).ToList();
			ChatLieu chatLieu = db.ChatLieus.SingleOrDefault(x => x.MaCl == sanPham.MaCl);
			Hangsanxuat hang = db.Hangsanxuats.SingleOrDefault(x => x.Mahang == sanPham.Mahang);
			var homeProductDetailViewModel = new HomeProductDetailViewModel(sanPham, anhSanPham, lstsanpham, chatLieu, hang);
            return View(homeProductDetailViewModel);
		}
	}
}
