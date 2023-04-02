using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsClubsWeb.Areas.Admin.Models;
using StudentsClubsWeb.Areas.Student.Models;
using StudentsClubsWeb.Data;
using StudentsClubsWeb.Models;
using StudentsClubsWeb.Utilities;

namespace StudentsClubsWeb.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public AdminController(
            AppDbContext db,
            UserManager<IdentityUser> userManager
            )
        {
            _db = db;
            _userManager = userManager;
        }
        [Authorize(Roles = SD.Role.Admin)]
        public IActionResult Index()
        {
            AdminIndexVM vm = new AdminIndexVM();

            vm.Clubs = _db.Clubs.Include(c => c.Tags);
            vm.AppUsers = _db.AppUsers;
            vm.Tags = _db.Tags;
            vm.Posts = _db.Posts.Include(p => p.Club);

            return View(vm);
        }
        public string GetUserId()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var id = claim.Value;

            return id;
        }

        public AppUser? GetAppUser()
        {
            return _db.AppUsers.Find(GetUserId());
        }
        [Authorize]
        public IActionResult GrantAdmin(string password)
        {
            if (password != "ThisIsMyVeryTopSecretPasswordWhichWillGrantYouAnAdminRole")
            {
                return NotFound();
            }
            var user = GetAppUser();
            _userManager.AddToRoleAsync(user, SD.Role.Admin).GetAwaiter().GetResult();
            
            return Ok("Admin Granted to this user");
        }

        [Authorize(Roles = SD.Role.Admin)]
        public IActionResult RemoveClub(int? clubId)
        {
            if (clubId is null or 0)
            {
                return RedirectToAction("Index");

            }
            var club = _db.Clubs.Include(c => c.Tags).FirstOrDefault(c => c.Id == clubId);

            _db.Clubs.Remove(club);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = SD.Role.Admin)]
        public IActionResult RemoveTag(int? tagId)
        {
            if (tagId is null or 0)
            {
                return RedirectToAction("Index");

            }
            var tag = _db.Tags.Find(tagId);

            _db.Tags.Remove(tag);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // create method RemovePost
        [Authorize(Roles = SD.Role.Admin)]
        public IActionResult RemovePost(int? postId)
        {
            if (postId is null or 0)
            {
                return RedirectToAction("Index");
            }
            var post = _db.Posts.Find(postId);
            _db.Posts.Remove(post);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
