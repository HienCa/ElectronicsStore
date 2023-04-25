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
            var electronicsStoreContext = await _context.Phieuthunokh.Where(a => a.Active == 1).Include(p => p.IdhtttNavigation).Include(p => p.IdnvNavigation).OrderByDescending(a => a.Idptnkh).ToListAsync();

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
            try
            {

                var phieuthunokh = await _context.Noidungthunokh
                                                    .Include(p => p.IdptnkhNavigation)
                                                    .Include(p => p.IdptnkhNavigation.IdnvNavigation)
                                                    .Where(m => m.Idptnkh == id)
                                                    .ToListAsync();

                var ndphieuthuno = await _context.Noidungthunokh.Where(a => a.Idptnkh == id)
                                                           .FirstOrDefaultAsync();

               
                ViewData["Noidungkh"] = ndphieuthuno;
                if (phieuthunokh.Count == 0)
                {
                    var phieuthunoddhkh = await _context.Noidungthunoddh
                                                            .Include(p => p.IdptnkhNavigation)
                                                            .Include(p => p.IdptnkhNavigation.IdnvNavigation)
                                                            .Where(m => m.Idptnkh == id)
                                                            .ToListAsync();

                    var ndphieuthunoddh = await _context.Noidungthunoddh.Where(a => a.Idptnkh == id)
                                                           .FirstOrDefaultAsync();


                    ViewData["Noidungddh"] = ndphieuthunoddh;

                    var Sotiendathu = _context.Noidungthunoddh
                                                        .Include(p => p.IdptnkhNavigation)
                                                        .Include(p => p.IdptnkhNavigation.IdnvNavigation)
                                                        .Where(m => m.Idptnkh == id).Sum(s=>s.Sotien);
                            
                    var Sotienphaitra = _context.Noidungddh
                                                        .Include(p => p.IdhhNavigation)
                                                        .Include(p => p.IddhNavigation)
                                                        .Where(m => m.IddhNavigation.Iddh == ndphieuthunoddh.Iddh).Sum(a=>a.Soluong * a.Dongia);

                    if (Sotienphaitra - Sotiendathu == 0)
                    {
                        ViewData["Sotienconno"] = 0;
                    }
                    else
                    {
                        ViewData["Sotienconno"] = Sotienphaitra - Sotiendathu;

                    }
                    ViewData["noidungthunoddhkh"] = phieuthunoddhkh;


                    
                    return View();

                    //}

                }


                var Sotiendathu1 = _context.Noidungthunokh
                                                       .Include(p => p.IdptnkhNavigation)
                                                       .Include(p => p.IdptnkhNavigation.IdnvNavigation)
                                                       .Where(m => m.Idptnkh == id).Sum(s => s.Sotien);

                var Sotienphaitra1 = _context.Noidungpxk
                                                    .Include(p => p.IdhhNavigation)
                                                    .Include(p => p.IdpxkNavigation)
                                                    .Where(m => m.IdpxkNavigation.Idpxk == ndphieuthuno.Idpxk).Sum(a => a.Soluong * a.Dongia);

                if (Sotienphaitra1 - Sotiendathu1 == 0)
                {
                    ViewData["Sotienconno"] = 0;
                }
                else
                {
                    ViewData["Sotienconno"] = Sotienphaitra1 - Sotiendathu1;

                }
                return View(phieuthunokh);

            }
            catch
            {
                return RedirectToAction("Index", "Phieuthunokh");

            }

        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Themnoidungphieuthunokh(Noidungthunokh noidung)
        {
            try
            {
                noidung.Ngaythuno = DateTime.Now;

                _context.Noidungthunokh.Add(noidung);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Phieuthunokh", new { id = noidung.Idptnkh });

            }
            catch
            {
                return RedirectToAction("Index", "Phieuthunokh");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Themnoidungphieuthunoddh(Noidungthunoddh noidung)
        {
            try
            {
                noidung.Ngaythuno = DateTime.Now;
                _context.Noidungthunoddh.Add(noidung);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Phieuthunokh", new { id = noidung.Idptnkh });

            }
            catch
            {
                return RedirectToAction("Index", "Phieuthunokh");
            }
        }
        public IActionResult Create()
        {

            return View();
        }
        // POST: Phieuthunokh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Phieuthunokh phieuthunokh, int Idpxk)
        {

            string employeeEmail = Request.Cookies["HienCaCookie"];
            var nhanvien = await _context.Nhanvien.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();

            phieuthunokh.Ngaylap = DateTime.Now;
            if (phieuthunokh.Sophieu == null)
            {
                phieuthunokh.Sophieu = "PTN" + nhanvien.Manv + '-' + ((phieuthunokh.Ngaylap).ToString()).Replace("/", "").Replace(" ", "");
            }
            phieuthunokh.Idnv = nhanvien.Idnv;
            //Idnv từ đăng nhập
            _context.Add(phieuthunokh);
            await _context.SaveChangesAsync();

            TempData["SoPhieu"] = phieuthunokh.Sophieu;
            var phieuthuno = _context.Phieuthunokh.Where(e => (e.Idnv).Equals(nhanvien.Idnv)).Where(e => (e.Sophieu).Equals(phieuthunokh.Sophieu)).FirstOrDefault();

            TempData["phieuthuno"] = phieuthuno.Idptnkh;
            return RedirectToAction("Details", "Phieuxuatkho", new { id = Idpxk });



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Actions(Noidungthunokh noidungphieuthuno, string action)
        {
            noidungphieuthuno.Ngaythuno = DateTime.Now;

            if (action == "addItem")
            {

                _context.Add(noidungphieuthuno);
                noidungphieuthuno.Idndtnkh = 0;
                await _context.SaveChangesAsync();
            }
            if (action == "editItem")
            {
                var Phieuthunokh = await _context.Phieuthunokh.FindAsync(noidungphieuthuno.Idptnkh);

                noidungphieuthuno.Ngaythuno = Phieuthunokh.Ngaylap;
                _context.Update(noidungphieuthuno);
                await _context.SaveChangesAsync();
            }
            if (action == "deleteItem")
            {
                var Noidung = _context.Noidungthunokh.Where(id => id.Idndtnkh == noidungphieuthuno.Idndtnkh).FirstOrDefault();
                var phieuthu = _context.Phieuthunokh.Where(id => id.Idptnkh == noidungphieuthuno.Idptnkh).FirstOrDefault();

                _context.Noidungthunokh.Remove(Noidung);
                _context.Phieuthunokh.Remove(phieuthu);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Phieuxuatkho", new { id = noidungphieuthuno.Idpxk });


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
