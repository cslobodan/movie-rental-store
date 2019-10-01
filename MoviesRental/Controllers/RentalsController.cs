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
    }
}