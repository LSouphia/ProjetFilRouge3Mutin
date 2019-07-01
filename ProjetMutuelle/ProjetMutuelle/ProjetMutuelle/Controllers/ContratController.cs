using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ProjetMutuelle;
using ProjetMutuelle.DAL;
using ProjetMutuelle.Models;

namespace ProjetMutuelle.Controllers
{
    public class ContratController : Controller
    {
        ContratDAO dao = new ContratDAO();
        StatutDAO daostatut = new StatutDAO();
        Contrat contrat = new Contrat();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            List<Contrat> contrat1;
            if (string.IsNullOrEmpty(search))
            {
            }
            else
            {
            }
            return View();
            //allsearch = mStatut.Statut.Where(x => x.LibelleStatut.Contains(search)).Select(x => new StatutContratModel
            //{
            //    IDStatut = x.IDStatut,
            //    LibelleStatut = x.LibelleStatut,
            //}).ToList();
            //return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public ActionResult ListeContrat()
        {
            try
            {
                List<Contrat> contratList = dao.ListeContrat();
                return View(contratList);
            }
            catch (Exception err)
            {
                ViewBag.Message = err.Message;
                return View();
            }
                 
        }

        // GET: Contrat/Details/5
        public ActionResult Details(string id)
        {
            try
            {
                contrat = dao.FicheContrat(id);
                return View(contrat);
            }
            catch (Exception err)
            {
                ViewBag.Message = err.Message;
                return View();
            }
       
        }

        // GET: Contrat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contrat/Create
        [HttpPost]
        public ActionResult Create(Contrat contrat)
        {
            try
            {
                dao.CreationContrat(contrat);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            contrat = dao.Lecture(id);
            return View(contrat);
        }

        // POST: Contrat/Edit/5
        [HttpPost]
        public ActionResult Edit(string code, Contrat contrat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dao.ModifierContrat(code, contrat);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "veuillez revoir votre saisie et coriger les champs indiqué en rouge");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Contrat/Delete/5
        public ActionResult Delete(string id)
        {
            return View(dao.Lecture(id));
        }

        // POST: Contrat/Delete/5
        [HttpPost]
        public ActionResult Delete(string code, Contrat contrat)
        {
            try
            {
                dao.SupressionContrat(code);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
