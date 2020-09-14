using LibraryMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
namespace LibraryMvc.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {

            IEnumerable<mvcCategoryModel> catList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("categories").Result;
            catList = response.Content.ReadAsAsync<IEnumerable<mvcCategoryModel>>().Result;
            return View(catList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcCategoryModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("categories/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcCategoryModel>().Result);
            }
        }


        [HttpPost]
        public ActionResult AddOrEdit(mvcCategoryModel emp)
        {
            if (emp.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("categories", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("categories/" + emp.Id, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("categories/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}