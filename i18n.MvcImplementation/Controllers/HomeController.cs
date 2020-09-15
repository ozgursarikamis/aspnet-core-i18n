using Microsoft.AspNetCore.Mvc;
using i18n.MvcImplementation.Models;

namespace i18n.MvcImplementation.Controllers
{
    public class HomeController : Controller
    { 
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Contact(ContactModel model)
        {
            return !ModelState.IsValid ? View(model) : View("ContactConfirmed", model.Comment);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
