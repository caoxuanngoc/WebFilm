using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFilm.Controllers
{
    public class SeriesController : Controller
    {
        // GET: Series
        public ActionResult Index()
        {
            return View();
        }
    }
}