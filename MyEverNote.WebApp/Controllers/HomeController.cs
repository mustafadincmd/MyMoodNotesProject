﻿using MyMoodNote.BusinessLayer;
using MyMoodNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyEverNote.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {


            NoteManager nm = new NoteManager(); 
            return View(nm.GetAllNote());


        }



        // GET: Category
        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }


            CategoryManager cm = new CategoryManager();
            Category cat = cm.GetCategoryById(id.Value);

            if (cat == null)
            {
                return HttpNotFound();
                //    return RedirectToAction("Index", "Home");
            }

            return View("Index", cat.Notes);
        }
    }
}