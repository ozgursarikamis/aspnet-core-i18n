using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using i18n.MvcImplementation.Models;

namespace i18n.MvcImplementation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View("ContactConfirmed", model.Comment);
        }

        public IActionResult Error()
        {
            return View();
            ;
            ;
        }
    }
}
