using Microsoft.AspNetCore.Mvc;

namespace UMS.Api.Controllers.StudentRepresentative
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
