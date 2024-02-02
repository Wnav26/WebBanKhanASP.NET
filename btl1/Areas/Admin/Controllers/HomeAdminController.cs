using btl1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace btl1.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlbanKhanContext db=new QlbanKhanContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("danhmucsanpham")]
		public IActionResult DanhMucSanPham(int? page)
		{
			int pageSize = 10;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var lstsanpham = db.Sanphams.AsNoTracking().OrderBy(x => x.Tensp);
			PagedList<Sanpham> lst = new PagedList<Sanpham>(lstsanpham, pageNumber, pageSize);
			return View(lst);
		}

		[Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.Mahang = new SelectList(db.Hangsanxuats.ToList(),"Mahang", "Tenhang");
            ViewBag.MaCl = new SelectList(db.ChatLieus.ToList(), "MaCl", "TenCl");
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(Sanpham sanpham)
        {
            if(ModelState.IsValid)
            {
                db.Sanphams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View();
        }
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(int Masp)
        {
            ViewBag.Mahang = new SelectList(db.Hangsanxuats.ToList(), "Mahang", "Tenhang");
            ViewBag.MaCl = new SelectList(db.ChatLieus.ToList(), "MaCl", "TenCl");
            var sanpham = db.Sanphams.Find(Masp);
            return View(sanpham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham","HomeAdmin");
            }
            return View(sanpham);
        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(int Masp)
        {
            TempData["Message"] = "";
            var Chitietdonhang = db.Chitietdonhangs.Where(x=>x.Masp == Masp).ToList();
            if(Chitietdonhang.Count() > 0)
            {
                TempData["Message"] = "Can not delete this product";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            var AnhSP=db.AnhSps.Where(x=>x.Masp==Masp);
            if (AnhSP.Any()) db.RemoveRange(AnhSP);
            db.Remove(db.Sanphams.Find(Masp));
            db.SaveChanges();
            TempData["Message"] = "Delete!";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }
    }
}
