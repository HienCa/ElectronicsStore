using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Text;
using ClosedXML.Excel;

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


            ViewData["Noidungpxk"] = await _context.Noidungpxk
               .Include(n => n.IdpxkNavigation).Include(n => n.IdpxkNavigation.IdnvNavigation)
               .Include(n => n.IdhhNavigation)
               .Where(pn => pn.Idpxk == Idpxk)
               .ToListAsync();
            ViewData["Phieuxuatkho"] = await _context.Phieuxuatkho
               .Include(p => p.IdkhNavigation)
               .Include(p => p.IdnvNavigation)
               .FirstOrDefaultAsync(m => m.Idpxk == Idpxk);
            ViewData["Hinhthucthanhtoan"] = await _context.Hinhthucthanhtoan.Where(a => a.Active == 1).ToListAsync();

            ViewData["Noidungthunokh"] = await _context.Noidungthunokh
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

            ViewData["ThongTinHanghoa"] = await _context.Hanghoa.Where(a => a.Idhh == Idhh).FirstOrDefaultAsync();

            float tongSoLuongNhap = HanghoaCanXuat.Sum(hh => hh.Soluong);
            float tongSoLuongXuat = HanghoaDaXuat.Sum(hh => hh.Soluong);


            ViewData["SoLuongCon"] = tongSoLuongNhap - tongSoLuongXuat;
            ViewData["HanghoaCanXuat"] = HanghoaCanXuat;

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
                if (noidungphieuxuatkho.Soluong <= 0)
                {
                    isExist.Soluong = 1;

                }
                else
                {
                    isExist.Soluong = noidungphieuxuatkho.Soluong;
                }
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


        public async Task<IActionResult> ShowReport(DateTime? from, DateTime? to, string action, int? Idhh)
        {
            ViewBag.Head = "Export Phiếu Xuất Kho";

            List<Noidungpxk> Listndpxk;

            if (from != null && to != null)
            {
                Listndpxk = await _context.Noidungpxk.Where(d => d.IdpxkNavigation.Ngaylap >= from && d.IdpxkNavigation.Ngaylap <= to).Include(p => p.IdpxkNavigation).Include(p => p.IdhhNavigation).Include(p => p.IdpxkNavigation.IdkhNavigation).ToListAsync();
            }
            if (from != null && to != null && Idhh > 0)
            {
                Listndpxk = await _context.Noidungpxk.Where(d => d.IdpxkNavigation.Ngaylap >= from && d.IdpxkNavigation.Ngaylap <= to).Include(p => p.IdpxkNavigation).Where(d => d.Idhh == Idhh).Include(p => p.IdhhNavigation).Include(p => p.IdpxkNavigation.IdkhNavigation).ToListAsync();
            }
            if (from == null && to == null && Idhh > 0)
            {
                Listndpxk = await _context.Noidungpxk.Include(p => p.IdpxkNavigation).Where(d => d.Idhh == Idhh).Include(p => p.IdhhNavigation).Include(p => p.IdpxkNavigation.IdkhNavigation).ToListAsync();
            }
            else
            {
                Listndpxk = await _context.Noidungpxk.Include(p => p.IdpxkNavigation).Include(p => p.IdhhNavigation).Include(p => p.IdpxkNavigation.IdkhNavigation).ToListAsync();

            }
            if (action.Equals("export") && from == null && to == null || action.Equals("export"))
            {

                using (var workbook = new XLWorkbook())
                {
                    //tên sheet
                    var worksheet = workbook.Worksheets.Add("Phieubanhang");

                    //tiêu đề
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "CÔNG TY SẢN XUẤT HIENCA";
                    currentRow += 2;
                    string fromString = "";
                    string toString = "";
                    if (from != null && to != null)
                    {
                        DateTime From = (DateTime)from;
                        DateTime To = (DateTime)to;
                        fromString = From.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        toString = To.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        worksheet.Cell(currentRow, 3).Value = "BẢNG KÊ PHIẾU BÁN HÀNG TỪ " + fromString + " ĐẾN " + toString;
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 3).Value = "BẢNG KÊ PHIẾU BÁN HÀNG TỪ " + from + " ĐẾN " + to;

                    }

                    //danh sách phiếu
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = "Mã KH";
                    worksheet.Cell(currentRow, 2).Value = "Tên khách hàng";
                    worksheet.Cell(currentRow, 3).Value = "Ngày lập";
                    worksheet.Cell(currentRow, 4).Value = "Số phiếu";
                    worksheet.Cell(currentRow, 5).Value = "Tên hàng hóa";
                    worksheet.Cell(currentRow, 6).Value = "Số lượng";
                    worksheet.Cell(currentRow, 7).Value = "Đơn giá nhập(đ)";
                    worksheet.Cell(currentRow, 8).Value = "Thành tiền(đ)";

                    float tongSoLuong = 0;
                    float tongGiaNhap = 0;
                    float tongThanhTien = 0;

                    foreach (var pnk in Listndpxk)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = pnk.IdpxkNavigation.IdkhNavigation.Makh;
                        worksheet.Cell(currentRow, 2).Value = pnk.IdpxkNavigation.IdkhNavigation.Tenkh;
                        DateTime Ngaylap = (DateTime)pnk.IdpxkNavigation.Ngaylap;
                        worksheet.Cell(currentRow, 3).Value = Ngaylap.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        worksheet.Cell(currentRow, 4).Value = pnk.IdpxkNavigation.Sophieu;
                        worksheet.Cell(currentRow, 5).Value = pnk.IdhhNavigation.Tenvl;
                        worksheet.Cell(currentRow, 6).Value = pnk.Soluong;
                        worksheet.Cell(currentRow, 7).Value = pnk.Dongia;

                        var Thanhtien = String.Format("{0:0,0}", (pnk.Soluong * pnk.Dongia));
                        worksheet.Cell(currentRow, 8).Value = Thanhtien;

                        tongSoLuong += pnk.Soluong;
                        tongGiaNhap += pnk.Dongia;
                        tongThanhTien += (pnk.Soluong * pnk.Dongia);

                    }
                    currentRow++;
                    worksheet.Cell(currentRow, 3).Value = "TỔNG CỘNG";
                    worksheet.Cell(currentRow, 6).Value = tongSoLuong;
                    worksheet.Cell(currentRow, 7).Value = String.Format("{0:0,0}", tongGiaNhap);
                    worksheet.Cell(currentRow, 8).Value = String.Format("{0:0,0}", tongThanhTien);

                    //tiêu đề
                    DateTime now = DateTime.Now;
                    currentRow += 2;
                    worksheet.Cell(currentRow, 7).Value = "TP. Hồ Chí Minh, Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

                    currentRow++;
                    worksheet.Cell(currentRow, 2).Value = "Người mua";
                    worksheet.Cell(currentRow, 5).Value = "Kế toán trưởng";
                    worksheet.Cell(currentRow, 8).Value = "Người phê duyệt";

                    currentRow++;
                    worksheet.Cell(currentRow, 2).Value = "(Ký, họ tên)";
                    worksheet.Cell(currentRow, 5).Value = "(Ký, họ tên)";
                    worksheet.Cell(currentRow, 8).Value = "(Ký, họ tên, đóng dấu)";
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "phieubanhang" + fromString + "-" + toString + ".xlsx");
                    }
                }
            }
            if (action.Equals("csv") && from == null && to == null || action.Equals("csv"))
            {
                string fromString = "";
                string toString = "";
                if (from != null && to != null)
                {

                    DateTime From = (DateTime)from;
                    DateTime To = (DateTime)to;
                    fromString = From.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    toString = To.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                }

                var builder = new StringBuilder();
                builder.AppendLine("Mã khách hàng, Tên khách hàng, Ngày lập, Số phiếu, Tên hàng hóa, Số lượng, Đon giá, Thành tiền");
                foreach (var p in Listndpxk)
                {
                    builder.AppendLine($"{p.IdpxkNavigation.IdkhNavigation.Makh}, {p.IdpxkNavigation.IdkhNavigation.Tenkh}, {p.IdpxkNavigation.Ngaylap}, {p.IdpxkNavigation.Sophieu}, {p.IdhhNavigation.Tenvl}, {p.Soluong}, {p.Dongia}, {p.Soluong * p.Dongia}");
                }

                return File(new UTF8Encoding().GetBytes(builder.ToString()), "text/csv", "phieubanhang" + fromString + "-" + toString + ".csv");
            }
            return View(Listndpxk);
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
