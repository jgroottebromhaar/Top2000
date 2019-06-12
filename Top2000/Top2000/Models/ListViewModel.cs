using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Top2000.Models
{
    public class ListViewModel
    {
        public int? ListPosition { get; set; }
        public string ArtistName { get; set; }
        public string SongName { get; set; }
        public int? SongYear { get; set; }
        public int? ListYear { get; set; }
    }
}