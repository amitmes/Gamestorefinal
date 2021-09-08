using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamesStore.Models;
using Gamestorefinal.Data;

namespace Gamestorefinal.Controllers
{
    public class OrderClientsController : Controller
    {
        private readonly GamestorefinalContext _context;

        public OrderClientsController(GamestorefinalContext context)
        {
          
            _context = context;
        }

        // GET: OrderClients
        public async Task<IActionResult> Index()
        {
            var gamestorefinalContext = _context.OrderClient.Include(o => o.Client);
    
            return View(await gamestorefinalContext.ToListAsync());
        }

        // GET: OrderClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderClient = await _context.OrderClient
                .Include(o => o.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderClient == null)
            {
                return NotFound();
            }

            return View(orderClient);
        }

        // GET: OrderClients/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Email");
            ViewBag.clientdetail = _context.Client.Include(x=>x.Cart);
            return View();
        }

        // POST: OrderClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,Creditcard,Totalprice,DateTime,City,Street,Buildingnumber,Apartmentnumber,Zipcode,Comment,Status")] OrderClient orderClient,List<int>gamesid,List<int> counters, string user)
        {
            orderClient.DateTime = DateTime.Now;
            ViewBag.clientdetail = _context.Client.Include(x => x.Cart);
            int count = 0;
            orderClient.Games = new List<Games>();
            orderClient.countofgames = new List<int>();
            foreach (var i in gamesid)
            {
                Games g = _context.Games.Where(x => x.Id == i).FirstOrDefault();
                orderClient.Games.Add(g);
                var c = counters[count] / g.Price;
                orderClient.countofgames.Add((int)c);
                _context.Games.Where(x => x.Id == i).FirstOrDefault().Countofsell += 1;
                _context.Games.Where(x => x.Id == i).FirstOrDefault().Onstock -= 1;
                count++;
            }
            orderClient.Client = _context.Client.Include(x => x.OrderClient).Where(x => x.Email.Equals(user)).FirstOrDefault();
            _context.Client.Include(x=>x.OrderClient).Where(x => x.Email.Equals(user)).FirstOrDefault().OrderClient.Add(orderClient);
            _context.Client.Include(x => x.Cart).Where(x => x.Email.Equals(user)).FirstOrDefault().Cart.Clear();
            await _context.SaveChangesAsync();
            
            if (ModelState.IsValid)
            {
                _context.Add(orderClient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Email", orderClient.ClientId);
            return RedirectToAction("Index", "Home");

        }

        // GET: OrderClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderClient = await _context.OrderClient.FindAsync(id);
            if (orderClient == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Email", orderClient.ClientId);
            return View(orderClient);
        }

        // POST: OrderClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,Creditcard,Totalprice,DateTime,City,Street,Buildingnumber,Apartmentnumber,Zipcode,Comment,Status")] OrderClient orderClient)
        {
            if (id != orderClient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderClient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderClientExists(orderClient.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Email", orderClient.ClientId);
            return View(orderClient);
        }

        // GET: OrderClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderClient = await _context.OrderClient
                .Include(o => o.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderClient == null)
            {
                return NotFound();
            }

            return View(orderClient);
        }

        // POST: OrderClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderClient = await _context.OrderClient.FindAsync(id);
            _context.OrderClient.Remove(orderClient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderClientExists(int id)
        {
            return _context.OrderClient.Any(e => e.Id == id);
        }
    }
}
