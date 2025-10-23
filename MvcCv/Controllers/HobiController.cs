using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.List();
            return View(hobi);
        }

        [HttpPost]
		public ActionResult Index(TblHobilerim p)
		{
            var deger = repo.Find(x => x.ID == 1);
            deger.Aciklama1 = p.Aciklama1;
            deger.Aciklama2 = p.Aciklama2;
            repo.TUpdate(deger);			
			return RedirectToAction("Index");
		}

	}
}