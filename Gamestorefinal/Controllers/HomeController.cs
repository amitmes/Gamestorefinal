using Gamestorefinal.Data;
using Gamestorefinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Gamestorefinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly GamestorefinalContext _context;

        public HomeController(ILogger<HomeController> logger, GamestorefinalContext context)
        {
            _logger = logger;
            _context = context;
        }

       // [Authorize]
        public async Task<IActionResult> Index()
        {
            ViewBag.Gameslist = _context.Games;
            return View(await _context.Games.ToListAsync());
        }
        [Authorize(Roles = "Admin")]

        public IActionResult Privacy()
        {
            //if(HttpContext.Session.GetString("Email") == null)
            //{
            //    return RedirectToAction("Login", "Clients");
            //}

            return View();
        }
        public JsonResult Datafromdb()
        {
    

            return Json( _context.Games.ToList());
        }
        public async Task<IActionResult> Graphs()
        {
            //if(HttpContext.Session.GetString("Email") == null)
            //{
            //    return RedirectToAction("Login", "Clients");
            //}

            return View();
        }


        public IActionResult About()
        {
          
            return View();
        }
        public IActionResult Team()
        {

            return View();
        }
        public IActionResult TermsAndConditions()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> NewestGames()
        {
            var variable = _context.Games.Where(a => a.Releasedate.Year >= 2020);

            return Json(await variable.ToListAsync());
        }






    }
}
