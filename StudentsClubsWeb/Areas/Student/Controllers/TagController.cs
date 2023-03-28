using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsClubsWeb.Models;
using StudentsClubsWeb.Utilities;

namespace StudentsClubsWeb.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize]
    public class TagController : Controller
    {
        [Authorize(Roles = SD.Role.Admin)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(Tag? tag)
        {
            tag ??= new Tag();

            return View(tag);
        }

        [HttpPost(nameof(Create))]
        public IActionResult CreatePOST(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                // error
                return View("Create", tag);
            }
            return View("Create", tag);
        }
    }
}
