using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using ProjetMutuelle;
using BiblioMetierDAL.DAL;
using BiblioMetierBOL;

namespace ProjetMutuelle.Controllers
{
    public class EntrepriseController : Controller
    {
        EntrepriseDAO dao = new EntrepriseDAO();
        EntrepriseMere entreprise = new EntrepriseMere();

        ModelEf mStatut = new ModelEf();

        // GET: Entreprise
        public ActionResult Index()
        {
            return View(mStatut.EntrepriseMeres.ToList());
        }
        public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        {
            List<EntrepriseMere> entreprises = new List<EntrepriseMere>();
            if (SearchBy == "ID")
            {
                try
                {
                    string Id = SearchValue.ToString();
                    entreprises = mStatut.EntrepriseMeres.Where(x => x.IDEntreprise == Id || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} Is Not A ID ", SearchValue);
                }
                return Json(entreprises, JsonRequestBehavior.AllowGet);
            }
            else
            {
                entreprises = mStatut.EntrepriseMeres.Where(x => x.DesignationEntreprise.StartsWith(SearchValue) || SearchValue == null).ToList();
                return Json(entreprises, JsonRequestBehavior.AllowGet);
            }
        }


        //public ActionResult Liste()
        //{
        //    try
        //    {
        //        List<EntrepriseMere> entreprises = dao.Liste();
        //        return View(entreprises);
        //    }
        //    catch (Exception err)
        //    {
        //        ViewBag.Message = err.Message;
        //        return View();
        //    }
        //}

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
        public ActionResult Edit(string id)
        {
            entreprise = dao.Fiche(id);
            return View(entreprise);
        }

        // POST: Entreprise/Edit/5
        [HttpPost]
        public ActionResult Edit(EntrepriseMere entreprise)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dao.Modifier(entreprise);
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

        // GET: Entreprise/Delete/5
        public ActionResult Delete(string id)
        {
            return View(dao.Fiche(id));
        }

        // POST: Entreprise/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, EntrepriseMere entreprise)
        {
            try
            {
                dao.Supprimer(id);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}

