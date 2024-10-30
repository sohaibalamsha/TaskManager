using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TASK_SYS.Areas.Identity.Data;
using TASK_SYS.Data;
using TASK_SYS.Models;

namespace TASK_SYS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly AuthDbContext _context;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, AuthDbContext context)
        {
            _logger = logger;
            _usermanager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _usermanager.GetUserId(User); // Get logged-in user's ID
            var tasks = _context.Tasks.Include(t => t.User).ToList();
            //var userTasks = await _context.Tasks
            //    .Where(t => t.UserId == userId)
            //    .ToListAsync(); // Fetch tasks for this user

            return View(tasks); // Pass tasks to the view
        }
        //public IActionResult Index()
        //{
        //    ViewData["UserID"] = _usermanager.GetUserId(this.User);
        //    return View();
        //}

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
