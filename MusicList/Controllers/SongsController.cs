using Microsoft.AspNetCore.Mvc;
using MusicList.Models;

namespace MusicList.Controllers
{
    public class SongsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SongsController(ApplicationDbContext db) {  //db is imported database
            _db = db;
        }
        public IActionResult Index()
        {
            var items = _db.Songs.ToList();
            
            if(items == null)
            {
                return NotFound();
            }
            return View(items);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }


        //POST
        [HttpPost]
        public IActionResult Create([Bind("Id,Name,Artist,Genre,Rating")] Song song)
        {
            _db.Add(song);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                var song = _db.Songs.FirstOrDefault(s => s.Id == id);
                return View(song);
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,Artist,Genre,Rating")] Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            _db.Update(song);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var song = _db.Songs.FirstOrDefault(s => s.Id == id);
            return View(song);
        }

        [HttpPost]
        public IActionResult Delete(int id, [Bind("Id,Name,Artist,Genre,Rating")] Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            _db.Remove(song);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Search(string query)
        {
            if (query == null)
            {
                return View("NotFound");
            }

            var song = _db.Songs.Where(i => i.Name == query).ToList();

            if (song == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(song);
        }
    }
}
