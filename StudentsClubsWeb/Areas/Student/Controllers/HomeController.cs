using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using StudentsClubsWeb.Areas.Student.Models;
using StudentsClubsWeb.Data;
using StudentsClubsWeb.Models;

namespace StudentsClubsWeb.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public async Task<IActionResult> GetFeatured()
        {
            var vm = new HomeIndexVM();
            
            vm.Posts = _db.Posts.OrderByDescending(p => p.ViewsCount).Take(3)
                .Include(p => p.Tags)
                .Include(p => p.Club)
                .Include(p => p.Author)
                .ToList();
            
            vm.Tags = _db.Tags.AsEnumerable().DistinctBy(t => t.Title).AsEnumerable()
                .OrderByDescending(t => t.ViewsCount).Take(5).ToList();
            vm.Clubs = _db.Clubs.OrderByDescending(e => e.ViewsCount).Take(5).ToList();

            var myViewData = new ViewDataDictionary(
                new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(), 
                new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
                {
                    { "vm", vm }
                };

            myViewData.Model = vm;

            PartialViewResult result = new PartialViewResult
            {
                ViewName = "_HomeFeatured",
                ViewData = myViewData
            };

            return result;
        }

        // public IActionResult Index()
        // {
        //     var vm = new HomeIndexVM();
        //
        //     vm.Posts = _db.Posts.OrderByDescending(p => p.ViewsCount).Take(3)
        //         .Include(p => p.Tags)
        //         .Include(p => p.Club)
        //         .Include(p => p.Author)
        //         .ToList();
        //
        //     vm.Tags = _db.Tags.AsEnumerable().DistinctBy(t => t.Title).AsEnumerable()
        //         .OrderByDescending(t => t.ViewsCount).Take(5).ToList();
        //     vm.Clubs = _db.Clubs.OrderByDescending(e => e.ViewsCount).Take(5).ToList();
        //
        //     return View(vm);
        // }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}