using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BiblioMetierDLL;
using ProjetMutuelle;
using ProjetMutuelle.DAL;

namespace ProjetMutuelle.Controllers
{
    public class EntrepriseController : Controller
    {
        EntrepriseDAO dao = new EntrepriseDAO();
        EntrepriseMere entreprise = new EntrepriseMere();
       


        // GET: Entreprise
        public ActionResult Index()
        {

            return View();

        }
        public ActionResult Liste()
        {
            try
            {
                List<EntrepriseMere> entreprises = dao.Liste();
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
        public ActionResult Create(EntrepriseMere entreprise)
        {
            try
            {
                dao.Creer(entreprise);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
