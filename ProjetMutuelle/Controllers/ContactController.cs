//using System;
//using System.Collections.Generic;
//using System.Web.Mvc;
//using ProjetMutuelle;
//using ProjetMutuelle.DAL;
//using ProjetMutuelle.Models;


//namespace ProjetMutuelle.Controllers
//{
//    public class ContactController : Controller
//    {
//        ContactDAO dao = new ContactDAO();
//        Contact contact = new Contact();

//        // GET: Contact
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult Liste()
//        {
//            try
//            {
//                List<Contact> contact = dao.Liste();
//                return View(contact);
//            }
//            catch (Exception err)
//            {
//                ViewBag.Message = err.Message;
//                return View();
//            }
//        }

//        // GET: Contact/Details/5
//        public ActionResult Details(string id)
//        {
//            contact = dao.Fiche(id);
//            return View(contact);
//        }

//        // GET: Contact/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Contact/Create
//        [HttpPost]
//        public ActionResult Create(FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add insert logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Contact/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: Contact/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Contact/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Contact/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
