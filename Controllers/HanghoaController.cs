using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using ElectronicsStore.ViewModel;

namespace ElectronicsStore.Controllers
{
    public class HanghoaController : Controller
    {
        private readonly ElectronicsStoreContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HanghoaController(ElectronicsStoreContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;

        }
        private string UploadedFile(HanghoaViewModel model)
        {
            string uniqueFileName = null;

            if (model.Hinhanh != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Hinhanh.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Hinhanh.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: Hanghoa
        public async Task<IActionResult> Index()
        {
            ViewBag.Head = "Quản Lý Hàng Hóa";

            ViewData["Nhomhh"] = await _context.Nhomhh.Where(a => a.Active == 1).ToListAsync();
            ViewData["Nuosx"] = await _context.Nuosx.Where(a => a.Active == 1).ToListAsync();
            ViewData["Thuonghieu"] = await _context.Thuonghieu.Where(a => a.Active == 1).ToListAsync();

            return View(await _context.Hanghoa.Where(a => a.Active == 1).Include(a => a.IdnhhNavigation).Include(a => a.IdnsxNavigation).Include(a => a.IdthNavigation).OrderByDescending(a => a.Idhh).ToListAsync());
        }
        public async Task<IActionResult> TrashList(int id)
        {
            ViewBag.Head = "Khôi Phục Hàng Hóa";

            return View(await _context.Hanghoa.Where(a => a.Active == 0).Include(a => a.IdnhhNavigation).Include(a => a.IdnsxNavigation).Include(a => a.IdthNavigation).ToListAsync());

        }
        public async Task<IActionResult> ReStore(int id)
        {
            var Hanghoa = await _context.Hanghoa
                .FirstOrDefaultAsync(m => m.Idhh == id);
            Hanghoa.Active = 1;
            _context.Update(Hanghoa);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }
        // GET: Hanghoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoa
                .FirstOrDefaultAsync(m => m.Idhh == id);
            if (hanghoa == null)
            {
                return NotFound();
            }

            return View(hanghoa);
        }

        // GET: Hanghoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hanghoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HanghoaViewModel hanghoa)
        {
            string uniqueFileName = UploadedFile(hanghoa);
            if (ModelState.IsValid)
            {

                //copy lại hanghoa vì HanghoaViewModel không được gán bằng Hanghoa
                Hanghoa hh = new Hanghoa();
                //lấy hình ảnh
                hh.Hinhanh = uniqueFileName;
                hh.Idhh = hanghoa.Idhh;
                hh.Mavl = hanghoa.Mavl;
                hh.Tenvl = hanghoa.Tenvl;
                hh.Giakm = hanghoa.Giakm;
                hh.Giaban = hanghoa.Giaban;
                hh.Tinhtrang = hanghoa.Tinhtrang;
                hh.Mausac = hanghoa.Mausac;
                hh.Donvitinh = hanghoa.Donvitinh;
                hh.Thoigianbh = hanghoa.Thoigianbh;
                hh.Mota = hanghoa.Mota;
                hh.Idnsx = hanghoa.Idnsx;
                hh.Idth = hanghoa.Idth;
                hh.Idnhh = hanghoa.Idnhh;

                hh.Active = 1;
                _context.Add(hh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hanghoa);

        }

        // GET: Hanghoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoa.FindAsync(id);
            if (hanghoa == null)
            {
                return NotFound();
            }
            return View(hanghoa);
        }

        // POST: Hanghoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HanghoaViewModel hanghoa)
        {

            try
            {
                Hanghoa hh = new Hanghoa();

                //lấy hình ảnh
                //hh.Hinhanh = uniqueFileName;

                hh.Idhh = hanghoa.Idhh;
                hh.Mavl = hanghoa.Mavl;
                hh.Tenvl = hanghoa.Tenvl;
                hh.Giakm = hanghoa.Giakm;
                hh.Giaban = hanghoa.Giaban;
                hh.Tinhtrang = hanghoa.Tinhtrang;
                hh.Mausac = hanghoa.Mausac;
                hh.Donvitinh = hanghoa.Donvitinh;
                hh.Thoigianbh = hanghoa.Thoigianbh;
                hh.Mota = hanghoa.Mota;
                hh.Idnsx = hanghoa.Idnsx;
                hh.Idth = hanghoa.Idth;
                hh.Idnhh = hanghoa.Idnhh;
                hh.Active = 1;

                if (hanghoa.Hinhanh != null)
                {
                    if (hanghoa.ExistingImage != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", hanghoa.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }

                    hh.Hinhanh = UploadedFile(hanghoa);
                }
                else
                {
                    Hanghoa hanghoacu = _context.Hanghoa.Where(id => id.Idhh == hh.Idhh).FirstOrDefault();
                    hh.Hinhanh = hanghoacu.Hinhanh;
                }

                _context.Update(hh);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                return RedirectToAction(nameof(Index));

            }

            return RedirectToAction(nameof(Index));

        }

        // GET: Hanghoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoa
                .FirstOrDefaultAsync(m => m.Idhh == id);
            if (hanghoa == null)
            {
                return NotFound();
            }

            return View(hanghoa);
        }

        // POST: Hanghoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hanghoa = await _context.Hanghoa.FindAsync(id);
            hanghoa.Active = 0;

            _context.Hanghoa.Update(hanghoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HanghoaExists(int id)
        {
            return _context.Hanghoa.Any(e => e.Idhh == id);
        }
    }
}
