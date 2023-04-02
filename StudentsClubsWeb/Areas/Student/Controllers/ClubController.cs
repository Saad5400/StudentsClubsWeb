using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
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
        public IActionResult Index(ClubIndexVM? vm)
        {
            vm = new ClubIndexVM();
            vm.Clubs = _db.Clubs.Include(c => c.Tags).ToList();
            vm.Tags = _db.Tags.ToList().ToList();

            return View(vm);
        }

        public IActionResult ApplyFilter(ClubIndexVM vm)
        {
            var clubs = _db.Clubs.Include(c => c.Tags).ToList();
            var tags = _db.Tags.ToList().DistinctBy(t => t.Title).ToList();

            // Filter clubs based on selected city
            if (!string.IsNullOrEmpty(vm.FilterCity))
            {
                clubs = clubs.Where(c => c.Tags.Any(t => t.Title == vm.FilterCity)).ToList();
            }

            // Filter clubs based on selected school
            if (!string.IsNullOrEmpty(vm.FilterSchool))
            {
                clubs = clubs.Where(c => c.Tags.Any(t => t.Title == vm.FilterSchool)).ToList();
            }

            // Filter clubs based on selected tag
            if (!string.IsNullOrEmpty(vm.FilterTag))
            {
                clubs = clubs.Where(c => c.Tags.Any(t => t.Title.Equals(vm.FilterTag, StringComparison.OrdinalIgnoreCase))).ToList();
            }

            vm.Clubs = clubs;
            vm.Tags = tags;
            
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
        [ValidateAntiForgeryToken]
        public IActionResult CreatePOST(CreateClubVM vm)
        {
            vm.Cities ??= new List<Tag>();
            vm.Schools ??= new List<Tag>();
            vm.Club.ClubAdmins ??= new List<ClubAdmin>();

            if (!ModelState.IsValid)
            {
                return View(nameof(Create), vm);
            }

            var user = GetAppUser();
            
            vm.Club.ClubAdmins.Add(new ClubAdmin{Admin = user, Club = vm.Club});

            var tagsTitle = vm.Tags.Split("-");
            var tags = new List<Tag>();

            foreach (var tagTitle in tagsTitle)
            {
                if (tagTitle.Trim() == string.Empty)
                {
                    continue;
                }
                var tag = new Tag
                {
                    Author = user,
                    Group = SD.TagGroup.Club,
                    Title = tagTitle.Trim(),
                };
                tags.Add(tag);
            }

            var cityTag = new Tag
            {
                Author = user,
                Group = SD.TagGroup.City,
                Title = vm.City.Trim()
            };
            tags.Add( cityTag);
            var schoolTag = new Tag
            {
                Author = user,
                Group = SD.TagGroup.School,
                Title = vm.School.Trim()
            };
            tags.Add(schoolTag);

            
            vm.Club.Tags.AddRange(tags);

            _db.Clubs.Add(vm.Club);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult ClubPage(int id)
        {
            if (TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"];
            }
            // Club club = _db.Clubs
            //     .Include(c => c.Posts)
            //     .Include(c => c.Members)
            //     .Include(c => c.ClubAdmins)
            //     .ThenInclude(cd => cd.Admin)
            //     .FirstOrDefault(c => c.Id == id);

            var club = _db.Clubs.Find(id);
            // if club is null
            if (club == null)
            {
                return NotFound();
            }
            // load and assign posts
            _db.Entry(club).Collection(c => c.Posts).Load();
            _db.Entry(club).Collection(c => c.Members).Load();
            _db.Entry(club).Collection(c => c.ClubAdmins).Load();
            _db.Entry(club).Collection(c => c.Tags).Load();
            // increament each tag's ViewsCount
            foreach (var tag in club.Tags)
            {
                tag.ViewsCount++;
            }
            foreach (var clubAdmin in club.ClubAdmins)
            {
                _db.Entry(clubAdmin).Reference(ca => ca.Admin).Load();
            }
            // increament club views
            club.ViewsCount++;
            // load enumerable JoinClubRequests, where club id == id
            IEnumerable<JoinClubRequest> requests = _db.JoinClubRequests.Include(r => r.User).Where(c => c.ClubId == id);
            // create a new Club Page VM
            var vm = new ClubPageVM()
            {
                Club = club,
                JoinClubRequests = requests
            };
            _db.SaveChanges();
            return View(vm);
        }

        // create method RequestJoinClub
        [Authorize]
        public IActionResult RequestJoinClub(int clubId)
        {
            var userId = GetUserId();
            if (_db.JoinClubRequests.Any(r => r.UserId == userId && r.ClubId == clubId))
            {
                TempData["message"] = "لقد قمت بطلب التسجيل من قبل، انتظر موافقة الادارة";
                return RedirectToAction("ClubPage", new {id = clubId});
            }
            var request = new JoinClubRequest()
            {
                ClubId = clubId,
                UserId = userId,
                IsApproved = false
            };
            _db.JoinClubRequests.Add(request);
            _db.SaveChanges();

            // add a message that the request is sent
            TempData["message"] = "تم ارسال طلبك بنجاح، انتظر موافقة الادارة";

            return RedirectToAction("ClubPage", new {id = clubId});
        }
        [Authorize]

        public IActionResult MyClubs()
        {
            var user = GetAppUser();
            var clubs = _db.Clubs
                .Include(c => c.Members)
                .Where(c => c.Members.Contains(user))
                .Include(c => c.Posts)
                .ToList();

            return View(clubs);
        }
        
    }
}
