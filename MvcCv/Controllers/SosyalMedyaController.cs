using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Ekle(TblSosyalMedya p)
		{
            repo.TAdd(p);
			return RedirectToAction("Index");
		}

        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var veri = repo.Find(x => x.ID == id);
            return View(veri);
        }

        [HttpPost]
		public ActionResult SayfaGetir(TblSosyalMedya p)
		{
			var veri = repo.Find(x => x.ID == p.ID);
			veri.Durum = true;
			veri.Ad = p.Ad;
            veri.Link = p.Link;
            veri.İkon = p.İkon;
            repo.TUpdate(veri);
			return RedirectToAction("Index");
		}
        public ActionResult Sil(int id)
        {
            var veri = repo.Find(x => x.ID == id);
            veri.Durum = false;
            repo.TUpdate(veri);
            return RedirectToAction("Index");
        }
	}
}