using Microsoft.AspNetCore.Mvc;

namespace CustomConfiguration_Section.Controllers
{
    public class PersonController : Controller
    {
        private PersonService _service;

        public PersonController(PersonService service)
        {
            _service = service;
        }

        //Method 1
        public IActionResult Index()
        {
            var dataResult = _service.GetPersonEmail();
            var dataResult_1 = _service.GetPersonEmail_1();
            ViewBag.Email = dataResult;
            ViewBag.UserEmail = dataResult_1;
            return View();
        }

        //https://www.c-sharpcorner.com/article/reading-values-from-appsettings-json-in-asp-net-core/
    }
}
