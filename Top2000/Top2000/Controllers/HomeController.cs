using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Top2000.Models;

namespace Top2000.Controllers
{
    public class HomeController : Controller
    {
        private top2000DBEntities db = new top2000DBEntities();
        public ActionResult Index(int? year)
        {
            ViewBag.Years = db.getAllYears().ToList();
            if (year == null)
            {
                year = db.List.Max(y => y.ListYear);
                return View(db.getListForYear(year));
            }
            else
            {
                return View(db.getListForYear(year));
            }
        }

        public ActionResult SearchResult(string search, int? year)
        {
            ViewBag.Search = db.searchFunction(search, year).ToList();
            if (year == null)
            {
                return View(db.searchFunction(search, year));
            }
            else
            {
                return View(db.searchFunction(search, year));
            }
        }
    }
}