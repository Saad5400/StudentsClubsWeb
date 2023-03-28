﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsClubsWeb.Areas.Student.Models;
using StudentsClubsWeb.Data;
using StudentsClubsWeb.Models;
using StudentsClubsWeb.Utilities;

namespace StudentsClubsWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role.Admin)]

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
            ClubIndexVM vm = new ClubIndexVM();

            vm.Clubs = _db.Clubs.Include(c => c.Tags).ToList();
            vm.Tags = _db.Tags.ToList();

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
            _db.SaveChanges();
            return Ok("Admin Granted to this user");
        }
    }
}
