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
    public class KhachhangController : Controller
    {
        private readonly ElectronicsStoreContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public KhachhangController(ElectronicsStoreContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;

        }
        private string UploadedFile(KhachhangViewModel model)
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

        // GET: Khachhang
        public async Task<IActionResult> Index()
        {
            ViewBag.Head = "Quản Lý Khách Hàng";
            ViewData["Nhanvien"]= await _context.Nhanvien.Where(a => a.Active == 1).ToListAsync();

            return View(await _context.Khachhang.Where(a => a.Active == 1).ToListAsync());
        }
        public async Task<IActionResult> TrashList(int id)
        {
            ViewBag.Head = "Khôi Phục Khách Hàng";

            return View(await _context.Khachhang.Where(a => a.Active == 0).ToListAsync());
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var Khachhang = await _context.Khachhang
                .FirstOrDefaultAsync(m => m.Idkh == id);
            Khachhang.Active = 1;
            _context.Update(Khachhang);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }
        // GET: Khachhang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .FirstOrDefaultAsync(m => m.Idkh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // GET: Khachhang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Khachhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( KhachhangViewModel khachhang)
        {
            string uniqueFileName = UploadedFile(khachhang);
            if (ModelState.IsValid)
            {

                //copy lại khachhang vì KhachhangViewModel không được gán bằng Khachhang
                Khachhang nv = new Khachhang();
                //lấy hình ảnh
                nv.Hinhanh = uniqueFileName;
                nv.Idkh = khachhang.Idkh;
                nv.Makh = khachhang.Makh;
                nv.Tenkh = khachhang.Tenkh;
                nv.Cccd = khachhang.Cccd;
                nv.Ngaysinh = khachhang.Ngaysinh;
                nv.Gioitinh = khachhang.Gioitinh;
                nv.Diachi = khachhang.Diachi;
                nv.Sdt = khachhang.Sdt;
                nv.Email = khachhang.Email;
                nv.Masothue = khachhang.Masothue;
                if (nv.Matkhau != "")
                {
                    nv.Matkhau = khachhang.Matkhau;

                }
                else
                {
                    nv.Matkhau = "NV12345";

                }
                nv.Ghichu = khachhang.Ghichu;
                nv.Facebook = khachhang.Facebook;
                nv.Zalo = khachhang.Zalo;

                nv.Active = 1;
                _context.Add(nv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachhang);

        }

        // GET: Khachhang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            return View(khachhang);
        }

        // POST: Khachhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(KhachhangViewModel khachhang)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Khachhang nv = new Khachhang();

                    //lấy hình ảnh
                    //nv.Hinhanh = uniqueFileName;
                    nv.Idkh = khachhang.Idkh;
                    nv.Makh = khachhang.Makh;
                    nv.Tenkh = khachhang.Tenkh;
                    nv.Cccd = khachhang.Cccd;
                    nv.Ngaysinh = khachhang.Ngaysinh;
                    nv.Gioitinh = khachhang.Gioitinh;
                    nv.Diachi = khachhang.Diachi;
                    nv.Sdt = khachhang.Sdt;
                    nv.Email = khachhang.Email;
                    nv.Masothue = khachhang.Masothue;
                    if (nv.Matkhau != "")
                    {
                        nv.Matkhau = khachhang.Matkhau;

                    }
                    else
                    {
                        nv.Matkhau = "NV12345";

                    }
                    nv.Ghichu = khachhang.Ghichu;
                    nv.Facebook = khachhang.Facebook;
                    nv.Zalo = khachhang.Zalo;

                    nv.Active = 1;

                    if (khachhang.Hinhanh != null)
                    {
                        if (khachhang.ExistingImage != null)
                        {
                            string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", khachhang.ExistingImage);
                            System.IO.File.Delete(filePath);
                        }

                        nv.Hinhanh = UploadedFile(khachhang);
                    }

                    _context.Update(nv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Khachhang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .FirstOrDefaultAsync(m => m.Idkh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // POST: Khachhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khachhang = await _context.Khachhang.FindAsync(id);
            khachhang.Active = 0;

            _context.Khachhang.Update(khachhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachhangExists(int id)
        {
            return _context.Khachhang.Any(e => e.Idkh == id);
        }
    }
}
