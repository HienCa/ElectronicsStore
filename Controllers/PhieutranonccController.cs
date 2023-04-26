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

    public class PhieutranonccController : Controller
    {
        private readonly ElectronicsStoreContext _context;

        public PhieutranonccController(ElectronicsStoreContext context)
        {
            _context = context;
        }

        // GET: Phieutranoncc
        public async Task<IActionResult> Index()
        {
            var electronicsStoreContext = await _context.Phieutranoncc.Where(a => a.Active == 1).Include(p => p.IdhtttNavigation).Include(p => p.IdnvNavigation).OrderByDescending(a => a.Idptnncc).ToListAsync();

            ViewBag.Head = "Quản Lý Phiếu Trả Nợ Nhà Cung Cấp";
            ViewData["Nhanvien"] = await _context.Nhanvien.Where(a => a.Active == 1).ToListAsync();
            ViewData["Hinhthucthanhtoan"] = await _context.Hinhthucthanhtoan.Where(a => a.Active == 1).ToListAsync();
            return View(electronicsStoreContext);
        }
        public async Task<IActionResult> TrashList(int id)
        {
            var electronicsStoreContext = await _context.Phieutranoncc.Where(a => a.Active == 0).Include(p => p.IdhtttNavigation).Include(p => p.IdnvNavigation).ToListAsync();

            ViewBag.Head = "Khôi Phục Phiếu Trả Nợ Nhà Cung Cấp";

            return View(electronicsStoreContext);
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var phieutranoncc = await _context.Phieutranoncc
                .FirstOrDefaultAsync(m => m.Idptnncc == id);
            phieutranoncc.Active = 1;
            _context.Update(phieutranoncc);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }

        // GET: Phieutranoncc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var phieuthunoncc = await _context.Noidungtranoncc
                .Include(p => p.IdptnnccNavigation)
                .Include(p => p.IdptnnccNavigation.IdnvNavigation)
                .Where(m => m.Idptnncc == id)
                .ToListAsync();
                if (phieuthunoncc == null)
                {
                    return RedirectToAction("Index", "Phieuthunoncc");

                }

                var phieuthunokh = await _context.Noidungtranoncc
                                                   .Include(p => p.IdptnnccNavigation)
                                                   .Include(p => p.IdptnnccNavigation.IdnvNavigation)
                                                   .Where(m => m.Idptnncc == id)
                                                   .ToListAsync();

                var ndphieutrano = await _context.Noidungtranoncc.Where(a => a.Idptnncc == id)
                                                           .FirstOrDefaultAsync();
                ViewData["Noidungncc"] = ndphieutrano;

                var Sotiendatra = _context.Noidungtranoncc
                                                      .Include(p => p.IdptnnccNavigation)
                                                      .Include(p => p.IdptnnccNavigation.IdnvNavigation)
                                                      .Where(m => m.Idptnncc == id).Sum(s => s.Sotien);

                var Sotienphaitra = _context.Noidungpnk
                                                    .Include(p => p.IdhhNavigation)
                                                    .Include(p => p.IdpnkNavigation)
                                                    .Where(m => m.IdpnkNavigation.Idpnk == ndphieutrano.Idpnk).Sum(a => a.Soluong * a.Dongia);

                if (Sotienphaitra - Sotiendatra == 0)
                {
                    ViewData["Sotienconno"] = 0;
                    ViewData["MaxSotienconno"] = (float)0;
                }
                else
                {
                    ViewData["MaxSotienconno"] = Sotienphaitra - Sotiendatra;
                    ViewData["Sotienconno"] = 1;

                }
                
                return View(phieuthunoncc);

            }
            catch
            {
                return RedirectToAction("Index", "Phieuthunoncc");

            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Themnoidungphieutranoncc(Noidungtranoncc noidung)
        {
            try
            {
                noidung.Ngaytrano = DateTime.Now;

                _context.Noidungtranoncc.Add(noidung);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Phieutranoncc", new { id = noidung.Idptnncc });

            }
            catch
            {
                return RedirectToAction("Index", "Phieutranoncc");
            }
        }
        // GET: Phieutranoncc/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Phieutranoncc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Phieutranoncc phieutranoncc, int Idpnk)
        {
            if (ModelState.IsValid)
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                var nhanvien = await _context.Nhanvien.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();

                phieutranoncc.Ngaylap = DateTime.Now;
                if (phieutranoncc.Sophieu == null)
                {
                    phieutranoncc.Sophieu = "PTN" + nhanvien.Manv + '-' + ((phieutranoncc.Ngaylap).ToString()).Replace("/", "").Replace(" ", "");
                }
                phieutranoncc.Idnv = nhanvien.Idnv;
                //Idnv từ đăng nhập
                _context.Add(phieutranoncc);
                await _context.SaveChangesAsync();

                TempData["SoPhieu"] = phieutranoncc.Sophieu;
                var phieutrano = _context.Phieutranoncc.Where(e => (e.Idnv).Equals(nhanvien.Idnv)).Where(e => (e.Sophieu).Equals(phieutranoncc.Sophieu)).FirstOrDefault();

                TempData["phieutrano"] = phieutrano.Idptnncc;
                return RedirectToAction("Details", "Phieunhapkho", new { id = Idpnk });

            }

            return RedirectToAction("Details", "Phieunhapkho", new { id = Idpnk });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Actions(Noidungtranoncc noidungphieutrano, string action)
        {
            noidungphieutrano.Ngaytrano = DateTime.Now;

            if (action == "addItem")
            {

                _context.Add(noidungphieutrano);
                await _context.SaveChangesAsync();
            }
            if (action == "editItem")
            {
                var Phieutranoncc = await _context.Phieutranoncc.FindAsync(noidungphieutrano.Idptnncc);

                noidungphieutrano.Ngaytrano = Phieutranoncc.Ngaylap;
                _context.Update(noidungphieutrano);
                await _context.SaveChangesAsync();
            }
            if (action == "deleteItem")
            {
                var Noidung = _context.Noidungtranoncc.Where(id=>id.Idndtnncc == noidungphieutrano.Idndtnncc).FirstOrDefault();
                //var phieutra = _context.Phieutranoncc.Where(id => id.Idptnncc == noidungphieutrano.Idptnncc).FirstOrDefault();

                _context.Noidungtranoncc.Remove(Noidung);
                //_context.Phieutranoncc.Remove(phieutra);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Phieunhapkho", new { id = noidungphieutrano.Idpnk });


        }

        // GET: Phieutranoncc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieutranoncc = await _context.Phieutranoncc.FindAsync(id);
            if (phieutranoncc == null)
            {
                return NotFound();
            }

            return View(phieutranoncc);
        }

        // POST: Phieutranoncc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Phieutranoncc phieutranoncc)
        {


            string employeeEmail = Request.Cookies["HienCaCookie"];
            var nhanvien = await _context.Nhanvien.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
            phieutranoncc.Idnv = nhanvien.Idnv;
            phieutranoncc.Ngaylap = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    phieutranoncc.Active = 1;
                    _context.Update(phieutranoncc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieutranonccExists(phieutranoncc.Idptnncc))
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

            return View(phieutranoncc);
        }

        // GET: Phieutranoncc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieutranoncc = await _context.Phieutranoncc
                .Include(p => p.IdhtttNavigation)
                .Include(p => p.IdnvNavigation)
                .FirstOrDefaultAsync(m => m.Idptnncc == id);
            if (phieutranoncc == null)
            {
                return NotFound();
            }

            return View(phieutranoncc);
        }

        // POST: Phieutranoncc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieutranoncc = await _context.Phieutranoncc.FindAsync(id);
            phieutranoncc.Active = 0;
            _context.Phieutranoncc.Update(phieutranoncc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieutranonccExists(int id)
        {
            return _context.Phieutranoncc.Any(e => e.Idptnncc == id);
        }
    }
}
