using MVCeDOCSwebServiceClient.Models;
using MVCeDOCSwebServiceClient.Services.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCeDOCSwebServiceClient.Controllers
{
    public class ContactInputController : Controller
    {



        // GET: ContactInput
        [HttpGet]
        public ActionResult Index(string currentSearchMode, string SelectedSearch)
        {
            ContactInput model = new ContactInput();
            model.currentSearchMode = currentSearchMode;
            model.SelectedSearch = SelectedSearch;
            return View(model);


            
        }
        [HttpPost]
        public ActionResult Index(ContactInput model)
        {
            string methodname = System.Reflection.MethodBase.GetCurrentMethod().Name;

            if(ModelState.IsValid)
            {

                try
                {


                    AppLogger.GetInstance().Info(model.currentSearchMode);
                    AppLogger.GetInstance().Info(model.SelectedSearch);
                    AppLogger.GetInstance().Info(model.ContactName);
                    AppLogger.GetInstance().Info(model.ContactEmail);
                    AppLogger.GetInstance().Info(model.Subject);
                    AppLogger.GetInstance().Info(model.Message);


                    return RedirectToAction("ThankYou");
                }
                catch (Exception ex)
                {
                    AppLogger.GetInstance().Error(methodname + ": " + ex.Message);                    
                    return RedirectToAction("Sorry");
                }


            }
            else
            {
                return View(model);
            }
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult Sorry()
        {
            return View();
        }
    }
}