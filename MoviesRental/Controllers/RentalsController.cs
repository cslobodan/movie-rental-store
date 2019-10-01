using System.Web.Mvc;

namespace MoviesRental.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals/New
        public ActionResult New()
        {
            return View();
        }

        // GET: Rentals/Return
        public ActionResult Return()
        {
            return View();
        }
    }
}