using System.Web.Mvc;
using PicturesGallery.Models;

namespace PicturesGallery.Controllers
{
    public class HomeController : Controller
    {
        PictureContext dataBase = new PictureContext();

        public ActionResult Index()
        {
            return View(dataBase.Pictures);
        }

        protected override void Dispose(bool disposing)
        {
            dataBase.Dispose();
            base.Dispose(disposing);
        }
    }
}