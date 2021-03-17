using System.Web.Mvc;

namespace FA.BookStore.WebMvc.Controllers
{
    public class DemoController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}