using MVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC2.Controllers
{
    public class EntrenadorController : Controller
    {
        // GET: Entrenador
        public ActionResult Index()
        {
            IEnumerable<mvcEntrenadormodel> empList;
            HttpResponseMessage response = GlobalVariables.WedApiClient.GetAsync("Entrenador").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcEntrenadormodel>>().Result;
            return View(empList);


        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcEntrenadormodel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WedApiClient.GetAsync("Entrenador/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcEntrenadormodel>().Result);
            }
        }
        [HttpPost]

        public ActionResult AddOrEdit(mvcEntrenadormodel emp)
        {
            if (emp.id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WedApiClient.PostAsJsonAsync("Entrenador", emp).Result;
                TempData["SuccesMessage"] = "Saved Succesfully";
            }
            else
            {

                HttpResponseMessage response = GlobalVariables.WedApiClient.PutAsJsonAsync("Entrenador/" + emp.id, emp).Result;
                TempData["SuccesMessage"] = "Update Succesfully";
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WedApiClient.DeleteAsync("Entrenador/" + id.ToString()).Result;
            TempData["SuccesMessage"] = "Delete Succesfully";
            return RedirectToAction("Index");
        }

    }
    }
