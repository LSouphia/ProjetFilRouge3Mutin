using BilbioMetierBOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MutIn.Controllers
{
    public class ContratApiController : Controller
    {
        // GET: ContratApi
        public ActionResult Index()
        {
            IEnumerable<ContratApiModel> contratlist;
            HttpResponseMessage response = GlobalVariables.WebApiClientContrat.GetAsync("Contrats").Result;
            contratlist = response.Content.ReadAsAsync<IEnumerable<ContratApiModel>>().Result;
            return View(contratlist);
        }

        public ActionResult AddOrEdit(string id = "")
        {
            if(id == "")
            return View(new ContratApiModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClientContrat.GetAsync("Contrats/"+ id).Result;
                return View(response.Content.ReadAsAsync<ContratApiModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(ContratApiModel contrat)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClientContrat.PostAsJsonAsync("Contrats", contrat).Result;
            TempData["SuccessMessage"] = "Sauvegarde effectuée !";
            return RedirectToAction("Index");
            
        }
    }
}