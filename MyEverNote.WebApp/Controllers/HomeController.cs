﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEverNote.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MyMoodNote.BusinessLayer.Test test = new MyMoodNote.BusinessLayer.Test(); 
            return View();
        }
    }
}