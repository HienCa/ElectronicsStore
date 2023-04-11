using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Models;

namespace ElectronicsStore.Controllers
{
    public class HinhthucthanhtoanController : Controller
    {
        private readonly ElectronicsStoreContext _context;

        public HinhthucthanhtoanController(ElectronicsStoreContext context)
        {
            _context = context;
        }

        // GET: Hinhthucthanhtoan
        public async Task<IActionResult> Index()
        {
            ViewBag.Head = "Quản Lý Hình Thức Thanh Toán";

            return View(await _context.Hinhthucthanhtoan.Where(a => a.Active == 1).ToListAsync());
        }
        public async Task<IActionResult> TrashList(int id)
        {
            ViewBag.Head = "Khôi Phục Hình Thức Thanh Toán";

            return View(await _context.Hinhthucthanhtoan.Where(a => a.Active == 0).ToListAsync());
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var Hinhthucthanhtoan = await _context.Hinhthucthanhtoan
                .FirstOrDefaultAsync(m => m.Idhttt == id);
            Hinhthucthanhtoan.Active = 1;
            _context.Update(Hinhthucthanhtoan);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }

        // GET: Hinhthucthanhtoan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhthucthanhtoan = await _context.Hinhthucthanhtoan
                .FirstOrDefaultAsync(m => m.Idhttt == id);
            if (hinhthucthanhtoan == null)
            {
                return NotFound();
            }

            return View(hinhthucthanhtoan);
        }

        // GET: Hinhthucthanhtoan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hinhthucthanhtoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idhttt,Mahttt,Tenhttt,Active")] Hinhthucthanhtoan hinhthucthanhtoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hinhthucthanhtoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hinhthucthanhtoan);
        }

        // GET: Hinhthucthanhtoan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhthucthanhtoan = await _context.Hinhthucthanhtoan.FindAsync(id);
            if (hinhthucthanhtoan == null)
            {
                return NotFound();
            }
            return View(hinhthucthanhtoan);
        }

        // POST: Hinhthucthanhtoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Hinhthucthanhtoan hinhthucthanhtoan)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    hinhthucthanhtoan.Active = 1;
                    _context.Update(hinhthucthanhtoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HinhthucthanhtoanExists(hinhthucthanhtoan.Idhttt))
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
            return View(hinhthucthanhtoan);
        }

        // GET: Hinhthucthanhtoan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhthucthanhtoan = await _context.Hinhthucthanhtoan
                .FirstOrDefaultAsync(m => m.Idhttt == id);
            if (hinhthucthanhtoan == null)
            {
                return NotFound();
            }

            return View(hinhthucthanhtoan);
        }

        // POST: Hinhthucthanhtoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hinhthucthanhtoan = await _context.Hinhthucthanhtoan.FindAsync(id);
            hinhthucthanhtoan.Active = 0;
            _context.Hinhthucthanhtoan.Update(hinhthucthanhtoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HinhthucthanhtoanExists(int id)
        {
            return _context.Hinhthucthanhtoan.Any(e => e.Idhttt == id);
        }
    }
}
