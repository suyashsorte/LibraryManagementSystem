using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using LibraryMvc.Models;
using Newtonsoft.Json;

namespace LibraryMvc.Controllers
{
    public class PublisherController : Controller
    {
        // GET: Publisher
        public ActionResult Index()
        {
            IEnumerable<mvcPublisherModel> pubList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("publishers").Result;
            //var model = JsonConvert.DeserializeObject<mvcPublisherModel>(response);
            pubList = response.Content.ReadAsAsync<IEnumerable<mvcPublisherModel>>().Result;
            return View(pubList);
            
        }


        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcPublisherModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("publishers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcPublisherModel>().Result);
            }
        }


        [HttpPost]
        public ActionResult AddOrEdit(mvcPublisherModel emp)
        {
            if (emp.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("publishers", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("publishers/" + emp.Id, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("publishers/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}