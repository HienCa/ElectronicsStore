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
    //[Authorize]

    public class PhieuxuatkhoController : Controller
    {
        private readonly ElectronicsStoreContext _context;

        public PhieuxuatkhoController(ElectronicsStoreContext context)
        {
            _context = context;
        }

        // GET: Phieuxuatkho
        public async Task<IActionResult> Index()
        {
            var electronicsStoreContext = await _context.Phieuxuatkho.Where(a => a.Active == 1).Include(p => p.IdkhNavigation).Include(p => p.IdnvNavigation).ToListAsync();

            ViewBag.Head = "Quản Lý Phiếu Xuất Kho";
            ViewData["Nhanvien"] = await _context.Nhanvien.Where(a => a.Active == 1).ToListAsync();
            ViewData["Khachhang"] = await _context.Khachhang.Where(a => a.Active == 1).ToListAsync();
            return View(electronicsStoreContext);
        }
        public async Task<IActionResult> TrashList(int id)
        {
            var electronicsStoreContext = await _context.Phieuxuatkho.Where(a => a.Active == 0).Include(p => p.IdkhNavigation).Include(p => p.IdnvNavigation).ToListAsync();

            ViewBag.Head = "Khôi Phục Phiếu Xuất Kho";
            return View(electronicsStoreContext);
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var phieuxuatkho = await _context.Phieuxuatkho
                .FirstOrDefaultAsync(m => m.Idpxk == id);
            phieuxuatkho.Active = 1;
            _context.Update(phieuxuatkho);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }

        // GET: Phieuxuatkho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            TempData["Noidungpxk"] = await _context.Noidungpxk
               .Include(n => n.IdpxkNavigation).Include(n => n.IdpxkNavigation.IdnvNavigation)
               .Include(n => n.IdhhNavigation)
               .Where(pn => pn.Idpxk == id)
               .ToListAsync();
            TempData["Phieuxuatkho"] = await _context.Phieuxuatkho
               .Include(p => p.IdkhNavigation)
               .Include(p => p.IdnvNavigation)
               .FirstOrDefaultAsync(m => m.Idpxk == id);
            TempData["Hinhthucthanhtoan"] = await _context.Hinhthucthanhtoan.Where(a => a.Active == 1).ToListAsync();

            TempData["Noidungthunokh"] = await _context.Noidungthunokh
               .Include(n => n.IdpxkNavigation).Include(n => n.IdpxkNavigation.IdnvNavigation)
               .Include(n => n.IdptnkhNavigation)
               .Where(pn => pn.Idpxk == id)
               .ToListAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Fillter(int? Idpxk, int Idhh)
        {


            TempData["Noidungpxk"] = await _context.Noidungpxk
               .Include(n => n.IdpxkNavigation).Include(n => n.IdpxkNavigation.IdnvNavigation)
               .Include(n => n.IdhhNavigation)
               .Where(pn => pn.Idpxk == Idpxk)
               .ToListAsync();
            TempData["Phieuxuatkho"] = await _context.Phieuxuatkho
               .Include(p => p.IdkhNavigation)
               .Include(p => p.IdnvNavigation)
               .FirstOrDefaultAsync(m => m.Idpxk == Idpxk);
            TempData["Hinhthucthanhtoan"] = await _context.Hinhthucthanhtoan.Where(a => a.Active == 1).ToListAsync();

            TempData["Noidungthunokh"] = await _context.Noidungthunokh
               .Include(n => n.IdpxkNavigation).Include(n => n.IdpxkNavigation.IdnvNavigation)
               .Include(n => n.IdptnkhNavigation)
               .Where(pn => pn.Idpxk == Idpxk)
               .ToListAsync();

            List<Noidungpnk> HanghoaCanXuat = await _context.Noidungpnk
                                                                .Where(a => a.Idhh == Idhh)
                                                                .Where(a => a.Soluong > 0)
                                                                .OrderByDescending(c => c.Hansd)
                                                                .Include(hh => hh.IdhhNavigation)
                                                                .ToListAsync();
            List<Noidungpxk> HanghoaDaXuat = await _context.Noidungpxk
                                                                .Where(a => a.Idhh == Idhh)
                                                                .ToListAsync();

            TempData["ThongTinHanghoa"] = await _context.Hanghoa.Where(a => a.Idhh == Idhh).FirstOrDefaultAsync();

            float tongSoLuongNhap = HanghoaCanXuat.Sum(hh => hh.Soluong);
            float tongSoLuongXuat = HanghoaDaXuat.Sum(hh => hh.Soluong);


            TempData["SoLuongCon"] = tongSoLuongNhap - tongSoLuongXuat;
            TempData["HanghoaCanXuat"] = HanghoaCanXuat;

            return View();
        }
        // GET: Phieuxuatkho/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Phieuxuatkho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Phieuxuatkho phieuxuatkho)
        {
            if (ModelState.IsValid)
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                var nhanvien = await _context.Nhanvien.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();

                phieuxuatkho.Ngaylap = DateTime.Now;
                if (phieuxuatkho.Sophieu == null)
                {
                    phieuxuatkho.Sophieu = "PXK" + nhanvien.Manv + '-' + ((phieuxuatkho.Ngaylap).ToString()).Replace("/", "").Replace(" ", "");
                }
                phieuxuatkho.Idnv = nhanvien.Idnv;
                //Idnv từ đăng nhập
                _context.Add(phieuxuatkho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(phieuxuatkho);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Actions(Noidungpxk noidungphieuxuatkho, string action)
        {

            if (action == "addItem")
            {
                Noidungpxk isExist = await _context.Noidungpxk.Where(pxk => pxk.Idpxk == noidungphieuxuatkho.Idpxk).Where(pxk => pxk.Idhh == noidungphieuxuatkho.Idhh).FirstOrDefaultAsync();
                if (isExist == null || noidungphieuxuatkho.Dongia != isExist.Dongia)
                {
                    _context.Add(noidungphieuxuatkho);
                }
                else
                {
                    isExist.Soluong += noidungphieuxuatkho.Soluong;
                    _context.Update(isExist);
                }

                await _context.SaveChangesAsync();

            }
            if (action == "editItem")
            {
                Noidungpxk isExist = await _context.Noidungpxk.Where(pxk => pxk.Idndpxk == noidungphieuxuatkho.Idndpxk).Where(pxk => pxk.Idhh == noidungphieuxuatkho.Idhh).Where(pxk => pxk.Dongia == noidungphieuxuatkho.Dongia).FirstOrDefaultAsync();
                isExist.Soluong = noidungphieuxuatkho.Soluong;
                _context.Update(isExist);
                await _context.SaveChangesAsync();
            }
            if (action == "deleteItem")
            {
              
                Noidungpxk Noidungpxk = await _context.Noidungpxk.Where(pxk => pxk.Idndpxk == noidungphieuxuatkho.Idndpxk).FirstOrDefaultAsync();
                _context.Noidungpxk.Remove(Noidungpxk);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Phieuxuatkho", new { id = noidungphieuxuatkho.Idpxk });


        }

        // GET: Phieuxuatkho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuxuatkho = await _context.Phieuxuatkho.FindAsync(id);
            if (phieuxuatkho == null)
            {
                return NotFound();
            }

            return View(phieuxuatkho);
        }

        // POST: Phieuxuatkho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Phieuxuatkho phieuxuatkho)
        {


            string employeeEmail = Request.Cookies["HienCaCookie"];
            var nhanvien = await _context.Nhanvien.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
            phieuxuatkho.Idnv = nhanvien.Idnv;
            phieuxuatkho.Ngaylap = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    phieuxuatkho.Active = 1;
                    _context.Update(phieuxuatkho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuxuatkhoExists(phieuxuatkho.Idpxk))
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

            return View(phieuxuatkho);
        }

        // GET: Phieuxuatkho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuxuatkho = await _context.Phieuxuatkho
                .Include(p => p.Idkh)
                .Include(p => p.IdnvNavigation)
                .FirstOrDefaultAsync(m => m.Idpxk == id);
            if (phieuxuatkho == null)
            {
                return NotFound();
            }

            return View(phieuxuatkho);
        }

        // POST: Phieuxuatkho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieuxuatkho = await _context.Phieuxuatkho.FindAsync(id);
            phieuxuatkho.Active = 0;
            _context.Phieuxuatkho.Update(phieuxuatkho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuxuatkhoExists(int id)
        {
            return _context.Phieuxuatkho.Any(e => e.Idpxk == id);
        }
    }
}
