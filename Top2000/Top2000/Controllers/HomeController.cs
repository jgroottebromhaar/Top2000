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
        public ActionResult Index(string sortOrder)
        {
            ViewBag.ListPositionSortParm = String.IsNullOrEmpty(sortOrder) ? "ListPosition_desc" : "";
            ViewBag.SongNameSortParm = sortOrder == "SongName" ? "SongName_desc" : "SongName";
            ViewBag.ArtistNameSortParm = sortOrder == "ArtistName" ? "ArtistName_desc" : "ArtistName";
            ViewBag.SongYearSortParm = sortOrder == "SongYear" ? "SongYear_desc" : "SongYear";

            List<List> listList = db.List.ToList();

            ListViewModel ListVM = new ListViewModel();

            List<ListViewModel> listVMList = listList.Select(x => new ListViewModel
            {
                ListPosition = x.ListPosition,
                ArtistName = x.Song.Artist.ArtistName,
                SongName = x.Song.SongName,
                SongYear = x.Song.SongYear,
                ListYear = x.ListYear
            }
            ).ToList();

            switch (sortOrder)
            {
                case "ListPosition_desc":
                    listVMList = listVMList.OrderByDescending(s => s.ListPosition).ToList();
                    break;
                case "SongName":
                    listVMList = listVMList.OrderBy(s => s.SongName).ToList();
                    break;
                case "SongName_desc":
                    listVMList = listVMList.OrderByDescending(s => s.SongName).ToList();
                    break;
                case "ArtistName":
                    listVMList = listVMList.OrderBy(s => s.ArtistName).ToList();
                    break;
                case "ArtistName_desc":
                    listVMList = listVMList.OrderByDescending(s => s.ArtistName).ToList();
                    break;
                case "SongYear":
                    listVMList = listVMList.OrderBy(s => s.SongYear).ToList();
                    break;
                case "SongYear_desc":
                    listVMList = listVMList.OrderByDescending(s => s.SongYear).ToList();
                    break;
                default:
                    listVMList = listVMList.OrderBy(s => s.ListPosition).ToList();
                    break;
            }
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