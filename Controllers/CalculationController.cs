using ApartmanProjeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApartmanProjeMVC.Controllers
{
    public class CalculationController : Controller
    {
        public ViewResult IslemTablo(string search)
        {

            using (ApartmanYonetimEntities baglan = new ApartmanYonetimEntities())
            {
                List<Uyeler> uyeler = baglan.Uyeler.ToList();
                List<Islemler> islemler = baglan.Islemler.ToList();

                var islemKayit = from e in islemler

                                 join d in uyeler on e.UyeId equals d.ID into table1
                                 from d in table1.ToList()

                                 select new ViewModel
                                 {
                                     islemler = e,
                                     uyeler = d,

                                 };

                var uyeTablo = uyeler;
                var islemTablo = islemler;
                ViewBag.uyeler = uyeTablo;
                ViewBag.islemler = islemTablo;
                Int32 uyeID = uyeTablo[0].ID;
                Int32 islemID = islemTablo[0].id;
                if (!String.IsNullOrEmpty(search))
                {
                    islemKayit = islemKayit.Where(s => s.islemler.UyeId == Convert.ToInt32(search));

                }
                
                return View(islemKayit);
            }
        }

        public ActionResult IslemEkle()
        {
            using (ApartmanYonetimEntities baglan = new ApartmanYonetimEntities())
            {
                var uyeTablo = baglan.Uyeler.ToList();
                ViewBag.uyeler = uyeTablo;

                Int32 uyeID = uyeTablo[0].ID;
                return View();
            }


        }

        [HttpPost]
        public ActionResult IslemEkle(Islemler islem)
        {
            using (ApartmanYonetimEntities baglan = new ApartmanYonetimEntities())
            {
                if ((islem.Tutar != null)&& (islem.Aciklama != null))
                {

                    baglan.Islemler.Add(islem);
                    baglan.SaveChanges();
                    Session["uyari"] = "Bilgileriniz kaydedildi.";
                }
                else
                {
                    Session["uyari"] = "Gerekli alanları doldurunuz ";
                }
                return RedirectToAction("IslemTablo");
            }

        }
    }

    
}