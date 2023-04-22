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
    public class NhacungcapController : Controller
    {
        private readonly ElectronicsStoreContext _context;

        public NhacungcapController(ElectronicsStoreContext context)
        {
            _context = context;
        }

        // GET: Nhacungcap
        public async Task<IActionResult> Index()
        {
            ViewBag.Head = "Quản Lý Nhà Cung Cấp";


            return View(await _context.Nhacungcap.Where(a => a.Active == 1).OrderByDescending(a => a.Idncc).ToListAsync());
        }
        public async Task<IActionResult> TrashList(int id)
        {
            ViewBag.Head = "Khôi Phục Nhà Cung Cấp";

            return View(await _context.Nhacungcap.Where(a => a.Active == 0).ToListAsync());
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var Nhanvien = await _context.Nhacungcap
                .FirstOrDefaultAsync(m => m.Idncc == id);
            Nhanvien.Active = 1;
            _context.Update(Nhanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }

        // GET: Nhacungcap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcap
                .FirstOrDefaultAsync(m => m.Idncc == id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // GET: Nhacungcap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhacungcap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Nhacungcap nhacungcap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhacungcap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhacungcap);
        }

        // GET: Nhacungcap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcap.FindAsync(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            return View(nhacungcap);
        }

        // POST: Nhacungcap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Nhacungcap nhacungcap)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    nhacungcap.Active = 1;
                    _context.Update(nhacungcap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhacungcapExists(nhacungcap.Idncc))
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
            return View(nhacungcap);
        }

        // GET: Nhacungcap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcap
                .FirstOrDefaultAsync(m => m.Idncc == id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // POST: Nhacungcap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhacungcap = await _context.Nhacungcap.FindAsync(id);
            nhacungcap.Active = 0;
            _context.Nhacungcap.Update(nhacungcap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhacungcapExists(int id)
        {
            return _context.Nhacungcap.Any(e => e.Idncc == id);
        }
    }
}
