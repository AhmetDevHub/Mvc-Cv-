using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
	[AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
		public PartialViewResult SosyalMedya()
		{
			var sosyalmedya = db.TblSosyalMedya.Where(x=>x.Durum == true).ToList();
			return PartialView(sosyalmedya);
		}
		public PartialViewResult Egitimlerim()
		{
			var egitim = db.TblEgitim.ToList();
			return PartialView(egitim);
		}
		public PartialViewResult Yeteneklerim()
		{
			var yetenek = db.TblYeteneklerim.ToList();
			return PartialView(yetenek);
		}
		public PartialViewResult Hobilerim()
		{
			var hobi = db.TblHobilerim.ToList();
			return PartialView(hobi);
		}
		public PartialViewResult Sertifikalar()
		{
			var sertifika = db.TblSertifikalar.ToList();
			return PartialView(sertifika);
		}

		[HttpGet]
		public PartialViewResult iletisim()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult iletisim(Tblİletisim t)
		{
			t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
			db.Tblİletisim.Add(t);
			db.SaveChanges();
			return PartialView();

		}
	}
}