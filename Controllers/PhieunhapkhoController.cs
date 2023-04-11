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
    public class PhieunhapkhoController : Controller
    {
        private readonly ElectronicsStoreContext _context;

        public PhieunhapkhoController(ElectronicsStoreContext context)
        {
            _context = context;
        }

        // GET: Phieunhapkho
        public async Task<IActionResult> Index()
        {
            ViewBag.Head = "Quản Lý Phiếu Nhập Kho";

            var electronicsStoreContext = _context.Phieunhapkho.Where(a => a.Active == 1).Include(p => p.IdnccNavigation).Include(p => p.IdnvNavigation);
            return View(await electronicsStoreContext.ToListAsync());

        }
        public async Task<IActionResult> TrashList(int id)
        {
            ViewBag.Head = "Khôi Phục Phiếu Nhập Kho";

            var electronicsStoreContext = _context.Phieunhapkho.Where(a => a.Active == 0).Include(p => p.IdnccNavigation).Include(p => p.IdnvNavigation);
            return View(await electronicsStoreContext.ToListAsync());
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var Phieunhapkho = await _context.Phieunhapkho
                .FirstOrDefaultAsync(m => m.Idpnk == id);
            Phieunhapkho.Active = 1;
            _context.Update(Phieunhapkho);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }

        // GET: Phieunhapkho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieunhapkho = await _context.Phieunhapkho
                .Include(p => p.IdnccNavigation)
                .Include(p => p.IdnvNavigation)
                .FirstOrDefaultAsync(m => m.Idpnk == id);
            if (phieunhapkho == null)
            {
                return NotFound();
            }

            return View(phieunhapkho);
        }

        // GET: Phieunhapkho/Create
        public IActionResult Create()
        {
            ViewData["Idncc"] = new SelectList(_context.Nhacungcap, "Idncc", "Diachi");
            ViewData["Idnv"] = new SelectList(_context.Nhanvien, "Idnv", "Diachi");
            return View();
        }

        // POST: Phieunhapkho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idpnk,Sophieu,Ngaylap,Sohd,Ngayhd,Ghichu,Active,Idncc,Idnv")] Phieunhapkho phieunhapkho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phieunhapkho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idncc"] = new SelectList(_context.Nhacungcap, "Idncc", "Diachi", phieunhapkho.Idncc);
            ViewData["Idnv"] = new SelectList(_context.Nhanvien, "Idnv", "Diachi", phieunhapkho.Idnv);
            return View(phieunhapkho);
        }

        // GET: Phieunhapkho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieunhapkho = await _context.Phieunhapkho.FindAsync(id);
            if (phieunhapkho == null)
            {
                return NotFound();
            }
            ViewData["Idncc"] = new SelectList(_context.Nhacungcap, "Idncc", "Diachi", phieunhapkho.Idncc);
            ViewData["Idnv"] = new SelectList(_context.Nhanvien, "Idnv", "Diachi", phieunhapkho.Idnv);
            return View(phieunhapkho);
        }

        // POST: Phieunhapkho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Phieunhapkho phieunhapkho)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    phieunhapkho.Active = 1;
                    _context.Update(phieunhapkho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieunhapkhoExists(phieunhapkho.Idpnk))
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
            ViewData["Idncc"] = new SelectList(_context.Nhacungcap, "Idncc", "Diachi", phieunhapkho.Idncc);
            ViewData["Idnv"] = new SelectList(_context.Nhanvien, "Idnv", "Diachi", phieunhapkho.Idnv);
            return View(phieunhapkho);
        }

        // GET: Phieunhapkho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieunhapkho = await _context.Phieunhapkho
                .Include(p => p.IdnccNavigation)
                .Include(p => p.IdnvNavigation)
                .FirstOrDefaultAsync(m => m.Idpnk == id);
            if (phieunhapkho == null)
            {
                return NotFound();
            }

            return View(phieunhapkho);
        }

        // POST: Phieunhapkho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieunhapkho = await _context.Phieunhapkho.FindAsync(id);
            phieunhapkho.Active = 0;
            _context.Phieunhapkho.Update(phieunhapkho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieunhapkhoExists(int id)
        {
            return _context.Phieunhapkho.Any(e => e.Idpnk == id);
        }
    }
}
