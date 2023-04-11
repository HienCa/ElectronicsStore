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
    public class NganhangController : Controller
    {
        private readonly ElectronicsStoreContext _context;

        public NganhangController(ElectronicsStoreContext context)
        {
            _context = context;
        }

        // GET: Nganhang
        public async Task<IActionResult> Index()
        {
            ViewBag.Head = "Quản Lý Thông Tin STK Ngân Hàng";

            var electronicsStoreContext = _context.Nganhang.Where(a => a.Active == 1).Include(n => n.IdhtttNavigation);
            return View(await electronicsStoreContext.ToListAsync());


        }
        public async Task<IActionResult> TrashList(int id)
        {
            ViewBag.Head = "Khôi Phục Thông Tin STK Ngân Hàng";
            var electronicsStoreContext = _context.Nganhang.Where(a => a.Active == 0).Include(n => n.IdhtttNavigation);
            return View(await electronicsStoreContext.ToListAsync());
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var Nganhang = await _context.Nganhang
                .FirstOrDefaultAsync(m => m.Idnh == id);
            Nganhang.Active = 1;
            _context.Update(Nganhang);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }

        // GET: Nganhang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganhang = await _context.Nganhang
                .Include(n => n.IdhtttNavigation)
                .FirstOrDefaultAsync(m => m.Idnh == id);
            if (nganhang == null)
            {
                return NotFound();
            }

            return View(nganhang);
        }

        // GET: Nganhang/Create
        public IActionResult Create()
        {
            ViewData["Idhttt"] = new SelectList(_context.Hinhthucthanhtoan, "Idhttt", "Tenhttt");
            return View();
        }

        // POST: Nganhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnh,Tennh,Diachi,Email,Masothue,Ghichu,Active,Idhttt")] Nganhang nganhang)
        {
            if (ModelState.IsValid)
            {
                nganhang.Idhttt = 2;
                _context.Add(nganhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idhttt"] = new SelectList(_context.Hinhthucthanhtoan, "Idhttt", "Tenhttt", nganhang.Idhttt);
            return View(nganhang);
        }

        // GET: Nganhang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganhang = await _context.Nganhang.FindAsync(id);
            if (nganhang == null)
            {
                return NotFound();
            }
            ViewData["Idhttt"] = new SelectList(_context.Hinhthucthanhtoan, "Idhttt", "Tenhttt", nganhang.Idhttt);
            return View(nganhang);
        }

        // POST: Nganhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Nganhang nganhang)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    nganhang.Active = 1;
                    nganhang.Idhttt = 2;

                    _context.Update(nganhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NganhangExists(nganhang.Idnh))
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
            ViewData["Idhttt"] = new SelectList(_context.Hinhthucthanhtoan, "Idhttt", "Tenhttt", nganhang.Idhttt);
            return View(nganhang);
        }

        // GET: Nganhang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganhang = await _context.Nganhang
                .Include(n => n.IdhtttNavigation)
                .FirstOrDefaultAsync(m => m.Idnh == id);
            if (nganhang == null)
            {
                return NotFound();
            }

            return View(nganhang);
        }

        // POST: Nganhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nganhang = await _context.Nganhang.FindAsync(id);
            nganhang.Active = 0;
            _context.Nganhang.Update(nganhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NganhangExists(int id)
        {
            return _context.Nganhang.Any(e => e.Idnh == id);
        }
    }
}
