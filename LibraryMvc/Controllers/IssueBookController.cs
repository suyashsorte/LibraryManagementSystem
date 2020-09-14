using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMvc.Models;
namespace LibraryMvc.Controllers
{
    public class IssueBookController : Controller
    {

        MVCModel db = new MVCModel();
        // GET: IssueBook
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetMid(int mid)
        {


            var memberid = (from s in db.members where s.Id == mid select s.Name).ToList();

            return Json(memberid,JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetBook()
        {


            var books = db.books.Select(p=>new { 
                Id = p.Id,
                Bname = p.BookName
            
            }).ToList();

            return Json(books, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Save(issuebook issue)
        {
            if (ModelState.IsValid) 
            {
                db.issuebooks.Add(issue);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Added to the database";
                return RedirectToAction("Index");
            }
            return View(issue);
            
            
        }
    }
}