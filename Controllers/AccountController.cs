using Microsoft.AspNetCore.Mvc;

namespace WebCustomMiddleware.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("[action]")]
        public IActionResult Login()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                Request.Headers.Add("Authorization", "Mykey");
            return Redirect("/Home/Index");
        }
    }
}
