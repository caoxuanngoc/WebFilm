using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebFilm.Models;
using WebFilm.Models.XULY;
using PagedList;

namespace WebFilm.Controllers
{
    public class CateController : Controller
    {
        private Phim2Entities db = new Phim2Entities();

        // GET: Cate
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Category).Include(m => m.Country);
            return View(movies.ToList());
        }

        [ChildActionOnly]
        public PartialViewResult Category()
        {
            var model = new CategoryTT().ListAll();
            return PartialView(model);

        }

        [ChildActionOnly]
        public PartialViewResult Country()
        {
            var model = new CountryTT().ListAll();
            return PartialView(model);

        }
      
        public ActionResult CategoryPage(long idcate, int page = 1)
        {
            var moviDao = new MovieTT();
            var cate = new CategoryTT().ViewDetail(idcate);
            ViewBag.cate = cate;
            ViewBag.ListMovieNew = moviDao.ListMovieTop(12);
            var model = moviDao.ListByCateId(idcate);
            //var model = moviDao.ListMovieTop(12);
            return View(model.ToPagedList(page, 6));
        }

        public ActionResult CountryPage(long idcate, int page = 1)
        {
            var moviDao = new MovieTT();
            var cate = new CountryTT().ViewDetail(idcate);
            ViewBag.cate = cate;
            //  ViewBag.ListMovieNew = moviDao.ListMovieNew(12);
            var model = moviDao.ListByCateId(idcate);
            return View(model.ToPagedList(page, 6));
        }
        public PartialViewResult MenuBottom()
        {
            var model = new CategoryTT().ListAll();
            return PartialView(model);
        }

        // GET: Cate/Details/5
        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Movie movie = db.Movies.Find(id);
        //        if (movie == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(movie);
        //    }

        //    // GET: Cate/Create
        //    public ActionResult Create()
        //    {
        //        ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "NameCategory");
        //        ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "NameCountry");
        //        return View();
        //    }

        //    // POST: Cate/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "MovieID,Name,Image,Actor,Description,Directors,Time,Year,MovieLink,TrailerLink,CategoryID,Rate,TrailerID,Viewed,Status,TopHot,CountryID")] Movie movie)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Movies.Add(movie);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "NameCategory", movie.CategoryID);
        //        ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "NameCountry", movie.CountryID);
        //        return View(movie);
        //    }

        //    // GET: Cate/Edit/5
        //    public ActionResult Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Movie movie = db.Movies.Find(id);
        //        if (movie == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "NameCategory", movie.CategoryID);
        //        ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "NameCountry", movie.CountryID);
        //        return View(movie);
        //    }

        //    // POST: Cate/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "MovieID,Name,Image,Actor,Description,Directors,Time,Year,MovieLink,TrailerLink,CategoryID,Rate,TrailerID,Viewed,Status,TopHot,CountryID")] Movie movie)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(movie).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "NameCategory", movie.CategoryID);
        //        ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "NameCountry", movie.CountryID);
        //        return View(movie);
        //    }

        //    // GET: Cate/Delete/5
        //    public ActionResult Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Movie movie = db.Movies.Find(id);
        //        if (movie == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(movie);
        //    }

        //    // POST: Cate/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        Movie movie = db.Movies.Find(id);
        //        db.Movies.Remove(movie);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
    }
}
