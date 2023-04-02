using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsClubsWeb.Data;
using StudentsClubsWeb.Models;

namespace StudentsClubsWeb.Areas.Student.Controllers
{
    [Area("Student")]
    public class PostController : Controller
    {
        private readonly AppDbContext _db;
        public PostController(AppDbContext db)
        {
            _db = db;
        }
        // public IActionResult Index()
        // {
        //     return View();
        // }

        public IActionResult Create(int? clubId)
        {
            // if clubId is null
            if (clubId == null)
            {
                return NotFound();
            }
            Post post = new Post();
            Club club = _db.Clubs
                .Include(c => c.Members)
                .Include(c => c.ClubAdmins)
                .FirstOrDefault(c => c.Id == clubId);

            post.ClubId = clubId;
            post.AuthorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (club.Members.Any(m => m.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)) ||
                club.ClubAdmins.Any(ca => ca.AdminId == User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return View(post);
            }

            return RedirectToAction("Index", "Club");

            // is there a package to have a text editor, that can then be stored and displayed in a view? 
            
        }

        // httppost for Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post, string? editordata)
        {
            post.Content = editordata;

            if (ModelState.IsValid)
            {
                _db.Posts.Add(post);
                _db.SaveChanges();
                
                return RedirectToAction("ClubPage", "Club", new {id =  post.ClubId});
            }
            return View(post);
        }   
    }
}
