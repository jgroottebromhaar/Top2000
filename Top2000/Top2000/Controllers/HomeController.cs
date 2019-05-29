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
        public ActionResult Index()
        {
            List<List> listList = db.List.ToList();

            ListViewModel ListVM = new ListViewModel();

            List<ListViewModel> listVMList = listList.Select(x => new ListViewModel
            {
                ListPosition = x.ListPosition,
                ArtistName = x.Song.Artist.ArtistName,
                SongName = x.Song.SongName,
                SongYear = x.Song.SongYear
            }
            ).ToList();
            return View(listVMList);
        }

        //// GET: Home/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ArtistID = new SelectList(db.Artist, "ArtistID", "ArtistName");
        //    return View();
        //}

        //// POST: Home/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "SongID,SongName,SongYear,ArtistID")] ListViewModel listVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Song.Add(listVM);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ArtistID = new SelectList(db.Artist, "ArtistID", "ArtistName", listVM.Song.Artist.ArtistID);
        //    return View(listVM);
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}