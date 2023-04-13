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
    public class DondathangController : Controller
    {
        private readonly ElectronicsStoreContext _context;

        public DondathangController(ElectronicsStoreContext context)
        {
            _context = context;
        }

        // GET: Dondathang
        public async Task<IActionResult> Index()
        {
            var electronicsStoreContext = await _context.Dondathang.Where(a => a.Active == 1).Include(p => p.IdkhNavigation).ToListAsync();

            ViewBag.Head = "Quản Lý Đơn Đặt Hàng";
            ViewData["Khachhang"] = await _context.Khachhang.Where(a => a.Active == 1).ToListAsync();
            ViewData["Hanghoa"] = await _context.Hanghoa.Where(a => a.Active == 1).ToListAsync();
            return View(electronicsStoreContext);
        }
        public async Task<IActionResult> TrashList(int id)
        {
            var electronicsStoreContext = await _context.Dondathang.Where(a => a.Active == 0).Include(p => p.IdkhNavigation).ToListAsync();

            ViewBag.Head = "Khôi Phục Đơn Đặt Hàng";
            return View(electronicsStoreContext);
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var dondathang = await _context.Dondathang
                .FirstOrDefaultAsync(m => m.Iddh == id);
            dondathang.Active = 1;
            _context.Update(dondathang);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }

        // GET: Dondathang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dondathang = await _context.Dondathang
                .Include(p => p.Idkh)
                .FirstOrDefaultAsync(m => m.Iddh == id);
            if (dondathang == null)
            {
                return NotFound();
            }

            return View(dondathang);
        }

        // GET: Dondathang/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Dondathang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dondathang dondathang)
        {
            if (ModelState.IsValid)
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                var nhanvien = await _context.Nhanvien.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
                dondathang.Ngaydat = DateTime.Now;
                dondathang.Trangthai = 0;

                dondathang.Madh = "DDH" + nhanvien.Manv + '-' + ((dondathang.Ngaydat).ToString()).Replace("/", "").Replace(" ", "");

                //Idnv từ đăng nhập
                _context.Add(dondathang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(dondathang);
        }

        // GET: Dondathang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dondathang = await _context.Dondathang.FindAsync(id);
            if (dondathang == null)
            {
                return NotFound();
            }

            return View(dondathang);
        }

        // POST: Dondathang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Dondathang dondathang)
        {


            //string employeeEmail = Request.Cookies["HienCaCookie"];
            //var nhanvien = await _context.Nhanvien.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
            //dondathang.Ngaydat = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    //dondathang.Madh = "DDH" + nhanvien.Manv + '-' + ((dondathang.Ngaydat).ToString()).Replace("/", "").Replace(" ", "");
                    dondathang.Active = 1;
                    _context.Update(dondathang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DondathangExists(dondathang.Iddh))
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

            return View(dondathang);
        }

        // GET: Dondathang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dondathang = await _context.Dondathang
                .Include(p => p.IdkhNavigation)
                .FirstOrDefaultAsync(m => m.Iddh == id);
            if (dondathang == null)
            {
                return NotFound();
            }

            return View(dondathang);
        }

        // POST: Dondathang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dondathang = await _context.Dondathang.FindAsync(id);
            dondathang.Active = 0;
            _context.Dondathang.Update(dondathang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DondathangExists(int id)
        {
            return _context.Dondathang.Any(e => e.Iddh == id);
        }
    }
}
