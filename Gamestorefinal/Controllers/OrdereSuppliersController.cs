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
    public class OrdereSuppliersController : Controller
    {
        private readonly GamestorefinalContext _context;

        public OrdereSuppliersController(GamestorefinalContext context)
        {
            _context = context;
        }

        // GET: OrdereSuppliers
        public async Task<IActionResult> Index()
        {
            var gamestorefinalContext = _context.OrdereSupplier.Include(o => o.Supplier);
            return View(await gamestorefinalContext.ToListAsync());
        }

        // GET: OrdereSuppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordereSupplier = await _context.OrdereSupplier
                .Include(o => o.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordereSupplier == null)
            {
                return NotFound();
            }

            return View(ordereSupplier);
        }

        // GET: OrdereSuppliers/Create
        public IActionResult Create(int gameid)
        {
            //ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Email");
            ViewBag.Supplierslist = _context.Supplier.Include(x=>x.Games);
            ViewBag.gname = _context.Games.Where(x => x.Id.Equals(gameid)).FirstOrDefault();
            ViewBag.sgame = _context.Games.Include(x=>x.Suppliers).Where(a=>a.Id.Equals(gameid));
            ViewBag.supor = _context.Games.Include(x => x.Suppliers).Where(a => a.Id.Equals(gameid)).FirstOrDefault().Suppliers;
            return View();
        }

        // POST: OrdereSuppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SupplierId,Totalprice")] OrdereSupplier ordereSupplier,int gameidorder,int count)
        {
            ordereSupplier.GamesforOrder = new List<Games>();
            ordereSupplier.GamesforOrder.Add(_context.Games.Include(x => x.Category).Include(x => x.Suppliers).Where(a => a.Id.Equals(gameidorder)).FirstOrDefault());
            ordereSupplier.countofgames = new List<int>();
            ordereSupplier.countofgames.Add(count);
            ordereSupplier.Supplier = _context.Supplier.Include(a => a.Games).Where(x => x.Id.Equals(ordereSupplier.SupplierId)).FirstOrDefault();
            _context.Games.Where(x => x.Id == gameidorder).FirstOrDefault().Onstock += count;
            await _context.SaveChangesAsync();
            if (ModelState.IsValid)
            {
                _context.Add(ordereSupplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Email", ordereSupplier.SupplierId);
           return RedirectToAction("Index", "Games");
        }

        // GET: OrdereSuppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordereSupplier = await _context.OrdereSupplier.FindAsync(id);
            if (ordereSupplier == null)
            {
                return NotFound();
            }
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Email", ordereSupplier.SupplierId);
            return View(ordereSupplier);
        }

        // POST: OrdereSuppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SupplierId,Totalprice")] OrdereSupplier ordereSupplier)
        {
            if (id != ordereSupplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordereSupplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdereSupplierExists(ordereSupplier.Id))
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
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Email", ordereSupplier.SupplierId);
            return View(ordereSupplier);
        }

        // GET: OrdereSuppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordereSupplier = await _context.OrdereSupplier
                .Include(o => o.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordereSupplier == null)
            {
                return NotFound();
            }

            return View(ordereSupplier);
        }

        // POST: OrdereSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordereSupplier = await _context.OrdereSupplier.FindAsync(id);
            _context.OrdereSupplier.Remove(ordereSupplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdereSupplierExists(int id)
        {
            return _context.OrdereSupplier.Any(e => e.Id == id);
        }
    }
}
