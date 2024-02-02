using btl1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace btl1.Controllers
{
    public class StoreController : Controller
    {
		QlbanKhanContext db = new QlbanKhanContext();
		public IActionResult Index(int? page)
        {
			int pageSize = 6;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var lstsanpham = db.Sanphams.AsNoTracking().OrderBy(x => x.Tensp);
			PagedList<Sanpham> lst = new PagedList<Sanpham>(lstsanpham, pageNumber, pageSize);
			return View(lst);
		}
		public IActionResult SanPhamTheoChatLieu(int maCl, int? page)
		{
			int pageSize = 6;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var lstsanpham = db.Sanphams.AsNoTracking().Where(x => x.MaCl == maCl).OrderBy(x => x.Tensp);
			PagedList<Sanpham> lst = new PagedList<Sanpham>(lstsanpham, pageNumber, pageSize);
			ViewBag.MaCl = maCl;
			return View(lst);
		}
		public IActionResult SanPhamTheoBrand(int maHang, int? page) 
		{

			int pageSize = 6;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var lstsanpham = db.Sanphams.AsNoTracking().Where(x => x.Mahang == maHang).OrderBy(x => x.Tensp);
			PagedList<Sanpham> lst = new PagedList<Sanpham>(lstsanpham, pageNumber, pageSize);
			ViewBag.Mahang = maHang;
			return View(lst);
		}
		public IActionResult Search(string tensp)
		{
			List<Sanpham> lst = db.Sanphams.Where(x => x.Tensp.Contains(tensp)).ToList();
			return View(lst);
		}
    }
}
