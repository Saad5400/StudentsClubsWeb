using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsClubsWeb.Data;
using StudentsClubsWeb.Models;
using StudentsClubsWeb.Utilities;

namespace StudentsClubsWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ClubAdminController : Controller
    {
        // create private readonly _db
        private readonly AppDbContext _db;
        // create user manager
        private readonly UserManager<IdentityUser> _userManager;
        // create ctor and inject db
        public ClubAdminController(AppDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        // public IActionResult Index()
        // {
        //     return View();
        // }

        // create a method for accepting a JoinClubRequest
        public IActionResult AcceptJoinClubRequest(int id)
        {
            // get the JoinClubRequest from the database
            var joinClubRequest = _db.JoinClubRequests
                .Include(j => j.Club)
                .Include(j => j.User)
                .FirstOrDefault(j => j.Id == id);            
            var userId = _userManager.GetUserAsync(User).GetAwaiter().GetResult().Id;
            var clubId = joinClubRequest.ClubId;
            // check if the user requsting this method is registed in the club's admins
            if (!_db.ClubAdmins.Any(ca => ca.ClubId == clubId && ca.AdminId == userId))
            {
                return Unauthorized();
            }
            // if id is null, return NotFound
            if (id == null)
            {
                return NotFound();
            }
            // if the JoinClubRequest is null, return NotFound
            if (joinClubRequest == null)
            {
                return NotFound();
            }
            // add the student to the club's members
            joinClubRequest.Club.Members.Add(joinClubRequest.User);
            // remove the JoinClubRequest from the database
            _db.JoinClubRequests.Remove(joinClubRequest);
            // save changes
            _db.SaveChanges();
            // redirect to the ClubPage
            return RedirectToAction("ClubPage", "Club", new { id = joinClubRequest.ClubId, area = "Student" });
        }
        // create method RejectJoinClubRequest
        public IActionResult RejectJoinClubRequest(int id)
        {
            // get the JoinClubRequest from the database
            var joinClubRequest = _db.JoinClubRequests
                .Include(j => j.Club)
                .Include(j => j.User)
                .FirstOrDefault(j => j.Id == id);
            var userId = _userManager.GetUserAsync(User).GetAwaiter().GetResult().Id;
            var clubId = joinClubRequest.ClubId;
            // check if the user requsting this method is registed in the club's admins
            if (!_db.ClubAdmins.Any(ca => ca.ClubId == clubId && ca.AdminId == userId))
            {
                return Unauthorized();
            }
            // if id is null, return NotFound
            if (id == null)
            {
                return NotFound();
            }
            // if the JoinClubRequest is null, return NotFound
            if (joinClubRequest == null)
            {
                return NotFound();
            }
            // remove the JoinClubRequest from the database
            _db.JoinClubRequests.Remove(joinClubRequest);
            // save changes
            _db.SaveChanges();
            // redirect to the ClubPage
            return RedirectToAction("ClubPage", "Club", new { id = joinClubRequest.ClubId, area = "Student" });
        }
        // create a method for kicking a user
        [Route("[area]/[controller]/[action]/{clubId:int}/{userId}")]
        public IActionResult KickUser(int clubId, string userId)
        {
            // check if the user requsting this method is registed in the club's admins
            if (!_db.ClubAdmins.Any(ca =>
                    ca.ClubId == clubId && ca.AdminId == _userManager.GetUserAsync(User).GetAwaiter().GetResult().Id))
            {
                return Unauthorized();
            }
            // if clubId or userId is null, return NotFound
            if (clubId == null || userId == null)
            {
                return NotFound();
            }
            // get the club from the database
            var club = _db.Clubs
                .Include(c => c.Members)
                .FirstOrDefault(c => c.Id == clubId);
            // if the club is null, return NotFound
            if (club == null)
            {
                return NotFound();
            }
            // get the user from the database
            var user = _db.Users
                .FirstOrDefault(u => u.Id == userId) as AppUser;
            // if the user is null, return NotFound
            if (user == null)
            {
                return NotFound();
            }
            // remove the user from the club's members
            club.Members.Remove(user);
            // save changes
            _db.SaveChanges();
            // redirect to the ClubPage
            return RedirectToAction("ClubPage", "Club", new { id = clubId, area = "Student" });
        }
    }
}