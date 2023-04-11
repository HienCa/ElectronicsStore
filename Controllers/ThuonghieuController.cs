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
    public class ThuonghieuController : Controller
    {
        private readonly ElectronicsStoreContext _context;

        public ThuonghieuController(ElectronicsStoreContext context)
        {
            _context = context;
        }

        // GET: Thuonghieu
        public async Task<IActionResult> Index()
        {
            ViewBag.Head = "Quản Lý Thương Hiệu";

            return View(await _context.Thuonghieu.Where(a => a.Active == 1).ToListAsync());
        }
        public async Task<IActionResult> TrashList(int id)
        {
            ViewBag.Head = "Khôi Phục Thương Hiệu";

            return View(await _context.Thuonghieu.Where(a => a.Active == 0).ToListAsync());
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var Thuonghieu = await _context.Thuonghieu
                .FirstOrDefaultAsync(m => m.Idth == id);
            Thuonghieu.Active = 1;
            _context.Update(Thuonghieu);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }
        // GET: Thuonghieu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuonghieu = await _context.Thuonghieu
                .FirstOrDefaultAsync(m => m.Idth == id);
            if (thuonghieu == null)
            {
                return NotFound();
            }

            return View(thuonghieu);
        }

        // GET: Thuonghieu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thuonghieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idth,Math,Tenth,Active")] Thuonghieu thuonghieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuonghieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thuonghieu);
        }

        // GET: Thuonghieu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuonghieu = await _context.Thuonghieu.FindAsync(id);
            if (thuonghieu == null)
            {
                return NotFound();
            }
            return View(thuonghieu);
        }

        // POST: Thuonghieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Thuonghieu thuonghieu)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    thuonghieu.Active = 1;
                    _context.Update(thuonghieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuonghieuExists(thuonghieu.Idth))
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
            return View(thuonghieu);
        }

        // GET: Thuonghieu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuonghieu = await _context.Thuonghieu
                .FirstOrDefaultAsync(m => m.Idth == id);
            if (thuonghieu == null)
            {
                return NotFound();
            }

            return View(thuonghieu);
        }

        // POST: Thuonghieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thuonghieu = await _context.Thuonghieu.FindAsync(id);
            thuonghieu.Active = 0;
            _context.Thuonghieu.Update(thuonghieu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuonghieuExists(int id)
        {
            return _context.Thuonghieu.Any(e => e.Idth == id);
        }
    }
}
