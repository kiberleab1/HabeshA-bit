using HabeshaBit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Data;

namespace HabeshaBit.Controllers
{
    public class MusicController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Music
        public ActionResult Index()
        {
            MusicModel musicModel = new MusicModel();
            
            return View(musicModel.getMusics());
        }
        //POST : Music
        [HttpPost]
        public ActionResult Index(string query)
        {
            Search search = new Search();
            search.searchQuery = query;
          //  return search.searchQuery;
           return View(search.getMusic());
        }
        [HttpPost]
        [Authorize]
        [ActionName("Add")]
        public ActionResult addPlay(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                PlayList playList = new PlayList();
                playList.userID = User.Identity.GetUserId();
                playList.musicID = int.Parse(id);
                playList.save();
              return  RedirectToAction("Music");
            }


          return  RedirectToAction("Account/Login");
        }
        [ActionName("Play")]
        public ActionResult play(int id) {
            MusicModel musicModel = new MusicModel();
            
            return View(musicModel.getMusicsByID(id));
        }
        // [ActionName("play")]
        
        [HttpGet]
        [AllowAnonymous]
        //GET: Music/upload
        public ActionResult upload() {
            DataConnection dataConnection = new DataConnection();
            dataConnection.Initalize();
        //   SqlCommand cmd = new SqlCommand("SELECT * FROM [Album]", dataConnection.openCon());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [Album]", dataConnection.openCon());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            var list = new List<Music>();
            foreach (DataRow row in dataTable.Rows) {
                list.Add(
                    new Music
                    {
                        album = row["Name"].ToString()
                    }

                ); }
            var model = new Music();
            model.albums =new SelectList(list, "album", "album");
            return View(model);
        }
        //POST: Music/upload
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult upload(Music music) {
           music.musicFile.SaveAs(Server.MapPath("~/UploadedMusic/" + music.musicFile.FileName));
           music.picFile.SaveAs(Server.MapPath("~/UploadedMusic/" + music.picFile.FileName));
           music.musicPath = "UploadedMusic/" + music.musicFile.FileName;
           music.picPath = "UploadedMusic/" + music.picFile.FileName;
           music.saveMusic();
            
            return RedirectToAction("Index");
        }
        public FileContentResult GetFile(string name) {
            return null;
        }
        [HttpGet]
        [AllowAnonymous]
        //GET: Music/Albums
        public ActionResult getAlbum()
        {
            Album album = new Album();
            
            
            return View(album.GetAlbums(User.Identity.GetUserId()));
        }
        [HttpGet]
        [AllowAnonymous]
        //GET: Music/Album/Create
        public ActionResult createAlbum()
        {
           


            return View();
        }
        //POST: Music/Album/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult createAlbum(Album alb)
        {
            alb.Artist = User.Identity.GetUserId();
            alb.saveAlbum();
            // return music.musicFile.FileName;
            return RedirectToAction("createAlbum");
        }
        //GET: music/Album/Edit
        public ActionResult detailsAlbum(int id)
        {
            Album album = new Album();
            
            
            return View(album.findAlbum(id));
        }
        //POST: Music/Album/Edit
        public ActionResult detailsAlbum(Album album)
        {
            album.update();

           return  RedirectToAction("Edit/"+album.id.ToString());
        }
        //GET: Music/PlayList
        [Authorize]
        public ActionResult playList()
        {
            if (User.Identity.IsAuthenticated) { 
            PlayList playList = new PlayList();
                playList.userID = User.Identity.GetUserId();
            return View(playList.getMusic());
            }
            return RedirectToRoute("Account/Login");
        }

    }
}