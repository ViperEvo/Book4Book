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
            var allAnnouncements = db.GetAllAnnouncements();
            string jsonResult = string.Empty;
            foreach (var announcement in allAnnouncements)
            {
                jsonResult += $"announcement: " +
                    $"{{ " +
                    $"date:{announcement.Date}," +
                    $"city:{announcement.City}," +
                    $"category:{announcement.Category}," +
                    $"title:{announcement.Title}," +
                    $"author:{announcement.Author}," +
                    $"description:{announcement.Description}," +
                    $"}},";
            }

            return Json(jsonResult);
        }

        [HttpPost]
        public ActionResult AddAnnouncement(string date, string city, string category, string title, string author, string description)
        {
            var announcement = new Announcement(date, city, category, title, author, description);
            db.AddAnnouncement(announcement);

            return Json(null);
        }

        [HttpPost]
        public ActionResult RemoveAnnouncement(string id)
        {
            var allAnnouncements = db.GetAllAnnouncements();
            foreach (var announcement in allAnnouncements)
            {
                if (announcement.AnnouncementId == int.Parse(id))
                {
                    db.RemoveAnnouncement(announcement);
                    break;
                }
            }

            return Json(null);
        }

        [HttpPost]
        public ActionResult IsUserAuthenticated(string login, string password)
        {
            return Json($"{db.IsUserAuthenticated(login, password)}");
        }

        [HttpPost]
        public ActionResult AddUser(string firstName, string lastName, string login, string password, string email)
        {
            var user = new User(firstName, lastName, email, login, password);

            db.AddUser(user);

            return Json(null);
        }

        [HttpPost]
        public ActionResult RemoveUser(string id)
        {
            var allUsers = db.GetAllUsers();
            foreach (var user in allUsers)
            {
                if (user.UserId == int.Parse(id))
                {
                    db.RemoveUser(user);
                    break;
                }
            }

            return Json(null);
        }
    }
}