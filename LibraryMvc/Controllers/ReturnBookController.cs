using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMvc.Models;
using System.Data.Entity.SqlServer;
namespace LibraryMvc.Controllers
{
    public class ReturnBookController : Controller
    {
        MVCModel db = new MVCModel();
        // GET: ReturnBook
        public ActionResult Index()
        {
            return View();
        }


        // POST: ReturnBook

        public ActionResult GetMid(int mid)
        {
            //var memberid = (from s in db.issuebooks
            //                where s.MemberId == mid
            //                select new
            //                {
            //                    IssueDate = s.IssueDate,
            //                    ReturnDate = s.ReturnDate,
            //                    Memberid = s.MemberId,
            //                    BookName = s.BookName,
            //                    ElapseDays = SqlFunctions.DateDiff("day", s.ReturnDate, DateTime.Now)
            //                }).ToArray();
            var memberid = (from s in db.issuebooks
                            where s.MemberId == mid
                            
                            select new
                            {
                                IssueDate = s.IssueDate,
                                ReturnDate = s.ReturnDate,
                                Memberid = s.MemberId,
                                BookName = s.BookName,
                                ElapseDays = SqlFunctions.DateDiff("day", s.ReturnDate, DateTime.Now)
                            }).ToArray();

            //var data = db.issuebooks.SqlQuery("select BookName from issuebook ib right join returnbook rb on rb.Book != ib.BookName where ib.MemberId = 1 ").ToArray();
            return Json(memberid, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(returnbook returns)
        {

            if (ModelState.IsValid)
            {
                db.returnbooks.Add(returns);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Book is returned successfully";
                return RedirectToAction("Index");
            }
            return View(returns);
            
        }
    }
}