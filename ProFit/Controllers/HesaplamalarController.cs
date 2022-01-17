using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProFit.Controllers
{
    
    public class HesaplamalarController : Controller
    {
        // GET: Hesaplamalar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VKIHesaplama()
        {
            return View();
        }
        public ActionResult KaloriHesaplama()
        {
            return View();
        }
        public ActionResult Quiz()
        {
            return View();
        }

    }
}