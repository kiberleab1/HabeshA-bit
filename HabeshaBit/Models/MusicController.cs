using HabeshaBit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HabeshaBit.Controllers
{
    public class MusicController : Controller
    {
        
        // GET: Music
        public ActionResult Index()
        {
            MusicModel musicModel = new MusicModel();
            
            return View(musicModel.getMusics());
        }

        [ActionName("Play")]
        public string play(int id) {
            return "plating music "+id.ToString();
        }
        // [ActionName("play")]
        
        [HttpGet]
        [AllowAnonymous]
        //GET: Music/upload
        public ActionResult upload() {
            return View();
        }
        //POST: Music/upload
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult upload(Music music) {
           music.musicPath= Server.MapPath("~/UploadedMusic/" + music.musicFile.FileName);
            music.saveMusic();
          // return music.musicFile.FileName;
            return RedirectToAction("Index");
        }
        public FileContentResult GetFile(string name) {
            return null;
        }
    }
}