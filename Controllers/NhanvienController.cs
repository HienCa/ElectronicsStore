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
using Microsoft.AspNetCore.Authorization;

namespace ElectronicsStore.Controllers
{
    [Authorize]

    public class NhanvienController : Controller
    {
        private readonly ElectronicsStoreContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public NhanvienController(ElectronicsStoreContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;

        }
        private string UploadedFile(NhanvienViewModel model)
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

        // GET: Nhanvien
        public async Task<IActionResult> Index()
        {
            ViewBag.Head = "Quản Lý Nhân Viên";


            return View(await _context.Nhanvien.Where(a => a.Active == 1).OrderByDescending(a => a.Idnv).ToListAsync());
        }
        public async Task<IActionResult> TrashList(int id)
        {
            ViewBag.Head = "Khôi Phục Nhân Viên";

            return View(await _context.Nhanvien.Where(a => a.Active == 0).ToListAsync());
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var Nhanvien = await _context.Nhanvien
                .FirstOrDefaultAsync(m => m.Idnv == id);
            Nhanvien.Active = 1;
            _context.Update(Nhanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }
        // GET: Nhanvien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .FirstOrDefaultAsync(m => m.Idnv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: Nhanvien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnv,Manv,Tennv,Cccd,Ngaysinh,Gioitinh,Diachi,Sdt,Email,Masothue,Matkhau,Hinhanh,Ghichu,Facebook,Zalo,Active")] NhanvienViewModel nhanvien)
        {
            string uniqueFileName = UploadedFile(nhanvien);
            if (ModelState.IsValid)
            {

                //copy lại nhanvien vì NhanvienViewModel không được gán bằng Nhanvien
                Nhanvien nv = new Nhanvien();
                //lấy hình ảnh
                nv.Hinhanh = uniqueFileName;
                nv.Idnv = nhanvien.Idnv;
                nv.Manv = nhanvien.Manv;
                nv.Tennv = nhanvien.Tennv;
                nv.Cccd = nhanvien.Cccd;
                nv.Ngaysinh = nhanvien.Ngaysinh;
                nv.Gioitinh = nhanvien.Gioitinh;
                nv.Diachi = nhanvien.Diachi;
                nv.Sdt = nhanvien.Sdt;
                nv.Email = nhanvien.Email;
                nv.Masothue = nhanvien.Masothue;
                if (nhanvien.Matkhau != "")
                {
                    nv.Matkhau = nhanvien.Matkhau;

                }
                else
                {
                    nv.Matkhau = "NV12345";

                }
                nv.Ghichu = nhanvien.Ghichu;
                nv.Facebook = nhanvien.Facebook;
                nv.Zalo = nhanvien.Zalo;

                nv.Active = 1;
                _context.Add(nv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanvien);

        }

        // GET: Nhanvien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }

        // POST: Nhanvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NhanvienViewModel nhanvien)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Nhanvien nv = new Nhanvien();

                    //lấy hình ảnh
                    //nv.Hinhanh = uniqueFileName;
                    nv.Idnv = nhanvien.Idnv;
                    nv.Manv = nhanvien.Manv;
                    nv.Tennv = nhanvien.Tennv;
                    nv.Cccd = nhanvien.Cccd;
                    nv.Ngaysinh = nhanvien.Ngaysinh;
                    nv.Gioitinh = nhanvien.Gioitinh;
                    nv.Diachi = nhanvien.Diachi;
                    nv.Sdt = nhanvien.Sdt;
                    nv.Email = nhanvien.Email;
                    nv.Masothue = nhanvien.Masothue;
                    if (nhanvien.Matkhau != "")
                    {
                        nv.Matkhau = nhanvien.Matkhau;

                    }
                    else
                    {
                        nv.Matkhau = "NV12345";

                    }
                    nv.Ghichu = nhanvien.Ghichu;
                    nv.Facebook = nhanvien.Facebook;
                    nv.Zalo = nhanvien.Zalo;

                    nv.Active = 1;

                    if (nhanvien.Hinhanh != null)
                    {
                        if (nhanvien.ExistingImage != null)
                        {
                            string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", nhanvien.ExistingImage);
                            System.IO.File.Delete(filePath);
                        }

                        nv.Hinhanh = UploadedFile(nhanvien);
                    }
                    else
                    {
                        Nhanvien nhanvienH = _context.Nhanvien.Where(id => id.Idnv == nhanvien.Idnv).FirstOrDefault();
                        nv.Hinhanh = nhanvienH.Hinhanh;
                    }

                    _context.Update(nv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));

                }
                catch (InvalidOperationException)
                {
                    return RedirectToAction(nameof(Index));

                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Nhanvien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .FirstOrDefaultAsync(m => m.Idnv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: Nhanvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanvien = await _context.Nhanvien.FindAsync(id);
            nhanvien.Active = 0;

            _context.Nhanvien.Update(nhanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(int id)
        {
            return _context.Nhanvien.Any(e => e.Idnv == id);
        }
    }
}
