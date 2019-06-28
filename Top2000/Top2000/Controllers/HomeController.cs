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

        // returns top 2000 
        public ActionResult Index(int? year)
        {
            // Viewbag vult de dropdownlist met ListYears
            // Returns int met ListYear
            ViewBag.Years = db.getAllYears().ToList();

            // Bij opstarten view, year is leeg en moet dus worden gevuld
            if (year == null)
            {
                year = db.List.Max(y => y.ListYear);
                return View(db.getListForYear(year));
            }
            else
            {
                // returns view top 2000 van de geselecteerde jaar
                return View(db.getListForYear(year));
            }
        }

        // Returns list met alle nummers van één artiest
        public ActionResult ArtistSongs(string artist)
        {
            // Viewbag vult de dropdownlist met ArtistNames
            // Returns String met ArtistName 
            ViewBag.Artist = db.getArtists().ToList();

            // Bij opstarten view, artist is leeg en moet dus worden gevuld
            if (artist == null)
            {
                artist = db.Artist.Min(y => y.ArtistName);
                return View(db.getArtistSongs(artist));
            }
            else
            {
                // returns view met alle nummers van de geselecteerde artiest
                return View(db.getArtistSongs(artist));
            }
        }

        // returns list met het gemiddelde positie van de nummers van één artiest
        public ActionResult AverageArtistSongPosition(string artist)
        {
            // Viewbag vult de dropdownlist met ArtistNames
            // Returns String met ArtistName 
            ViewBag.Artist = db.getArtists().ToList();

            // Bij opstarten view, artist is leeg en moet dus worden gevuld
            if (artist == null)
            {
                artist = db.Artist.Min(y => y.ArtistName);
                return View(db.getAveragePositionOfArtistSong1(artist));
            }
            else
            {
                // returns view met gemiddelde positie van de  nummers van de geselecteerde artiest
                return View(db.getAveragePositionOfArtistSong1(artist));
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