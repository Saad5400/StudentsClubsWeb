using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsClubsWeb.Areas.Admin.Controllers;
using StudentsClubsWeb.Areas.Student.Models;
using StudentsClubsWeb.Data;
using StudentsClubsWeb.Models;
using StudentsClubsWeb.Utilities;

namespace StudentsClubsWeb.Areas.Student.Controllers
{
    [Area("Student")]
    public class ClubController : Controller
    {
        private readonly AppDbContext _db;
        public ClubController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable <Club> clubs = _db.Clubs;
            return View(clubs);
        }

        [HttpPost(nameof(Index))]
        public IActionResult ApplyFilter()
        {
            // TODO: Complete
            IEnumerable <Club> clubs = _db.Clubs;

            return View(nameof(Index), clubs);
        }
        public string GetUserId()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var id = claim.Value;

            return id;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(CreateClubVM? vm)
        {
            vm.Club ??= new Club();

            return View(vm);
        }

        [Authorize]
        [HttpPost(nameof(Create))]
        public IActionResult CreatePOST(CreateClubVM vm)
        {
            return View(nameof(Create), vm);
        }
    }
}
