﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Top2000.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class top2000DBEntities : DbContext
    {
        public top2000DBEntities()
            : base("name=top2000DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<Song> Song { get; set; }
    
        public virtual ObjectResult<Nullable<int>> getAllYears()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getAllYears");
        }
    
        public virtual ObjectResult<string> getArtists(Nullable<int> selectedYear)
        {
            var selectedYearParameter = selectedYear.HasValue ?
                new ObjectParameter("selectedYear", selectedYear) :
                new ObjectParameter("selectedYear", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("getArtists", selectedYearParameter);
        }
    
        public virtual ObjectResult<getArtistSongs_Result> getArtistSongs(string artistName, Nullable<int> selectedYear)
        {
            var artistNameParameter = artistName != null ?
                new ObjectParameter("artistName", artistName) :
                new ObjectParameter("artistName", typeof(string));
    
            var selectedYearParameter = selectedYear.HasValue ?
                new ObjectParameter("selectedYear", selectedYear) :
                new ObjectParameter("selectedYear", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getArtistSongs_Result>("getArtistSongs", artistNameParameter, selectedYearParameter);
        }
    
        public virtual ObjectResult<getListForYear_Result> getListForYear(Nullable<int> listYear)
        {
            var listYearParameter = listYear.HasValue ?
                new ObjectParameter("ListYear", listYear) :
                new ObjectParameter("ListYear", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getListForYear_Result>("getListForYear", listYearParameter);
        }
    
        public virtual ObjectResult<searchFunction_Result> searchFunction(string searchString, Nullable<int> selectedYear)
        {
            var searchStringParameter = searchString != null ?
                new ObjectParameter("searchString", searchString) :
                new ObjectParameter("searchString", typeof(string));
    
            var selectedYearParameter = selectedYear.HasValue ?
                new ObjectParameter("selectedYear", selectedYear) :
                new ObjectParameter("selectedYear", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchFunction_Result>("searchFunction", searchStringParameter, selectedYearParameter);
        }
    
        public virtual ObjectResult<getArtistSongs_Result> getArtistSongs(string artistName)
        {
            var artistNameParameter = artistName != null ?
                new ObjectParameter("artistName", artistName) :
                new ObjectParameter("artistName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getArtistSongs_Result>("getArtistSongs", artistNameParameter);
        }
    
        public virtual ObjectResult<string> getArtists()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("getArtists");
        }
    
        public virtual ObjectResult<getAveragePositionOfArtistSong1_Result> getAveragePositionOfArtistSong(string artistName)
        {
            var artistNameParameter = artistName != null ?
                new ObjectParameter("artistName", artistName) :
                new ObjectParameter("artistName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAveragePositionOfArtistSong1_Result>("getAveragePositionOfArtistSong", artistNameParameter);
        }
    
        public virtual ObjectResult<getAveragePositionOfArtistSong1_Result> getAveragePositionOfArtistSong1(string artistName)
        {
            var artistNameParameter = artistName != null ?
                new ObjectParameter("artistName", artistName) :
                new ObjectParameter("artistName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAveragePositionOfArtistSong1_Result>("getAveragePositionOfArtistSong1", artistNameParameter);
        }
    }
}
