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
        public ActionResult Index(string sortOrder, string searchString)
        {
            int year = 2018;

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
            }).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                listVMList = listVMList.Where(s => s.SongName.Contains(searchString)
                                       || s.ArtistName.Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "ListPosition_desc":
                    listVMList = listVMList.Where(s => s.ListYear == year).OrderByDescending(s => s.ListPosition).ToList();
                    break;
                case "SongName":
                    listVMList = listVMList.Where(s => s.ListYear == year).OrderBy(s => s.SongName).ToList();
                    break;
                case "SongName_desc":
                    listVMList = listVMList.Where(s => s.ListYear == year).OrderByDescending(s => s.SongName).ToList();
                    break;
                case "ArtistName":
                    listVMList = listVMList.Where(s => s.ListYear == year).OrderBy(s => s.ArtistName).ToList();
                    break;
                case "ArtistName_desc":
                    listVMList = listVMList.Where(s => s.ListYear == year).OrderByDescending(s => s.ArtistName).ToList();
                    break;
                case "SongYear":
                    listVMList = listVMList.Where(s => s.ListYear == year).OrderBy(s => s.SongYear).ToList();
                    break;
                case "SongYear_desc":
                    listVMList = listVMList.Where(s => s.ListYear == year).OrderByDescending(s => s.SongYear).ToList();
                    break;
                default:
                    listVMList = listVMList.Where(s => s.ListYear == year).OrderBy(s => s.ListPosition).ToList();
                    break;
            }
            return View(listVMList);
        }
    }
}