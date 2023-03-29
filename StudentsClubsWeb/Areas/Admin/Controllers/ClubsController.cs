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
    // [Authorize(Roles = SD.Role.Admin)]

    public class ClubsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public ClubsController(
            AppDbContext db,
            UserManager<IdentityUser> userManager
            )
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ClubsIndexVM vm = new ClubsIndexVM();

            vm.Clubs = _db.Clubs.Include(c => c.Tags);
            vm.AppUsers = _db.AppUsers;
            vm.Tags = _db.Tags;

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
        public IActionResult GrantAdmin()
        {
            var user = GetAppUser();
            _userManager.AddToRoleAsync(user, SD.Role.Admin).GetAwaiter().GetResult();
            
            return Ok("Admin Granted to this user");
        }

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
    }
}
