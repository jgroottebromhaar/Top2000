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
        public ActionResult Index()
        {
            //top2000DBEntities db = new top2000DBEntities();

            //List<ListViewModel> listClassList = db.List.ToList();

            //ListViewModel ListVM = new ListViewModel();

            //List<ListViewModel> listVMList = listClassList.Select(x => new ListViewModel
            //{
            //    ListPosition = x.ListPosition,
            //    ArtistName = x.ArtistName,
            //    SongName = x.Song.SongName,
            //    SongYear = x.Song.SongYear
            //}
            //).ToList();
            return View();
        }

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