using MVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC2.Controllers
{
    public class FutbolistasController : Controller
    {
        // GET: Futbolistas
        public ActionResult Index()
        {
            IEnumerable<mvcFutbolistasmodel> empList;
            HttpResponseMessage response = GlobalVariables.WedApiClient.GetAsync("Futbolistas").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcFutbolistasmodel>>().Result;
            return View(empList);
            
        }


        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcFutbolistasmodel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WedApiClient.GetAsync("Futbolistas/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcFutbolistasmodel>().Result);
            }
        }
        [HttpPost]

        public ActionResult AddOrEdit(mvcFutbolistasmodel emp)
        {
            if (emp.id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WedApiClient.PostAsJsonAsync("Futbolistas", emp).Result;
                TempData["SuccesMessage"] = "Saved Succesfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WedApiClient.PutAsJsonAsync("Futbolistas/" + emp.id, emp).Result;
                TempData["SuccesMessage"] = "Update Succesfully";

            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WedApiClient.DeleteAsync("Futbolistas/" + id.ToString()).Result;
            TempData["SuccesMessage"] = "Delete Succesfully";
            return RedirectToAction("Index");
        }

    }
    }
