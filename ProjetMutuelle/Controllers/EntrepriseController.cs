using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ProjetMutuelle;
using ProjetMutuelle.DAL;
using ProjetMutuelle.Models;

namespace ProjetMutuelle.Controllers
{
    public class EntrepriseController : Controller
    {
        EntrepriseDAO dao = new EntrepriseDAO();
        Entreprise entreprise = new Entreprise();


        // GET: Entreprise
        public ActionResult Index()
        {

            return View();

        }
        public ActionResult Liste()
        {
            try
            {
                List<Entreprise> entreprises = dao.Liste();
                return View(entreprises);
            }
            catch (Exception err)
            {
                ViewBag.Message = err.Message;
                return View();
            }
        }

        // GET: Entreprise/Details/5
        public ActionResult Details(string id)
        {
            try
            {
                entreprise = dao.Fiche(id);
                return View(entreprise);
            }
            catch (Exception err)
            {
                ViewBag.Message = err.Message;
                return View();
            }
        }

        // GET: Entreprise/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entreprise/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            int n = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    if (n == 0)
                    {
                        dao.Creer(entreprise);
                        return RedirectToAction("Liste");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Impossible de créer la ligne");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Il manque des éléments");
                    return View();
                }
            }
            catch (Exception err)

            {
                ViewBag.Message = err.Message;
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        // GET: Entreprise/Edit/5
        public ActionResult Edit(int id)
        {
            return View(id);
        }

        // POST: Entreprise/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }


        }

        // GET: Entreprise/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Entreprise/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
