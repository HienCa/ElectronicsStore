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

    public class NhomhhController : Controller
    {
        private readonly ElectronicsStoreContext _context;

        public NhomhhController(ElectronicsStoreContext context)
        {
            _context = context;
        }

        // GET: Nhomhh
        public async Task<IActionResult> Index()
        {
            ViewBag.Head = "Quản Lý Nhóm Hàng Hóa";

            return View(await _context.Nhomhh.Where(a=>a.Active==1).OrderByDescending(a => a.Idnhh).ToListAsync());
        }
        public async Task<IActionResult> TrashList(int id)
        {
            ViewBag.Head = "Khôi Phục Nhóm Hàng Hóa";

            return View(await _context.Nhomhh.Where(a => a.Active == 0).ToListAsync());
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var nhomhh = await _context.Nhomhh
                .FirstOrDefaultAsync(m => m.Idnhh == id);
            nhomhh.Active = 1;
            _context.Update(nhomhh);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }
        // GET: Nhomhh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhomhh = await _context.Nhomhh
                .FirstOrDefaultAsync(m => m.Idnhh == id);
            if (nhomhh == null)
            {
                return NotFound();
            }

            return View(nhomhh);
        }

        // GET: Nhomhh/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhomhh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnhh,Manhh,Tennhh,Active")] Nhomhh nhomhh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhomhh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhomhh);
        }

        // GET: Nhomhh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhomhh = await _context.Nhomhh.FindAsync(id);
            if (nhomhh == null)
            {
                return NotFound();
            }
            return View(nhomhh);
        }

        // POST: Nhomhh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Nhomhh nhomhh)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    nhomhh.Active = 1;

                    _context.Update(nhomhh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhomhhExists(nhomhh.Idnhh))
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
            return View(nhomhh);
        }

        // GET: Nhomhh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhomhh = await _context.Nhomhh
                .FirstOrDefaultAsync(m => m.Idnhh == id);
            if (nhomhh == null)
            {
                return NotFound();
            }

            return View(nhomhh);
        }

        // POST: Nhomhh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhomhh = await _context.Nhomhh.FindAsync(id);
            nhomhh.Active = 0;
            _context.Nhomhh.Update(nhomhh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhomhhExists(int id)
        {
            return _context.Nhomhh.Any(e => e.Idnhh == id);
        }
    }
}
