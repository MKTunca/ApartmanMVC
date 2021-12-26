using ApartmanProjeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApartmanProjeMVC.Controllers
{
    public class SettingController : Controller
    {
        ApartmanYonetimEntities baglan = new ApartmanYonetimEntities();
        public ActionResult Ayarlar()
        {
            var model = baglan.Setting.ToList();
            return View(model);
        }
        [HttpPost]
        public JsonResult Degisim(Setting aidat)
        {

            var degisim = baglan.Setting.Find(aidat.ID);
            degisim.aidatTutari = aidat.aidatTutari;


            baglan.SaveChanges();
            return Json("Bilgileriniz güncellendi", JsonRequestBehavior.AllowGet);
        }
    }
}