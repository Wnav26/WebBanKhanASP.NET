using Microsoft.AspNetCore.Mvc;
using btl1.Models;
namespace btl1.Controllers
{
    public class AccessController : Controller
    {
        QlbanKhanContext db=new QlbanKhanContext();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
        [HttpPost]
        public IActionResult Login(Nguoidung user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u=db.Nguoidungs.Where(x=>x.Email.Equals(user.Email) && x.Matkhau.Equals(user.Matkhau)).FirstOrDefault();
                if (u != null && u.Idquyen == 2)
                {
                    HttpContext.Session.SetString("UserName", u.Email.ToString());
                    return RedirectToAction( "Index", "Admin");
                }
                else if(u != null && u.Idquyen == 1)
                {
					HttpContext.Session.SetString("UserName", u.Email.ToString());
					return RedirectToAction( "Index", "Home");

				}
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Access");
        }
    }
}
