using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ClubIndexVM vm = new ClubIndexVM();

            vm.Clubs = _db.Clubs.Include(c => c.Tags).ToList();
            vm.Tags = _db.Tags.ToList();

            return View(vm);
        }

        [HttpPost(nameof(Index))]
        public IActionResult ApplyFilter()
        {
            // TODO: Complete
            ClubIndexVM vm = new ClubIndexVM();

            return View(nameof(Index), vm);
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
        [HttpGet]
        public IActionResult Create(CreateClubVM? vm)
        {
            vm ??= new CreateClubVM();
            vm.Club = new Club();
            vm.TagsList = _db.Tags.Where(t => t.Group == SD.TagGroup.Club).ToList();
            vm.Cities = _db.Tags.Where(t => t.Group == SD.TagGroup.City).ToList();
            vm.Schools = _db.Tags.Where(t => t.Group == SD.TagGroup.School).ToList();

            return View(vm);
        }

        [Authorize]
        public IActionResult CreatePOST(CreateClubVM vm)
        {
            vm.Cities = new List<Tag>();
            vm.Schools = new List<Tag>();

            if (!ModelState.IsValid)
            {
                return View(nameof(Create), vm);
            }

            var user = GetAppUser();
            
            vm.Club.Admins.Add(user);

            var tagsTitle = vm.Tags.Split("-");
            var tags = new List<Tag>();
            foreach (var tagTitle in tagsTitle)
            {
                var tag = new Tag
                {
                    Author = user,
                    Group = SD.TagGroup.Club,
                    Title = tagTitle
                };
                tags.Add(tag);
            }

            var cityTag = new Tag
            {
                Author = user,
                Group = SD.TagGroup.City,
                Title = vm.City
            };
            tags.Add(cityTag);
            var schoolTag = new Tag
            {
                Author = user,
                Group = SD.TagGroup.School,
                Title = vm.School
            };
            tags.Add(schoolTag);

            
            vm.Club.Tags.AddRange(tags);

            _db.Clubs.Add(vm.Club);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
