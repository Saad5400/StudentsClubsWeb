using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsClubsWeb.Models;
using StudentsClubsWeb.Utilities;

namespace StudentsClubsWeb.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize]
    public class TagController : Controller
    {
        [Authorize(Roles = SD.Role.Admin)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tag tag)
        {
            if (!ModelState.IsValid) 
            {
                return View(tag);
            }
            return View(tag);
        }
    }
}
