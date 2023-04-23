using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace ElectronicsStore.Controllers
{
    [Authorize]

    public class NuosxController : Controller
    {
        private readonly ElectronicsStoreContext _context;

        public NuosxController(ElectronicsStoreContext context)
        {
            _context = context;
        }

        // GET: Nuosx
        public async Task<IActionResult> Index()
        {
            ViewBag.Head = "Quản Lý Nước Sản Xuất";

            return View(await _context.Nuosx.Where(a => a.Active == 1).OrderByDescending(a => a.Idnsx).ToListAsync());
        }
        public async Task<IActionResult> TrashList(int id)
        {
            ViewBag.Head = "Khôi Phục Nước Sản Xuất";

            return View(await _context.Nuosx.Where(a => a.Active == 0).ToListAsync());
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var Nuosx = await _context.Nuosx
                .FirstOrDefaultAsync(m => m.Idnsx == id);
            Nuosx.Active = 1;
            _context.Update(Nuosx);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }

        // GET: Nuosx/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuosx = await _context.Nuosx
                .FirstOrDefaultAsync(m => m.Idnsx == id);
            if (nuosx == null)
            {
                return NotFound();
            }

            return View(nuosx);
        }

        // GET: Nuosx/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nuosx/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnsx,Mansx,Tennsx,Active")] Nuosx nuosx)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nuosx);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nuosx);
        }

        // GET: Nuosx/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuosx = await _context.Nuosx.FindAsync(id);
            if (nuosx == null)
            {
                return NotFound();
            }
            return View(nuosx);
        }

        // POST: Nuosx/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Nuosx nuosx)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    nuosx.Active = 1;
                    _context.Update(nuosx);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NuosxExists(nuosx.Idnsx))
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
            return View(nuosx);
        }

        // GET: Nuosx/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuosx = await _context.Nuosx
                .FirstOrDefaultAsync(m => m.Idnsx == id);
            if (nuosx == null)
            {
                return NotFound();
            }

            return View(nuosx);
        }

        // POST: Nuosx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nuosx = await _context.Nuosx.FindAsync(id);
            nuosx.Active = 0;
            _context.Nuosx.Update(nuosx);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NuosxExists(int id)
        {
            return _context.Nuosx.Any(e => e.Idnsx == id);
        }
    }
}
