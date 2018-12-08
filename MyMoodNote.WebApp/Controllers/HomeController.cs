using MyMoodNote.BusinessLayer;
using MyMoodNote.Entities;
using MyMoodNote.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyMoodNote.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {


            NoteManager nm = new NoteManager(); 
            return View(nm.GetAllNote().OrderByDescending(x=> x.ModifiedOn).ToList());


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

            return View("Index", cat.Notes.OrderByDescending(x => x.ModifiedOn).ToList());
        }

        public ActionResult MostLiked()
        {

            NoteManager nm = new NoteManager();
            return View("Index",nm.GetAllNote().OrderByDescending(x => x.LikeCount).ToList());

        }

        public ActionResult About()
        {
            return View(); 

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {//Giriş Kontrolü ve Yönlendirme 
            //Session'a kullanıcı bilgisi saklama
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterViewModel model)

        {

            if (ModelState.IsValid)
            {
                MyMoodNoteUserManager num = new MyMoodNoteUserManager();
                BusinessLayerResult<NoteUser> res = num.RegisterUser(model);

                if (res.Errors.Count>0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);

                }



                //NoteUser user = null;

                //try
                //{
                //    num.RegisterUser(model);

                //}
                //catch (Exception ex)
                //{
                //    ModelState.AddModelError("", ex.Message);

                //}


                // model geçerli mi değil mi ? 

                /*  bool hasError = false;

                  {
                      if (model.Username == "aaa")
                      {

                          ModelState.AddModelError("", "Kullanıcı adı kullanılıyor.");
                          hasError = true;

                      }

                      if (model.Email== "aaa@aa.com")
                      {

                          ModelState.AddModelError("", "Eposta adresi kullanılıyor.");
                          hasError = true;

                      }
                      if (hasError)

                  }*/
                //if (User == null)
                //{
                //    return View(model);

                ////}
                return RedirectToAction("RegisterOk");

            }
            return View(model);

        }



        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterOk()
        {
            return View();
        }




        public ActionResult UserActivate(Guid activate_id)
        {
            //kullanıcı aktivasyonu sağlanacak
            return View();
        }


    }
}