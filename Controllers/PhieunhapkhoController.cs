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
    [Authorize]

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
            var electronicsStoreContext = await _context.Phieunhapkho.Where(a => a.Active == 1).Include(p => p.IdnccNavigation).Include(p => p.IdnvNavigation).OrderByDescending(a => a.Idpnk).ToListAsync();

            ViewBag.Head = "Quản Lý Phiếu Nhập Kho";
            ViewData["Nhanvien"] = await _context.Nhanvien.Where(a => a.Active == 1).ToListAsync();
            ViewData["Nhacungcap"] = await _context.Nhacungcap.Where(a => a.Active == 1).ToListAsync();
            return View(electronicsStoreContext);
        }
        public async Task<IActionResult> TrashList(int id)
        {
            var electronicsStoreContext = await _context.Phieunhapkho.Where(a => a.Active == 0).Include(p => p.IdnccNavigation).Include(p => p.IdnvNavigation).ToListAsync();

            ViewBag.Head = "Khôi Phục Phiếu Nhập Kho";
            return View(electronicsStoreContext);
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var phieunhapkho = await _context.Phieunhapkho
                .FirstOrDefaultAsync(m => m.Idpnk == id);
            phieunhapkho.Active = 1;
            _context.Update(phieunhapkho);
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


            TempData["Noidungpnk"] = await _context.Noidungpnk
               .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
               .Include(n => n.IdhhNavigation)
               .Where(pn => pn.Idpnk == id)
               .ToListAsync();
            TempData["Phieunhapkho"] = await _context.Phieunhapkho
               .Include(p => p.IdnccNavigation)
               .Include(p => p.IdnvNavigation)
               .FirstOrDefaultAsync(m => m.Idpnk == id);
            TempData["Hinhthucthanhtoan"] = await _context.Hinhthucthanhtoan.Where(a => a.Active == 1).ToListAsync();

            TempData["Noidungtranoncc"] = await _context.Noidungtranoncc
               .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
               .Include(n => n.IdptnnccNavigation)
               .Where(pn => pn.Idpnk == id)
               .ToListAsync();


            return View();
        }

        // GET: Phieunhapkho/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Phieunhapkho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Phieunhapkho phieunhapkho)
        {
            if (ModelState.IsValid)
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                var nhanvien = await _context.Nhanvien.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();

                phieunhapkho.Ngaylap = DateTime.Now;
                if (phieunhapkho.Sophieu == null)
                {
                    phieunhapkho.Sophieu = "PNK" + nhanvien.Manv + '-' + ((phieunhapkho.Ngaylap).ToString()).Replace("/", "").Replace(" ", "");
                }
                phieunhapkho.Idnv = nhanvien.Idnv;
                //Idnv từ đăng nhập
                _context.Add(phieunhapkho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(phieunhapkho);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Actions(Noidungpnk noidungphieunhapkho, string action)
        {

            if (action == "addItem")
            {
                var noidung = _context.Noidungpnk.Where(a => a.Idpnk == noidungphieunhapkho.Idpnk).Where(a => a.Idhh == noidungphieunhapkho.Idhh).Where(a => a.Solo == noidungphieunhapkho.Solo).Where(a => a.Dongia == noidungphieunhapkho.Dongia).FirstOrDefault();
                if (noidung != null)
                {
                    noidung.Soluong += noidungphieunhapkho.Soluong;
                    _context.Update(noidung);
                }
                else
                {
                    _context.Noidungpnk.Add(noidungphieunhapkho);
                }
                await _context.SaveChangesAsync();

            }
            if (action == "editItem")
            {
                //Noidungpnk nd = _context.Noidungpnk.Where(id => id.Idndpnk == noidungphieunhapkho.Idndpnk).FirstOrDefault();
                //nd.Dongia = noidungphieunhapkho.Dongia;
                //nd.Soluong = noidungphieunhapkho.Soluong;
                //nd.Vat = noidungphieunhapkho.Vat;
                //nd.Cktm = noidungphieunhapkho.Cktm;
                //nd.Donvitinh = noidungphieunhapkho.Donvitinh;
                //nd.Solo = noidungphieunhapkho.Solo;
                //nd.Idhh = noidungphieunhapkho.Idhh;
                _context.Noidungpnk.Update(noidungphieunhapkho);
                await _context.SaveChangesAsync();

            }
            if (action == "deleteItem")
            {
                var Noidungpnk = _context.Noidungpnk.Where(a => a.Idndpnk == noidungphieunhapkho.Idndpnk).FirstOrDefault();
                _context.Noidungpnk.Remove(Noidungpnk);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Phieunhapkho", new { id = noidungphieunhapkho.Idpnk });


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

            return View(phieunhapkho);
        }

        // POST: Phieunhapkho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Phieunhapkho phieunhapkho)
        {


            string employeeEmail = Request.Cookies["HienCaCookie"];
            var nhanvien = await _context.Nhanvien.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
            phieunhapkho.Idnv = nhanvien.Idnv;
            phieunhapkho.Ngaylap = DateTime.Now;

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

            return View(phieunhapkho);
        }



        public async Task<IActionResult> ShowReport(DateTime? from, DateTime? to, string action, int? Idhh)
        {
            ViewBag.Head = "Export Phiếu Nhập Kho";
            List<Noidungpnk> Listndpnk;

            if (from != null && to != null)
            {
                Listndpnk = await _context.Noidungpnk.Where(d => d.IdpnkNavigation.Ngaylap >= from && d.IdpnkNavigation.Ngaylap <= to).Include(p => p.IdpnkNavigation).Include(p => p.IdhhNavigation).Include(p => p.IdpnkNavigation.IdnccNavigation).ToListAsync();
            }
            if (from != null && to != null && Idhh > 0)
            {
                Listndpnk = await _context.Noidungpnk.Where(d => d.IdpnkNavigation.Ngaylap >= from && d.IdpnkNavigation.Ngaylap <= to).Where(d => d.Idhh == Idhh).Include(p => p.IdpnkNavigation).Include(p => p.IdhhNavigation).Include(p => p.IdpnkNavigation.IdnccNavigation).ToListAsync();
            }
            if (from == null && to == null && Idhh > 0)
            {
                Listndpnk = await _context.Noidungpnk.Where(d => d.Idhh == Idhh).Include(p => p.IdpnkNavigation).Include(p => p.IdhhNavigation).Include(p => p.IdpnkNavigation.IdnccNavigation).ToListAsync();
            }
            else
            {
                Listndpnk = await _context.Noidungpnk.Include(p => p.IdpnkNavigation).Include(p => p.IdhhNavigation).Include(p => p.IdpnkNavigation.IdnccNavigation).ToListAsync();


            }
            if (action.Equals("export") && from == null && to == null || action.Equals("export"))
            {

                using (var workbook = new XLWorkbook())
                {
                    //tên sheet
                    var worksheet = workbook.Worksheets.Add("Phieunhapkho");

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
                        worksheet.Cell(currentRow, 4).Value = "BẢNG KÊ PHIẾU NHẬP KHO TỪ " + fromString + " ĐẾN " + toString;
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 4).Value = "BẢNG KÊ PHIẾU NHẬP KHO TỪ " + from + " ĐẾN " + to;

                    }

                    //danh sách phiếu
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = "Mã NCC";
                    worksheet.Cell(currentRow, 2).Value = "Tên nhà cung cấp";
                    worksheet.Cell(currentRow, 3).Value = "Ngày nhập";
                    worksheet.Cell(currentRow, 4).Value = "Số phiếu";
                    worksheet.Cell(currentRow, 5).Value = "Số lô";
                    worksheet.Cell(currentRow, 6).Value = "Mã hàng hóa";
                    worksheet.Cell(currentRow, 7).Value = "Tên hàng hóa";
                    worksheet.Cell(currentRow, 8).Value = "Đơn vị tính";
                    worksheet.Cell(currentRow, 9).Value = "Số lượng";
                    worksheet.Cell(currentRow, 10).Value = "Đơn giá nhập(đ)";
                    worksheet.Cell(currentRow, 11).Value = "Thành tiền(đ)";

                    float tongSoLuong = 0;
                    float tongGiaNhap = 0;
                    float tongThanhTien = 0;

                    foreach (var pnk in Listndpnk)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = pnk.IdpnkNavigation.IdnccNavigation.Mancc;
                        worksheet.Cell(currentRow, 2).Value = pnk.IdpnkNavigation.IdnccNavigation.Tenncc;
                        DateTime Ngaylap = (DateTime)pnk.IdpnkNavigation.Ngaylap;
                        worksheet.Cell(currentRow, 3).Value = Ngaylap.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        worksheet.Cell(currentRow, 4).Value = pnk.IdpnkNavigation.Sophieu;
                        worksheet.Cell(currentRow, 5).Value = pnk.Solo;
                        worksheet.Cell(currentRow, 6).Value = pnk.IdhhNavigation.Mavl;
                        worksheet.Cell(currentRow, 7).Value = pnk.IdhhNavigation.Tenvl;
                        worksheet.Cell(currentRow, 8).Value = pnk.Donvitinh;
                        worksheet.Cell(currentRow, 9).Value = pnk.Soluong;
                        worksheet.Cell(currentRow, 10).Value = pnk.Dongia;

                        var Thanhtien = String.Format("{0:0,0}", (pnk.Soluong * pnk.Dongia));
                        worksheet.Cell(currentRow, 11).Value = Thanhtien;

                        tongSoLuong += pnk.Soluong;
                        tongGiaNhap += pnk.Dongia;
                        tongThanhTien += (pnk.Soluong * pnk.Dongia);

                    }
                    currentRow++;
                    worksheet.Cell(currentRow, 3).Value = "TỔNG CỘNG";
                    worksheet.Cell(currentRow, 9).Value = tongSoLuong;
                    worksheet.Cell(currentRow, 10).Value = String.Format("{0:0,0}", tongGiaNhap);
                    worksheet.Cell(currentRow, 11).Value = String.Format("{0:0,0}", tongThanhTien);

                    //tiêu đề
                    DateTime now = DateTime.Now;
                    currentRow += 2;
                    worksheet.Cell(currentRow, 8).Value = "TP. Hồ Chí Minh, Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

                    currentRow++;
                    worksheet.Cell(currentRow, 2).Value = "Người mua";
                    worksheet.Cell(currentRow, 5).Value = "Kế toán trưởng";
                    worksheet.Cell(currentRow, 9).Value = "Người phê duyệt";

                    currentRow++;
                    worksheet.Cell(currentRow, 2).Value = "(Ký, họ tên)";
                    worksheet.Cell(currentRow, 5).Value = "(Ký, họ tên)";
                    worksheet.Cell(currentRow, 9).Value = "(Ký, họ tên, đóng dấu)";
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "phieunhapkho" + fromString + "-" + toString + ".xlsx");
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
                builder.AppendLine("Mã nhà cung cấp, Tên nhà cung cấp, Ngày nhập, Số phiếu, Số lô, Mã hàng hóa, Tên hàng hóa, Đơn vị tính, Số lượng, Đon giá, Thành tiền");
                foreach (var p in Listndpnk)
                {
                    builder.AppendLine($"{p.IdpnkNavigation.IdnccNavigation.Mancc}, {p.IdpnkNavigation.IdnccNavigation.Tenncc}, {p.IdpnkNavigation.Ngaylap}, {p.IdpnkNavigation.Sophieu}, {p.Solo}, {p.IdhhNavigation.Mavl}, {p.IdhhNavigation.Tenvl}, {p.Donvitinh}, {p.Soluong}, {p.Dongia}, {p.Soluong * p.Dongia}");
                }

                return File(new UTF8Encoding().GetBytes(builder.ToString()), "text/csv", "phieunhapkho" + fromString + "-" + toString + ".csv");
            }

            return View(Listndpnk);
        }



        public async Task<IActionResult> Report(DateTime? from, DateTime? to, string action)
        {


            var inventoryReport = _context.Noidungpnk
             .GroupBy(n => n.Idhh)
             .Select(g => new
             {
                 Idhh = g.Key,
                 TongNhap = g.Sum(n => n.Soluong),
                 TongXuat = _context.Noidungpxk.Where(n => n.Idhh == g.Key).Sum(n => n.Soluong),
             })
             .ToList()
             .Select(p => new
             {
                 ProductId = p.Idhh,
                 TenSanPham = _context.Hanghoa.FirstOrDefault(pr => pr.Idhh == p.Idhh),
                 TongNhap = p.TongNhap,
                 TongXuat = p.TongXuat,
                 TonKho = p.TongNhap - p.TongXuat,
             })
             .ToList();
            //var report = new Report
            //{
            //    Mavl = "MAVL001",
            //    Tenvl = "Tên vật liệu",
            //    Donvitinh = "Đơn vị tính",
            //    Ngaylapbaocao = DateTime.Now,
            //    SLdauky = 1000,
            //    Giadauky = 5000,
            //    SLnhaptrongky = productsReport.Sum(p => p.TongNhap),
            //    Gianhaptrongky = productsReport.Sum(p => p.TongNhap * p.TenSanPham.GiaNhap),
            //    SLxuattrongky = productsReport.Sum(p => p.TongXuat),
            //    Giaxuattrongky = productsReport.Sum(p => p.TongXuat * p.TenSanPham.GiaXuat),
            //    SLtoncuoiky = productsReport.Sum(p => p.TonKho),
            //    Giatoncuoiky = productsReport.Sum(p => p.TonKho * p.TenSanPham.GiaBan),
            //};

            //// Tính tổng tiền đầu kỳ, nhập trong kỳ và xuất trong kỳ
            //report.Tongtiendauky = report.SLdauky * report.Giadauky;
            //report.Tongtiennhaptrongky = report.SLnhaptrongky * report.Gianhaptrongky;
            //report.Tongtienxuattrongky = report.SLxuattrongky * report.Giaxuattrongky;

            //// Tính tổng tiền tồn cuối kỳ
            //report.Tongtientoncuoiky = report.SLtoncuoiky * report.Giatoncuoiky;
            using (var workbook = new XLWorkbook())
            {
                //tên sheet
                var worksheet = workbook.Worksheets.Add("Báo cáo Nhập-Xuất-Tồn");

                //tiêu đề
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "CÔNG TY SẢN XUẤT HIENCA";
                currentRow += 2;
                DateTime From = (DateTime)from;
                DateTime To = (DateTime)to;
                string fromString = From.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                string toString = To.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                worksheet.Cell(currentRow, 4).Value = "BÁO CÁO NHẬP-XUẤT-TỒN";
                currentRow++;
                worksheet.Cell(currentRow, 4).Value = "TỪ " + fromString + " ĐẾN " + toString;
                currentRow += 2;
                worksheet.Cell(currentRow, 4).Value = "Tồn kho đầu kỳ";
                worksheet.Cell(currentRow, 6).Value = "Nhập trong kỳ";
                worksheet.Cell(currentRow, 8).Value = "Xuất trong kỳ";
                worksheet.Cell(currentRow, 11).Value = "Tồn kho cuối kỳ";
                //danh sách
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = "Mã hàng hóa";
                worksheet.Cell(currentRow, 2).Value = "Tên hàng hóa";
                worksheet.Cell(currentRow, 3).Value = "Đơn vị tính";
                worksheet.Cell(currentRow, 4).Value = "Số lượng";
                worksheet.Cell(currentRow, 5).Value = "Thành tiền(đ)";

                worksheet.Cell(currentRow, 6).Value = "Số lượng";
                worksheet.Cell(currentRow, 7).Value = "Thành tiền(đ)";

                worksheet.Cell(currentRow, 8).Value = "Số lượng";
                worksheet.Cell(currentRow, 9).Value = "Đơn giá xuất kho(đ)";
                worksheet.Cell(currentRow, 10).Value = "Thành tiền(đ)";

                worksheet.Cell(currentRow, 11).Value = "Số lượng";
                worksheet.Cell(currentRow, 12).Value = "Thành tiền(đ)";

                float tongSoLuong = 0;
                float tongSoLuongXuat = 0;
                float tongSoLuongTon = 0;
                float GiaNhap = 0;
                float GiaXuat = 0;
                float tongThanhTien = 0;
                float tongThanhTienTon = 0;
                float tongThanhTienXuat = 0;

                //foreach (var pnk in ListndpnkNew)
                //{
                //    currentRow++;
                //    //worksheet.Cell(vitri1, 1).Value = pnk.IdhhNavigation.Mavl;
                //    worksheet.Cell(currentRow, 2).Value = pnk.Tenvl;
                //    //worksheet.Cell(vitri1, 3).Value = pnk.Donvitinh;

                //    worksheet.Cell(currentRow, 6).Value = pnk.Soluong;
                //    worksheet.Cell(currentRow, 7).Value = String.Format("{0:0,0}", pnk.Thanhtien);


                //    //worksheet.Cell(vitri1, 8).Value = pnk.Soluongxuat;
                //    worksheet.Cell(currentRow, 8).Value = pnk.Soluongxuat;
                //    worksheet.Cell(currentRow, 9).Value = 0;//giá xuất
                //    worksheet.Cell(currentRow, 10).Value = String.Format("{0:0,0}", pnk.Thanhtienxuat);

                //    worksheet.Cell(currentRow, 11).Value = pnk.Soluongcon;
                //    worksheet.Cell(currentRow, 12).Value = String.Format("{0:0,0}", pnk.Thanhtienton);

                //    tongSoLuong += pnk.Soluong;
                //    tongSoLuongXuat += pnk.Soluongxuat;
                //    tongSoLuongTon += pnk.Soluongcon;
                //    //GiaNhap = pnk.Giaban;
                //    tongThanhTien += pnk.Thanhtien;
                //    tongThanhTienXuat += pnk.Thanhtienxuat;
                //    tongThanhTienTon += pnk.Thanhtienton;
                //}



                currentRow++;
                worksheet.Cell(currentRow, 3).Value = "TỔNG CỘNG";
                worksheet.Cell(currentRow, 6).Value = tongSoLuong;
                worksheet.Cell(currentRow, 7).Value = String.Format("{0:0,0}", tongThanhTien);
                worksheet.Cell(currentRow, 8).Value = tongSoLuongXuat;
                worksheet.Cell(currentRow, 9).Value = 0;
                worksheet.Cell(currentRow, 10).Value = String.Format("{0:0,0}", tongThanhTienXuat);
                worksheet.Cell(currentRow, 11).Value = tongSoLuongTon;
                worksheet.Cell(currentRow, 12).Value = String.Format("{0:0,0}", tongThanhTienTon);

                //tiêu đề
                DateTime now = DateTime.Now;
                currentRow += 3;
                worksheet.Cell(currentRow, 10).Value = "TP. Hồ Chí Minh, Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

                currentRow++;
                worksheet.Cell(currentRow, 2).Value = "Người mua";
                worksheet.Cell(currentRow, 5).Value = "Kế toán trưởng";
                worksheet.Cell(currentRow, 11).Value = "Người phê duyệt";

                currentRow++;
                worksheet.Cell(currentRow, 2).Value = "(Ký, họ tên)";
                worksheet.Cell(currentRow, 5).Value = "(Ký, họ tên)";
                worksheet.Cell(currentRow, 11).Value = "(Ký, họ tên, đóng dấu)";
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "baocaonhapxuatton" + fromString + "-" + toString + ".xlsx");
                }
            }

            if (from != null && to != null && action == "search")
            {



                //TempData["Listreport"] = Listreport;

            }

            if (from == null && to == null)
            {


               
                //TempData["Listreport"] = Listreport;
            }
            return View();

        }



        // GET: Phieunhapkho/Delete/5
        public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var phieunhapkho = await _context.Phieunhapkho
            .Include(p => p.Idncc)
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
