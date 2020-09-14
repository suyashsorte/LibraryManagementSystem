using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMvc.Models;
using System.Net.Http;
namespace LibraryMvc.Controllers
{
    public class AuthorController : Controller
    {
        MVCModel db = new MVCModel();
        // GET: Author
        public ActionResult Index()
        {
            IEnumerable<mvcAuthorModel> authList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("authors").Result;
            authList = response.Content.ReadAsAsync<IEnumerable<mvcAuthorModel>>().Result;
            return View(authList);
            
                       
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcAuthorModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("authors/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcAuthorModel>().Result);
            }
        }


        [HttpPost]
        public ActionResult AddOrEdit(mvcAuthorModel emp)
        {
            if (emp.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("authors", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("authors/" + emp.Id, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("authors/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}