﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Movies.Data;
using Movies.Data.Models;

namespace Movies.Web.Controllers
{
    public class MoviesController : Controller
    {
        // In my course project It will come from IoC Container the logic part will be executed in Service layer
        private MoviesDbContext db = new MoviesDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Director).Include(m => m.LeadingFemaleRole).Include(m => m.LeadingMaleRole);
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.DirectorId = new SelectList(db.People, "Id", "Name");
            ViewBag.LeadingFemaleRoleId = new SelectList(db.People, "Id", "Name");
            ViewBag.LeadingMaleRoleId = new SelectList(db.People, "Id", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Title,DirectorId,LeadingMaleRoleId,LeadingFemaleRoleId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectorId = new SelectList(db.People, "Id", "Name", movie.DirectorId);
            ViewBag.LeadingFemaleRoleId = new SelectList(db.People, "Id", "Name", movie.LeadingFemaleRoleId);
            ViewBag.LeadingMaleRoleId = new SelectList(db.People, "Id", "Name", movie.LeadingMaleRoleId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectorId = new SelectList(db.People, "Id", "Name", movie.DirectorId);
            ViewBag.LeadingFemaleRoleId = new SelectList(db.People, "Id", "Name", movie.LeadingFemaleRoleId);
            ViewBag.LeadingMaleRoleId = new SelectList(db.People, "Id", "Name", movie.LeadingMaleRoleId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Title,DirectorId,LeadingMaleRoleId,LeadingFemaleRoleId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectorId = new SelectList(db.People, "Id", "Name", movie.DirectorId);
            ViewBag.LeadingFemaleRoleId = new SelectList(db.People, "Id", "Name", movie.LeadingFemaleRoleId);
            ViewBag.LeadingMaleRoleId = new SelectList(db.People, "Id", "Name", movie.LeadingMaleRoleId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
