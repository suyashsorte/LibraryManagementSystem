using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryMvc.Models;

namespace LibraryMvc.Controllers
{
    public class BookController : Controller
    {
        private MVCModel db = new MVCModel();
        
        

        // GET: Book
        public ActionResult Index()
        {
            var books = db.books.Include(b => b.author).Include(b => b.category).Include(b => b.publisher);
            return View(books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.authors, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.categories, "Id", "CategoryName");
            ViewBag.PublisherId = new SelectList(db.publishers, "Id", "Name");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookName,CategoryId,AuthorId,PublisherId,Contents,Pages,Edition")] book book)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(book);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Created Successfully";
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.authors, "Id", "Name", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.categories, "Id", "CategoryName", book.CategoryId);
            ViewBag.PublisherId = new SelectList(db.publishers, "Id", "Name", book.PublisherId);
            //TempData["SuccessMessage"] = "Saved Successfully";
            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.authors, "Id", "Name", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.categories, "Id", "CategoryName", book.CategoryId);
            ViewBag.PublisherId = new SelectList(db.publishers, "Id", "Name", book.PublisherId);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookName,CategoryId,AuthorId,PublisherId,Contents,Pages,Edition")] book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Saved Successfully";
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.authors, "Id", "Name", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.categories, "Id", "CategoryName", book.CategoryId);
            ViewBag.PublisherId = new SelectList(db.publishers, "Id", "Name", book.PublisherId);
            //TempData["SuccessMessage"] = "Saved Successfully";
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book book = db.books.Find(id);
            db.books.Remove(book);
            db.SaveChanges();
            TempData["SuccessMessage"] = "Deleted Successfully";
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
