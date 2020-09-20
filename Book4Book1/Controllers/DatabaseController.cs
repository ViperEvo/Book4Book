using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book4Book1.Database;
using Book4Book1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book4Book1.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly LocalDatabase db;

        public DatabaseController(LocalDatabase dataBase)
        {
            db = dataBase;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult GetAllAnnouncements()
        {
            var announcement = new Announcement("2020-09-14", "Krakow", "Fantastyka", "Test1", "Ziomek1", "jakisopis");
            db.AddAnnouncement(announcement);
            var allAnnouncements = db.GetAllAnnouncements();
            var jsonAnnouncement = new
            {
                date = allAnnouncements[0].Date,
                city = allAnnouncements[0].City,
                category = allAnnouncements[0].Category,
                title = allAnnouncements[0].Title,
                author = allAnnouncements[0].Author,
                description = allAnnouncements[0].Description,
            };

            return Json(jsonAnnouncement);
        }
    }
}
