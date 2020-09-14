using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMvc.Models;
using System.Net.Http;

namespace LibraryMvc.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            IEnumerable<mvcMemberModel> authList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("members").Result;
            authList = response.Content.ReadAsAsync<IEnumerable<mvcMemberModel>>().Result;
            return View(authList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcMemberModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("members/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcMemberModel>().Result);
            }
        }


        [HttpPost]
        public ActionResult AddOrEdit(mvcMemberModel emp)
        {
            if (emp.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("members", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("members/" + emp.Id, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("members/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}