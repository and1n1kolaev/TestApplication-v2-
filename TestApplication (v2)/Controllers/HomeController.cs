using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApplication__v2_.Models;

namespace TestApplication__v2_.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult GetTree()
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    var treeData = db.Performers
                        .AsNoTracking()
                        .Include(p => p.Album)
                        .ToList();
                    return Ok(treeData);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }


        [HttpGet]
        public IActionResult GetTracks(int albumId)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    var tracks = db.Albums
                        .AsNoTracking()
                        .Include(p => p.Tracks)
                        .FirstOrDefault(p => p.Id == albumId)
                        .Tracks
                        .ToList();
                    return Ok(tracks);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);            
            }           
        }

      

        [HttpPost]
        public ActionResult PostTrackInfo(TrackModel trackData)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    var track = db.Tracks
                        .FirstOrDefault(p => p.Id == trackData.Id);
                    track.IsFavorite = trackData.IsFavorite;
                    track.IsListened = trackData.IsListened;
                    track.Rating = trackData.Rating;                   
                    db.Entry(track).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok();
                }

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        


        public IActionResult Index()
        {
            return View();
        }
    }
}
