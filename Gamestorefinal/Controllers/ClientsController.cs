using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamesStore.Models;
using Gamestorefinal.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Gamestorefinal.Controllers
{
    public class ClientsController : Controller
    {
        private readonly GamestorefinalContext _context;

        public ClientsController(GamestorefinalContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Search(string query)
        {
            var m2MwithSearchContext = _context.Client.Where(a => a.Email.Contains(query) || query == null);
            return Json(await m2MwithSearchContext.ToListAsync());
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Client.ToListAsync());
        }

        public async void Addtocart(string email, int gameid)
        {
            if (email != null)
            {
                var g = _context.Games.Include(x => x.Category).Where(a => a.Id.Equals(gameid)).FirstOrDefault();
                _context.Client.Include(x => x.Cart).Where(a => a.Email.Equals(email)).FirstOrDefault().Cart.Add(g);
                _context.SaveChangesAsync();
            }
        }


        public async void Deletefromcart(string email, int gameid)
        {
            var g = _context.Games.Include(x => x.Category).Where(a => a.Id.Equals(gameid)).FirstOrDefault();
            _context.Client.Include(x => x.Cart).Where(a => a.Email.Equals(email)).FirstOrDefault().Cart.Remove(g);
            _context.SaveChangesAsync();

        }
        public async void Addtowishlist(string email, int gameid)
        {
            if (email != null)
            {
                var g = _context.Games.Include(x => x.Category).Where(a => a.Id.Equals(gameid)).FirstOrDefault();
                _context.Client.Include(x => x.WishList).ThenInclude(a => a.Gameslist).Where(a => a.Email.Equals(email)).FirstOrDefault().WishList.Gameslist.Add(g);
                _context.SaveChangesAsync();
            }
       
        }

        public async void Deletefromwishlist(string email, int gameid)
        {
            var g = _context.Games.Include(x => x.Category).Where(a => a.Id.Equals(gameid)).FirstOrDefault();
            _context.Client.Include(x => x.WishList).ThenInclude(a => a.Gameslist).Where(a => a.Email.Equals(email)).FirstOrDefault().WishList.Gameslist.Remove(g);
            _context.SaveChangesAsync();
        }

        // GET: Clients/Login
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        // POST: Clients/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Id,Email,Password")] Client client)
        {
          
                var q = from u in _context.Client
                        where u.Email == client.Email && u.Password == client.Password
                        select u;

                if (q.Count()>0)
                {
                //HttpContext.Session.SetString("Email", q.First().Email);

                Signin(q.First());
                    
                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    ViewData["Error"] = "One or more of the details are wrong";
                }
            
            return View(client);
        }



        private async void Signin(Client account)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Email),
                new Claim(ClaimTypes.Role, account.Type.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }






        // GET: Clients/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Clients/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,FirstName,LastName,Email,Password,phone")] Client client)
        {
            client.OrderClient = new List<OrderClient>();
            client.WishList = new Wishlist();
            client.WishList.Gameslist = new List<Games>();
            client.WishList.ClientId = client.Id;
            client.WishList.Client = client;
            if (ModelState.IsValid)
            {
                var q = _context.Client.FirstOrDefault(u => u.Email == client.Email);
                if (q == null)
                {
                    _context.Add(client);
                    await _context.SaveChangesAsync();

                    var u = _context.Client.FirstOrDefault(u => u.Email == client.Email && u.Password == client.Password);
                    Signin(u);

                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    ViewData["Error"] = "This Email is already exist, please enter another email.";
                }
            }
            return View(client);
        }



        public async Task<IActionResult> Join1()
        {
            var result = (from a in _context.Client
                          join b in _context.Supplier on a.Email equals b.Email
                          select a).Distinct();

            return View(await result.ToListAsync());
           
        }



        // GET: Clients
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Client.ToListAsync());
        //}

        //// GET: Clients/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var client = await _context.Client
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(client);
        //}

        //// GET: Clients/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Clients/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Password,phone,Type")] Client client)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(client);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(client);
        //}

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Password,phone,Type")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Client.FindAsync(id);


            //var orderClient = _context.OrderClient.Where(x => x.ClientId == id).ToList();
            //_context.OrderClient.RemoveRange(orderClient);

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.Id == id);
        }
    }
}
