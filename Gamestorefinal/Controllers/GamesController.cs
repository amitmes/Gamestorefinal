using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamesStore.Models;
using Gamestorefinal.Data;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Gamestorefinal.Tweeter;


namespace Gamestorefinal.Controllers
{
    public class GamesController : Controller
    {
        private readonly GamestorefinalContext _context;

        public GamesController(GamestorefinalContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            ViewBag.Category = _context.Category;
            ViewBag.Suppliers = _context.Supplier;

            var m2MwithSearchContext = _context.Games.Include(a => a.Category);
            return View(await m2MwithSearchContext.ToListAsync());




            //  return View(await _context.Games.ToListAsync());
        }
        
        public async Task<IActionResult> Gametype(string Item)
        {
            ViewBag.Category = _context.Category;
            ViewBag.Suppliers = _context.Supplier;
            var m2MwithSearchContext = _context.Games.Include(a => a.Category).Where(g => g.Category.Select(x => x.Name).Contains(Item));

            //var m2MwithSearchContext = _context.Category.Include(a => a.Games).Where(a => a.Name.Equals(Item)).Select(a => a.Games);
            return View("Index",await m2MwithSearchContext.ToListAsync());
        }
       
        public async Task<IActionResult> Filter(string[] category, string[] supplier,int price)
        {
            ViewBag.Category = _context.Category;
            ViewBag.Suppliers = _context.Supplier;
            List<Games> gameslist=new List<Games>();
            foreach(var item in _context.Games.Include(a=>a.Category).Include(x=>x.Suppliers))
            {
                Boolean hascategory = true;
                foreach(var cat in category)
                {
                    if (!(item.Category.Select(x => x.Name).Contains(cat)))
                    {
                        hascategory = false;
                        break;
                    }
                }
                if (hascategory == false)
                {
                    continue;
                }
                Boolean hassupplier = true;
                foreach (var sup in supplier)
                {
                    if (!(item.Suppliers.Select(x => x.Name).Contains(sup)))
                    {
                        hassupplier = false;
                        break;
                    }
                }
                Boolean under = true;
                if (item.Price > price)
                {
                    under = false;
                }
                if (hascategory && hassupplier&&under)
                {
                    gameslist.Add(item);
                }
            }
           
            return View("Index",gameslist);
        }

        public async Task<IActionResult> Search(string query)
        {
            var m2MwithSearchContext = _context.Games.Where(a => a.Name.Contains(query) || query == null);
            return Json(await m2MwithSearchContext.ToListAsync());

        }
        
        //public async Task<IActionResult> Gamesfilter(string matchingStr)
        //{
        //    var x = _context.Games.Include(a => a.Category).Where(g => g.Category.Select(x => x.Name).Contains(matchingStr));
        //    var y = x;
        //    return View("Index", await x.ToListAsync());
        //}

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = _context.Games.Where(m => m.Id == id);
            if (games == null)
            {
                return NotFound();
            }

            return Json(await games.ToListAsync());
        }

        // GET: Games/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Category"] = new MultiSelectList(_context.Category, nameof(Category.Id), nameof(Category.Name));
            ViewData["Suppliers"] = new MultiSelectList(_context.Supplier, nameof(Supplier.Id), nameof(Supplier.Name));

            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Systemrequiremnts,Releasedate,Price,Trailer,Imagefile,Onstock,Countofsell")] Games games, int[] Category, int[] Suppliers)
        {
            
            games.Category = new List<Category>();
            games.Category.AddRange(_context.Category.Where(x => Category.Contains(x.Id)));

            games.Suppliers = new List<Supplier>();
            games.Suppliers.AddRange(_context.Supplier.Where(x => Suppliers.Contains(x.Id)));
            if (ModelState.IsValid)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    games.Imagefile.CopyTo(ms);
                    games.Image = ms.ToArray();
                }
                _context.Add(games);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            //Twitter twitter = new Twitter(Twitter.APIkeycon, Twitter.APIsecretKeycon, Twitter.AccessToken,
            //            Twitter.AccessTokenSecret);
            //twitter.TweetText("Check out our new game!!! -> " + games.Name, string.Empty);





            Tweeter.Twitter twitter = new Twitter(Twitter.APIkeycon, Twitter.APIsecretKeycon, Twitter.AccessToken,
                        Twitter.AccessTokenSecret);
            twitter.TweetText("Check out our new game!!! -> " + games.Name, string.Empty);



            return View(games);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }
            return View(games);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Systemrequiremnts,Releasedate,Price,Trailer,Image,Onstock,Countofsell")] Games games)
        {
            if (id != games.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(games);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamesExists(games.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(games);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var games = await _context.Games.FindAsync(id);
            _context.Games.Remove(games);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamesExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}