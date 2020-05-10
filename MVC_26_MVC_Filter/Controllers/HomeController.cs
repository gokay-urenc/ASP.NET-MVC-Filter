using MVC_26_MVC_Filter.Models;
using MVC_26_MVC_Filter.Models.BaglantiCumlesi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_26_MVC_Filter.Controllers
{
    public class HomeController : Controller
    {
        [KullaniciFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KayitOl(Kullanici parametre)
        {
            ProjeConnectionString db = new ProjeConnectionString();
            if (ModelState.IsValid) // Validation(Şifre eşleşme) kontrolü yapmak içindir. True, false olarak sonuç döner.
            {
                db.Kullanicilar.Add(parametre);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
                // Kullanıcı kaydı başarılıysa çalışacak ve Index sayfasına yönlendirilecek.
            }
            return View(); 
            // Başarısız ise tekrar aynı sayfaya yönlendirilecek ve hata mesajları gösterilecek.
        }

        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Kullanici model)
        {
            ProjeConnectionString db = new ProjeConnectionString();
            Kullanici girenKisi = db.Kullanicilar.FirstOrDefault(x => (x.KullaniciAdi == model.KullaniciAdi || x.EmailAdresi == model.EmailAdresi) && x.Sifre == model.Sifre);
            if (girenKisi != null)
            {
                ViewBag.Mesaj = "Kullanıcı adı veya parolanız hatalı. Lütfen kontrol ediniz.";
            }
            HttpCookie ck = new HttpCookie("cerez", girenKisi.KullaniciAdi);
            ck.Expires = DateTime.Now.AddDays(1); // Cookienin yaşam süresini belirledik. Bugünün üstüne 1 gün ekledik.
            Response.Cookies.Add(ck); // Cevaba cookie'yi ekledik.
            return RedirectToAction("Index", "Home");
        }
    }
}