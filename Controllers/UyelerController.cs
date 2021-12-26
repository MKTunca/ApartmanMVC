using ApartmanProjeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApartmanProjeMVC.Controllers
{
    
    public class UyelerController : Controller
    {
        ApartmanYonetimEntities baglan = new ApartmanYonetimEntities();
        public ActionResult Liste()
        {
            try
            {
                ViewBag.uyarTXT = Session["uyari"];
            }
            catch
            { Session["uyari"] = ""; }
            List<object> otur = new List<object>();

            otur.Add(new SelectListItem { Text = "Ev Sahibi", Value = "Ev Sahibi" });
            otur.Add(new SelectListItem { Text = "Kiracı", Value = "Kiracı" });

            ViewBag.oturan = otur;
            var model = baglan.Uyeler.ToList();
            return View(model);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Uyeler ekle)
        {
            if ((ekle.Ad != null) && (ekle.gsm != null))
            {
                baglan.Uyeler.Add(ekle);
                baglan.SaveChanges();
                Session["uyari"] = "Bilgileriniz kaydedildi.";
            }
            else
            {
                Session["uyari"] = "Gerekli alanları doldurunuz ";
            }
            return RedirectToAction("Liste");
        }
        [HttpPost]
        public JsonResult Degisim(Uyeler uyedeg)
        {

            var degisim = baglan.Uyeler.Find(uyedeg.ID);
            degisim.Ad = uyedeg.Ad;
            degisim.Daire = uyedeg.Daire;
            if (uyedeg.Oturan != null)
            { degisim.Oturan = uyedeg.Oturan; }
            degisim.gsm = uyedeg.gsm;
            degisim.tarih = uyedeg.tarih;

            baglan.SaveChanges();
            return Json("Bilgileriniz güncellendi", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Sil(int id)
        {

            var silinecek = baglan.Uyeler.Find(id);
            baglan.Uyeler.Remove(silinecek);

            baglan.SaveChanges();
            return Json("Silme işlemi tamamlandı.", JsonRequestBehavior.AllowGet);
        }

    }
}