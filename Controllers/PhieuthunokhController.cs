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

    public class PhieuthunokhController : Controller
    {
        private readonly ElectronicsStoreContext _context;

        public PhieuthunokhController(ElectronicsStoreContext context)
        {
            _context = context;
        }

        // GET: Phieuthunokh
        public async Task<IActionResult> Index()
        {
            var electronicsStoreContext = await _context.Phieuthunokh.Where(a => a.Active == 1).Include(p => p.IdhtttNavigation).Include(p => p.IdnvNavigation).ToListAsync();

            ViewBag.Head = "Quản Lý Phiếu Thu Nợ Khách Hàng";
            ViewData["Nhanvien"] = await _context.Nhanvien.Where(a => a.Active == 1).ToListAsync();
            ViewData["Hinhthucthanhtoan"] = await _context.Hinhthucthanhtoan.Where(a => a.Active == 1).ToListAsync();
            return View(electronicsStoreContext);
        }
        public async Task<IActionResult> TrashList(int id)
        {
            var electronicsStoreContext = await _context.Phieuthunokh.Where(a => a.Active == 0).Include(p => p.IdhtttNavigation).Include(p => p.IdnvNavigation).ToListAsync();

            ViewBag.Head = "Khôi Phục Phiếu Thu Nợ Khách Hàng";

            return View(electronicsStoreContext);
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var phieuthunokh = await _context.Phieuthunokh
                .FirstOrDefaultAsync(m => m.Idptnkh == id);
            phieuthunokh.Active = 1;
            _context.Update(phieuthunokh);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }

        // GET: Phieuthunokh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthunokh = await _context.Phieuthunokh
                .Include(p => p.IdhtttNavigation)
                .Include(p => p.IdnvNavigation)
                .FirstOrDefaultAsync(m => m.Idptnkh == id);
            if (phieuthunokh == null)
            {
                return NotFound();
            }

            return View(phieuthunokh);
        }

        // GET: Phieuthunokh/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Phieuthunokh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Phieuthunokh phieuthunokh)
        {
            if (ModelState.IsValid)
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                var nhanvien = await _context.Nhanvien.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();

                phieuthunokh.Ngaylap = DateTime.Now;
                if (phieuthunokh.Sophieu == null)
                {
                    phieuthunokh.Sophieu = "PTN" + nhanvien.Manv +'-'+ ((phieuthunokh.Ngaylap).ToString()).Replace("/", "").Replace(" ", "");
                }
                phieuthunokh.Idnv = nhanvien.Idnv;
                //Idnv từ đăng nhập
                _context.Add(phieuthunokh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(phieuthunokh);
        }

        // GET: Phieuthunokh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthunokh = await _context.Phieuthunokh.FindAsync(id);
            if (phieuthunokh == null)
            {
                return NotFound();
            }

            return View(phieuthunokh);
        }

        // POST: Phieuthunokh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Phieuthunokh phieuthunokh)
        {


            string employeeEmail = Request.Cookies["HienCaCookie"];
            var nhanvien = await _context.Nhanvien.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
            phieuthunokh.Idnv = nhanvien.Idnv;
            phieuthunokh.Ngaylap = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    phieuthunokh.Active = 1;
                    _context.Update(phieuthunokh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuthunokhExists(phieuthunokh.Idptnkh))
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

            return View(phieuthunokh);
        }

        // GET: Phieuthunokh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthunokh = await _context.Phieuthunokh
                .Include(p => p.IdhtttNavigation)
                .Include(p => p.IdnvNavigation)
                .FirstOrDefaultAsync(m => m.Idptnkh == id);
            if (phieuthunokh == null)
            {
                return NotFound();
            }

            return View(phieuthunokh);
        }

        // POST: Phieuthunokh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieuthunokh = await _context.Phieuthunokh.FindAsync(id);
            phieuthunokh.Active = 0;
            _context.Phieuthunokh.Update(phieuthunokh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuthunokhExists(int id)
        {
            return _context.Phieuthunokh.Any(e => e.Idptnkh == id);
        }
    }
}
