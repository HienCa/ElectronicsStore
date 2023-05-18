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
using ElectronicsStore.ViewModel;

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


        public async Task<IActionResult> InventoryReport(int? Idnhh, int? Idhh, string action)
        {
            ViewBag.Head = "THỐNG KÊ SỐ LIỆU TỒN KHO";
            if (Idhh != null)
            {
                var productQuantitiesNhap = _context.Noidungpnk.Include(p => p.IdhhNavigation).Include(p => p.IdhhNavigation.IdnhhNavigation).Where(i => i.Idhh == Idhh).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Mahh = group.FirstOrDefault().IdhhNavigation.Mavl,
                                                  Donvitinh = group.FirstOrDefault().IdhhNavigation.Donvitinh,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.FirstOrDefault().Dongia,
                                              })
                                              .ToList();
                var productQuantitiesXuat = _context.Noidungpxk.Include(p => p.IdhhNavigation).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.Sum(item => item.Dongia)

                                              })
                                              .ToList();


                var allHanghoa = await _context.Hanghoa.Where(i => i.Idhh == Idhh).ToListAsync();

                var productQuantitiesTonKho = new List<ProductQuantityViewModel>();
                foreach (var hanghoa in allHanghoa)
                {
                    var tonkho = new ProductQuantityViewModel
                    {
                        Idhh = hanghoa.Idhh,
                        Tenhh = hanghoa.Tenvl,
                        Mahh = hanghoa.Mavl,
                        Donvitinh = hanghoa.Donvitinh,
                        Dongia = (productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Dongia ?? 0),
                        Soluong = (productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0) - (productQuantitiesXuat.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0),
                        Tongtien = ((productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0) - (productQuantitiesXuat.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0)) * (productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Dongia ?? 0),
                    };

                    productQuantitiesTonKho.Add(tonkho);
                }

                if (action != null && action.Equals("excel"))
                {


                    using (var workbook = new XLWorkbook())
                    {
                        //tên sheet
                        var worksheet = workbook.Worksheets.Add("Tonkho");

                        //tiêu đề
                        var currentRow = 1;
                        worksheet.Cell(currentRow, 1).Value = "Linh kiện máy tính ElectronicsStore";
                        currentRow += 2;

                        //danh sách phiếu
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = "Mã hàng hóa";
                        worksheet.Cell(currentRow, 2).Value = "Tên hàng hóa";
                        worksheet.Cell(currentRow, 3).Value = "Đơn vị tính";
                        worksheet.Cell(currentRow, 4).Value = "Số lượng tồn";
                        worksheet.Cell(currentRow, 5).Value = "Đơn giá nhập";
                        worksheet.Cell(currentRow, 6).Value = "Tổng trị giá tồn (đ)";

                        double tongcong = 0;
                        foreach (var tk in productQuantitiesTonKho)
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = tk.Mahh;
                            worksheet.Cell(currentRow, 2).Value = tk.Tenhh;
                            worksheet.Cell(currentRow, 3).Value = tk.Donvitinh;
                            worksheet.Cell(currentRow, 4).Value = tk.Soluong;
                            worksheet.Cell(currentRow, 5).Value = String.Format("{0:0,0}", tk.Dongia);
                            worksheet.Cell(currentRow, 6).Value = String.Format("{0:0,0}", tk.Tongtien);

                            tongcong += tk.Tongtien;
                        }
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = "TỔNG CỘNG";
                        worksheet.Cell(currentRow, 6).Value = String.Format("{0:0,0}", tongcong);

                        //tiêu đề
                        DateTime now = DateTime.Now;
                        currentRow += 2;
                        worksheet.Cell(currentRow, 4).Value = "TP. Hồ Chí Minh, Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();
                            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "tonkho.xlsx");
                        }
                    }
                }
                else if (action != null && action.Equals("csv"))
                {

                    var builder = new StringBuilder();
                    builder.AppendLine("Mã hàng hóa, Tên hàng hóa, Đơn vị tính, Số lượng tồn, Đơn giá nhập, Tổng trị giá tồn");
                    foreach (var p in productQuantitiesTonKho)
                    {
                        builder.AppendLine($"{p.Mahh}, {p.Tenhh}, {p.Donvitinh}, {p.Soluong}, {p.Dongia}, {p.Tongtien}");
                    }
                    return File(new UTF8Encoding().GetBytes(builder.ToString()), "text/csv", "tonkho.csv");
                }

                return View(productQuantitiesTonKho);
            }
            if (Idnhh != null)
            {
                var productQuantitiesNhap = _context.Noidungpnk.Include(p => p.IdhhNavigation).Include(p => p.IdhhNavigation.IdnhhNavigation).Where(i => i.IdhhNavigation.IdnhhNavigation.Idnhh == Idnhh).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Mahh = group.FirstOrDefault().IdhhNavigation.Mavl,
                                                  Donvitinh = group.FirstOrDefault().IdhhNavigation.Donvitinh,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.FirstOrDefault().Dongia,
                                              })
                                              .ToList();
                var productQuantitiesXuat = _context.Noidungpxk.Include(p => p.IdhhNavigation).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.Sum(item => item.Dongia)

                                              })
                                              .ToList();

                var allHanghoa = await _context.Hanghoa.Where(i=>i.Idnhh== Idnhh).ToListAsync();

                var productQuantitiesTonKho = new List<ProductQuantityViewModel>();
                foreach (var hanghoa in allHanghoa)
                {
                    var tonkho = new ProductQuantityViewModel
                    {
                        Idhh = hanghoa.Idhh,
                        Tenhh = hanghoa.Tenvl,
                        Mahh = hanghoa.Mavl,
                        Donvitinh = hanghoa.Donvitinh,
                        Dongia = (productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Dongia ?? 0),
                        Soluong = (productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0) - (productQuantitiesXuat.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0),
                        Tongtien = ((productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0) - (productQuantitiesXuat.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0)) * (productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Dongia ?? 0),
                    };

                    productQuantitiesTonKho.Add(tonkho);
                }


                if (action != null && action.Equals("excel"))
                {


                    using (var workbook = new XLWorkbook())
                    {
                        //tên sheet
                        var worksheet = workbook.Worksheets.Add("Tonkho");

                        //tiêu đề
                        var currentRow = 1;
                        worksheet.Cell(currentRow, 1).Value = "Linh kiện máy tính ElectronicsStore";
                        currentRow += 2;

                        //danh sách phiếu
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = "Mã hàng hóa";
                        worksheet.Cell(currentRow, 2).Value = "Tên hàng hóa";
                        worksheet.Cell(currentRow, 3).Value = "Đơn vị tính";
                        worksheet.Cell(currentRow, 4).Value = "Số lượng tồn";
                        worksheet.Cell(currentRow, 5).Value = "Đơn giá nhập";
                        worksheet.Cell(currentRow, 6).Value = "Tổng trị giá tồn (đ)";

                        double tongcong = 0;
                        foreach (var tk in productQuantitiesTonKho)
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = tk.Mahh;
                            worksheet.Cell(currentRow, 2).Value = tk.Tenhh;
                            worksheet.Cell(currentRow, 3).Value = tk.Donvitinh;
                            worksheet.Cell(currentRow, 4).Value = tk.Soluong;
                            worksheet.Cell(currentRow, 5).Value = String.Format("{0:0,0}", tk.Dongia);
                            worksheet.Cell(currentRow, 6).Value = String.Format("{0:0,0}", tk.Tongtien);

                            tongcong += tk.Tongtien;
                        }
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = "TỔNG CỘNG";
                        worksheet.Cell(currentRow, 6).Value = String.Format("{0:0,0}", tongcong);

                        //tiêu đề
                        DateTime now = DateTime.Now;
                        currentRow += 2;
                        worksheet.Cell(currentRow, 4).Value = "TP. Hồ Chí Minh, Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();
                            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "tonkho.xlsx");
                        }
                    }
                }
                else if (action != null && action.Equals("csv"))
                {

                    var builder = new StringBuilder();
                    builder.AppendLine("Mã hàng hóa, Tên hàng hóa, Đơn vị tính, Số lượng tồn, Đơn giá nhập, Tổng trị giá tồn");
                    foreach (var p in productQuantitiesTonKho)
                    {
                        builder.AppendLine($"{p.Mahh}, {p.Tenhh}, {p.Donvitinh}, {p.Soluong}, {p.Dongia}, {p.Tongtien}");
                    }
                    return File(new UTF8Encoding().GetBytes(builder.ToString()), "text/csv", "tonkho.csv");
                }

                return View(productQuantitiesTonKho);
            }
            else
            {

                var productQuantitiesNhap = _context.Noidungpnk.Include(p => p.IdhhNavigation).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Mahh = group.FirstOrDefault().IdhhNavigation.Mavl,
                                                  Donvitinh = group.FirstOrDefault().IdhhNavigation.Donvitinh,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.FirstOrDefault().Dongia,
                                              })
                                              .ToList();
                var productQuantitiesXuat = _context.Noidungpxk.Include(p => p.IdhhNavigation).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.Sum(item => item.Dongia)

                                              })
                                              .ToList();



                var allHanghoa = await _context.Hanghoa.ToListAsync();

                var productQuantitiesTonKho = new List<ProductQuantityViewModel>();
                foreach (var hanghoa in allHanghoa)
                {
                    var tonkho = new ProductQuantityViewModel
                    {
                        Idhh = hanghoa.Idhh,
                        Tenhh = hanghoa.Tenvl,
                        Mahh = hanghoa.Mavl,
                        Donvitinh = hanghoa.Donvitinh,
                        Dongia = (productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Dongia ?? 0),
                        Soluong = (productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0) - (productQuantitiesXuat.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0),
                        Tongtien = ((productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0) - (productQuantitiesXuat.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0)) * (productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Dongia ?? 0),
                    };

                    productQuantitiesTonKho.Add(tonkho);
                }


                if (action != null && action.Equals("excel"))
                {


                    using (var workbook = new XLWorkbook())
                    {
                        //tên sheet
                        var worksheet = workbook.Worksheets.Add("Tonkho");

                        //tiêu đề
                        var currentRow = 1;
                        worksheet.Cell(currentRow, 1).Value = "Linh kiện máy tính ElectronicsStore";
                        currentRow += 2;

                        //danh sách phiếu
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = "Mã hàng hóa";
                        worksheet.Cell(currentRow, 2).Value = "Tên hàng hóa";
                        worksheet.Cell(currentRow, 3).Value = "Đơn vị tính";
                        worksheet.Cell(currentRow, 4).Value = "Số lượng tồn";
                        worksheet.Cell(currentRow, 5).Value = "Đơn giá nhập";
                        worksheet.Cell(currentRow, 6).Value = "Tổng trị giá tồn (đ)";

                        double tongcong = 0;
                        foreach (var tk in productQuantitiesTonKho)
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = tk.Mahh;
                            worksheet.Cell(currentRow, 2).Value = tk.Tenhh;
                            worksheet.Cell(currentRow, 3).Value = tk.Donvitinh;
                            worksheet.Cell(currentRow, 4).Value = tk.Soluong;
                            worksheet.Cell(currentRow, 5).Value = String.Format("{0:0,0}", tk.Dongia);
                            worksheet.Cell(currentRow, 6).Value = String.Format("{0:0,0}", tk.Tongtien);

                            tongcong += tk.Tongtien;
                        }
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = "TỔNG CỘNG";
                        worksheet.Cell(currentRow, 6).Value = String.Format("{0:0,0}", tongcong);

                        //tiêu đề
                        DateTime now = DateTime.Now;
                        currentRow += 2;
                        worksheet.Cell(currentRow, 4).Value = "TP. Hồ Chí Minh, Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();
                            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "tonkho.xlsx");
                        }
                    }
                }
                else if (action != null && action.Equals("csv"))
                {

                    var builder = new StringBuilder();
                    builder.AppendLine("Mã hàng hóa, Tên hàng hóa, Đơn vị tính, Số lượng tồn, Đơn giá nhập, Tổng trị giá tồn");
                    foreach (var p in productQuantitiesTonKho)
                    {
                        builder.AppendLine($"{p.Mahh}, {p.Tenhh}, {p.Donvitinh}, {p.Soluong}, {p.Dongia}, {p.Tongtien}");
                    }

                    return File(new UTF8Encoding().GetBytes(builder.ToString()), "text/csv", "tonkho.csv");
                }

                return View(productQuantitiesTonKho);
            }




        }

        // Xuất Nhập Tồn Kho
        public async Task<IActionResult> XuatNhapTonReport(DateTime? from, DateTime? to, int? Idhh, string action)
        {

            ViewBag.Head = "THỐNG KÊ SỐ LIỆU XUẤT - NHẬP - TỒN";

            if (from != null && to != null && Idhh == null)
            {
                ViewData["from"] = from;
                ViewData["to"] = to;
                //ĐẦU KỲ
                var productQuantitiesNhapDK = _context.Noidungpnk.Include(p => p.IdhhNavigation).Include(p => p.IdpnkNavigation).Where(p => p.IdpnkNavigation.Ngaylap < from).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Mahh = group.FirstOrDefault().IdhhNavigation.Mavl,
                                                  Donvitinh = group.FirstOrDefault().IdhhNavigation.Donvitinh,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.FirstOrDefault().Dongia,
                                              })
                                              .ToList();
                var productQuantitiesXuatDK = _context.Noidungpxk.Include(p => p.IdhhNavigation).Include(p => p.IdpxkNavigation).Where(p => p.IdpxkNavigation.Ngaylap < from).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.Sum(item => item.Dongia)

                                              })
                                              .ToList();

                var productQuantitiesTonKhoDK = productQuantitiesNhapDK.Select(p => new ProductQuantityViewModel
                {
                    Idhh = p.Idhh,
                    Tenhh = p.Tenhh,
                    Mahh = p.Mahh,
                    Dongia = p.Dongia,
                    Donvitinh = p.Donvitinh,
                    Soluong = p.Soluong - (productQuantitiesXuatDK.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Tongtien = (p.Soluong - (productQuantitiesXuatDK.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0)) * p.Dongia
                }).ToList();


                // GIỮA KỲ
                var productQuantitiesNhapGK = _context.Noidungpnk.Include(p => p.IdhhNavigation).Include(p => p.IdpnkNavigation).Where(p => p.IdpnkNavigation.Ngaylap >= from && p.IdpnkNavigation.Ngaylap <= to).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Mahh = group.FirstOrDefault().IdhhNavigation.Mavl,
                                                  Donvitinh = group.FirstOrDefault().IdhhNavigation.Donvitinh,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.FirstOrDefault().Dongia,
                                                  Tongtien = group.Sum(item => item.Soluong) * group.Sum(item => item.Dongia)
                                              })
                                              .ToList();
                var productQuantitiesXuatGK = _context.Noidungpxk.Include(p => p.IdhhNavigation).Include(p => p.IdpxkNavigation).Where(p => p.IdpxkNavigation.Ngaylap >= from && p.IdpxkNavigation.Ngaylap <= to).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.Sum(item => item.Dongia),
                                                  Tongtien = group.Sum(item => item.Soluong) * group.Sum(item => item.Dongia)


                                              })
                                              .ToList();

                var productQuantitiesTonKhoGK = productQuantitiesNhapGK.Select(p => new ProductQuantityViewModel
                {
                    Idhh = p.Idhh,
                    Tenhh = p.Tenhh,
                    Mahh = p.Mahh,
                    Dongia = p.Dongia,
                    Donvitinh = p.Donvitinh,
                    Soluong = p.Soluong - (productQuantitiesXuatGK.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Tongtien = (p.Soluong - (productQuantitiesXuatGK.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0)) * p.Dongia
                }).ToList();



                //Cuối kỳ - XUẤT TỒN TỔNG 

                var productQuantitiesNhapCK = _context.Noidungpnk.Include(p => p.IdhhNavigation).ToList()
                                             .GroupBy(item => item.Idhh)
                                             .Select(group => new ProductQuantityViewModel
                                             {
                                                 Idhh = group.Key,
                                                 Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                 Mahh = group.FirstOrDefault().IdhhNavigation.Mavl,
                                                 Donvitinh = group.FirstOrDefault().IdhhNavigation.Donvitinh,
                                                 Soluong = group.Sum(item => item.Soluong),
                                                 Dongia = group.FirstOrDefault().Dongia,
                                             })
                                             .ToList();
                var productQuantitiesXuatCK = _context.Noidungpxk.Include(p => p.IdhhNavigation).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.Sum(item => item.Dongia)

                                              })
                                              .ToList();


                var productQuantitiesTonKhoCK = productQuantitiesNhapCK.Select(p => new ProductQuantityViewModel
                {
                    Idhh = p.Idhh,
                    Tenhh = p.Tenhh,
                    Mahh = p.Mahh,
                    Dongia = p.Dongia,
                    Donvitinh = p.Donvitinh,
                    Soluong = p.Soluong - (productQuantitiesXuatCK.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Tongtien = (p.Soluong - (productQuantitiesXuatCK.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0)) * p.Dongia
                }).ToList();


                List<Hanghoa> hanghoa = await _context.Hanghoa.ToListAsync();
                // KẾT HỢP DK-GK-CK
                var XuatNhapTonReport = hanghoa.Select(t => new XuatNhapTon
                {
                    Idhh = t.Idhh,
                    Mahh = t.Mavl,
                    Tenhh = t.Tenvl,
                    Donvitinh = t.Donvitinh,

                    //đầu kỳ
                    Soluongdauky = (productQuantitiesTonKhoDK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Dongiadauky = (productQuantitiesTonKhoDK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Tongtien ?? 0),

                    //giữ kỳ
                    Soluonggiuakynhap = (productQuantitiesNhapGK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Dongiagiuakynhap = (productQuantitiesNhapGK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Tongtien ?? 0),

                    Soluonggiuakyxuat = (productQuantitiesXuatGK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Dongiagiuakyxuat = (productQuantitiesXuatGK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Tongtien ?? 0),

                    //cuối kỳ
                    Soluongcuoiky = (productQuantitiesTonKhoCK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Dongiacuoiky = (productQuantitiesTonKhoCK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Tongtien ?? 0),

                }).ToList();

                ViewData["XuatNhapTonReport"] = XuatNhapTonReport;


                if (action != null && action.Equals("excel"))
                {


                    using (var workbook = new XLWorkbook())
                    {
                        //tên sheet
                        var worksheet = workbook.Worksheets.Add("Tonkho");

                        //tiêu đề
                        var currentRow = 1;
                        worksheet.Cell(currentRow, 1).Value = "Linh kiện máy tính ElectronicsStore";
                        //worksheet.Cell(currentRow, 2).Value = "Báo cáo xuất nhập tồn từ: "+ from.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        currentRow += 2;

                        //danh sách phiếu
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = "Mã hàng hóa";
                        worksheet.Cell(currentRow, 2).Value = "Tên hàng hóa";
                        worksheet.Cell(currentRow, 3).Value = "Đơn vị tính";
                        worksheet.Cell(currentRow, 4).Value = "Số lượng tồn đầu kỳ";
                        worksheet.Cell(currentRow, 5).Value = "Tổng trị giá đầu kỳ (đ)";

                        worksheet.Cell(currentRow, 6).Value = "Số lượng nhập giữa kỳ";
                        worksheet.Cell(currentRow, 7).Value = "Tổng trị giá nhập giữa kỳ (đ)";
                        worksheet.Cell(currentRow, 8).Value = "Số lượng xuất giữa kỳ";
                        worksheet.Cell(currentRow, 9).Value = "Tổng trị giá xuất giữa kỳ (đ)";

                        worksheet.Cell(currentRow, 10).Value = "Số lượng tồn cuối kỳ";
                        worksheet.Cell(currentRow, 11).Value = "Tổng trị giá tồn cuối kỳ (đ)";


                        foreach (var tk in XuatNhapTonReport)
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = tk.Mahh;
                            worksheet.Cell(currentRow, 2).Value = tk.Tenhh;
                            worksheet.Cell(currentRow, 3).Value = tk.Donvitinh;
                            worksheet.Cell(currentRow, 4).Value = tk.Soluongdauky;
                            worksheet.Cell(currentRow, 5).Value = String.Format("{0:0,0}", tk.Dongiadauky);
                            worksheet.Cell(currentRow, 6).Value = tk.Soluonggiuakynhap;
                            worksheet.Cell(currentRow, 7).Value = String.Format("{0:0,0}", tk.Dongiagiuakynhap);
                            worksheet.Cell(currentRow, 8).Value = tk.Soluonggiuakyxuat;
                            worksheet.Cell(currentRow, 9).Value = String.Format("{0:0,0}", tk.Dongiagiuakyxuat);
                            worksheet.Cell(currentRow, 10).Value = tk.Soluongcuoiky;
                            worksheet.Cell(currentRow, 11).Value = String.Format("{0:0,0}", tk.Dongiacuoiky);

                        }


                        //tiêu đề
                        DateTime now = DateTime.Now;
                        currentRow += 2;
                        worksheet.Cell(currentRow, 8).Value = "TP. Hồ Chí Minh, Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();
                            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xuatnhapton.xlsx");
                        }
                    }
                }
                else if (action != null && action.Equals("csv"))
                {

                    var builder = new StringBuilder();
                    builder.AppendLine("Mã hàng hóa, Tên hàng hóa, Đơn vị tính, Số lượng tồn đầu kỳ, Tổng trị giá đầu kỳ, Số lượng nhập giữa kỳ, Tổng trị giá nhập giữa kỳ, Số lượng xuất giữa kỳ, Tổng trị giá xuất giữa kỳ, Tổng số lượng tồn kho cuối kỳ, Tổng trị giá tồn kho cuối kỳ");
                    foreach (var p in XuatNhapTonReport)
                    {
                        builder.AppendLine($"{p.Mahh}, {p.Tenhh}, {p.Donvitinh}, {p.Soluongdauky}, {p.Dongiadauky}, {p.Soluonggiuakynhap}, {p.Dongiagiuakynhap}, {p.Soluonggiuakyxuat}, {p.Dongiagiuakyxuat}, {p.Soluongcuoiky}, {p.Dongiacuoiky}");
                    }
                    return File(new UTF8Encoding().GetBytes(builder.ToString()), "text/csv", "xuatnhapton.csv");
                }

                return View();
            }
            else if (from != null && to != null && Idhh > 0)
            {
                ViewData["from"] = from;
                ViewData["to"] = to;
                //ĐẦU KỲ
                var productQuantitiesNhapDK = _context.Noidungpnk.Include(p => p.IdhhNavigation).Include(p => p.IdpnkNavigation).Where(p => p.IdpnkNavigation.Ngaylap < from).Where(p => p.Idhh == Idhh).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Mahh = group.FirstOrDefault().IdhhNavigation.Mavl,
                                                  Donvitinh = group.FirstOrDefault().IdhhNavigation.Donvitinh,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.FirstOrDefault().Dongia,
                                              })
                                              .ToList();
                var productQuantitiesXuatDK = _context.Noidungpxk.Include(p => p.IdhhNavigation).Include(p => p.IdpxkNavigation).Where(p => p.IdpxkNavigation.Ngaylap < from).Where(p => p.Idhh == Idhh).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.Sum(item => item.Dongia)

                                              })
                                              .ToList();

                var productQuantitiesTonKhoDK = productQuantitiesNhapDK.Select(p => new ProductQuantityViewModel
                {
                    Idhh = p.Idhh,
                    Tenhh = p.Tenhh,
                    Mahh = p.Mahh,
                    Dongia = p.Dongia,
                    Donvitinh = p.Donvitinh,
                    Soluong = p.Soluong - (productQuantitiesXuatDK.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Tongtien = (p.Soluong - (productQuantitiesXuatDK.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0)) * p.Dongia
                }).ToList();


                // GIỮA KỲ
                var productQuantitiesNhapGK = _context.Noidungpnk.Include(p => p.IdhhNavigation).Include(p => p.IdpnkNavigation).Where(p => p.IdpnkNavigation.Ngaylap >= from && p.IdpnkNavigation.Ngaylap <= to).Where(p => p.Idhh == Idhh).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Mahh = group.FirstOrDefault().IdhhNavigation.Mavl,
                                                  Donvitinh = group.FirstOrDefault().IdhhNavigation.Donvitinh,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.FirstOrDefault().Dongia,
                                                  Tongtien = group.Sum(item => item.Soluong) * group.Sum(item => item.Dongia)
                                              })
                                              .ToList();
                var productQuantitiesXuatGK = _context.Noidungpxk.Include(p => p.IdhhNavigation).Include(p => p.IdpxkNavigation).Where(p => p.IdpxkNavigation.Ngaylap >= from && p.IdpxkNavigation.Ngaylap <= to).Where(p => p.Idhh == Idhh).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.Sum(item => item.Dongia),
                                                  Tongtien = group.Sum(item => item.Soluong) * group.Sum(item => item.Dongia)


                                              })
                                              .ToList();

                var productQuantitiesTonKhoGK = productQuantitiesNhapGK.Select(p => new ProductQuantityViewModel
                {
                    Idhh = p.Idhh,
                    Tenhh = p.Tenhh,
                    Mahh = p.Mahh,
                    Dongia = p.Dongia,
                    Donvitinh = p.Donvitinh,
                    Soluong = p.Soluong - (productQuantitiesXuatGK.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Tongtien = (p.Soluong - (productQuantitiesXuatGK.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0)) * p.Dongia
                }).ToList();



                //Cuối kỳ - XUẤT TỒN TỔNG 

                var productQuantitiesNhapCK = _context.Noidungpnk.Include(p => p.IdhhNavigation).Where(p => p.Idhh == Idhh).ToList()
                                             .GroupBy(item => item.Idhh)
                                             .Select(group => new ProductQuantityViewModel
                                             {
                                                 Idhh = group.Key,
                                                 Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                 Mahh = group.FirstOrDefault().IdhhNavigation.Mavl,
                                                 Donvitinh = group.FirstOrDefault().IdhhNavigation.Donvitinh,
                                                 Soluong = group.Sum(item => item.Soluong),
                                                 Dongia = group.FirstOrDefault().Dongia,
                                             })
                                             .ToList();
                var productQuantitiesXuatCK = _context.Noidungpxk.Include(p => p.IdhhNavigation).Where(p => p.Idhh == Idhh).ToList()
                                              .GroupBy(item => item.Idhh)
                                              .Select(group => new ProductQuantityViewModel
                                              {
                                                  Idhh = group.Key,
                                                  Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                  Soluong = group.Sum(item => item.Soluong),
                                                  Dongia = group.Sum(item => item.Dongia)

                                              })
                                              .ToList();


                var productQuantitiesTonKhoCK = productQuantitiesNhapCK.Select(p => new ProductQuantityViewModel
                {
                    Idhh = p.Idhh,
                    Tenhh = p.Tenhh,
                    Mahh = p.Mahh,
                    Dongia = p.Dongia,
                    Donvitinh = p.Donvitinh,
                    Soluong = p.Soluong - (productQuantitiesXuatCK.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Tongtien = (p.Soluong - (productQuantitiesXuatCK.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0)) * p.Dongia
                }).ToList();


                List<Hanghoa> hanghoa = await _context.Hanghoa.Where(p => p.Idhh == Idhh).ToListAsync();
                // KẾT HỢP DK-GK-CK
                var XuatNhapTonReport = hanghoa.Select(t => new XuatNhapTon
                {
                    Idhh = t.Idhh,
                    Mahh = t.Mavl,
                    Tenhh = t.Tenvl,
                    Donvitinh = t.Donvitinh,

                    //đầu kỳ
                    Soluongdauky = (productQuantitiesTonKhoDK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Dongiadauky = (productQuantitiesTonKhoDK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Tongtien ?? 0),

                    //giữ kỳ
                    Soluonggiuakynhap = (productQuantitiesNhapGK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Dongiagiuakynhap = (productQuantitiesNhapGK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Tongtien ?? 0),

                    Soluonggiuakyxuat = (productQuantitiesXuatGK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Dongiagiuakyxuat = (productQuantitiesXuatGK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Tongtien ?? 0),

                    //cuối kỳ
                    Soluongcuoiky = (productQuantitiesTonKhoCK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Soluong ?? 0),
                    Dongiacuoiky = (productQuantitiesTonKhoCK.Where(q => q.Idhh == t.Idhh).FirstOrDefault()?.Tongtien ?? 0),

                }).ToList();

                ViewData["XuatNhapTonReport"] = XuatNhapTonReport;


                if (action != null && action.Equals("excel"))
                {


                    using (var workbook = new XLWorkbook())
                    {
                        //tên sheet
                        var worksheet = workbook.Worksheets.Add("Tonkho");

                        //tiêu đề
                        var currentRow = 1;
                        worksheet.Cell(currentRow, 1).Value = "Linh kiện máy tính ElectronicsStore";
                        //worksheet.Cell(currentRow, 2).Value = "Báo cáo xuất nhập tồn từ: "+ from.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        currentRow += 2;

                        //danh sách phiếu
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = "Mã hàng hóa";
                        worksheet.Cell(currentRow, 2).Value = "Tên hàng hóa";
                        worksheet.Cell(currentRow, 3).Value = "Đơn vị tính";
                        worksheet.Cell(currentRow, 4).Value = "Số lượng tồn đầu kỳ";
                        worksheet.Cell(currentRow, 5).Value = "Tổng trị giá đầu kỳ (đ)";

                        worksheet.Cell(currentRow, 6).Value = "Số lượng nhập giữa kỳ";
                        worksheet.Cell(currentRow, 7).Value = "Tổng trị giá nhập giữa kỳ (đ)";
                        worksheet.Cell(currentRow, 8).Value = "Số lượng xuất giữa kỳ";
                        worksheet.Cell(currentRow, 9).Value = "Tổng trị giá xuất giữa kỳ (đ)";

                        worksheet.Cell(currentRow, 10).Value = "Số lượng tồn cuối kỳ";
                        worksheet.Cell(currentRow, 11).Value = "Tổng trị giá tồn cuối kỳ (đ)";


                        foreach (var tk in XuatNhapTonReport)
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = tk.Mahh;
                            worksheet.Cell(currentRow, 2).Value = tk.Tenhh;
                            worksheet.Cell(currentRow, 3).Value = tk.Donvitinh;
                            worksheet.Cell(currentRow, 4).Value = tk.Soluongdauky;
                            worksheet.Cell(currentRow, 5).Value = String.Format("{0:0,0}", tk.Dongiadauky);
                            worksheet.Cell(currentRow, 6).Value = tk.Soluonggiuakynhap;
                            worksheet.Cell(currentRow, 7).Value = String.Format("{0:0,0}", tk.Dongiagiuakynhap);
                            worksheet.Cell(currentRow, 8).Value = tk.Soluonggiuakyxuat;
                            worksheet.Cell(currentRow, 9).Value = String.Format("{0:0,0}", tk.Dongiagiuakyxuat);
                            worksheet.Cell(currentRow, 10).Value = tk.Soluongcuoiky;
                            worksheet.Cell(currentRow, 11).Value = String.Format("{0:0,0}", tk.Dongiacuoiky);

                        }


                        //tiêu đề
                        DateTime now = DateTime.Now;
                        currentRow += 2;
                        worksheet.Cell(currentRow, 8).Value = "TP. Hồ Chí Minh, Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();
                            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xuatnhapton.xlsx");
                        }
                    }
                }
                else if (action != null && action.Equals("csv"))
                {

                    var builder = new StringBuilder();
                    builder.AppendLine("Mã hàng hóa, Tên hàng hóa, Đơn vị tính, Số lượng tồn đầu kỳ, Tổng trị giá đầu kỳ, Số lượng nhập giữa kỳ, Tổng trị giá nhập giữa kỳ, Số lượng xuất giữa kỳ, Tổng trị giá xuất giữa kỳ, Tổng số lượng tồn kho cuối kỳ, Tổng trị giá tồn kho cuối kỳ");
                    foreach (var p in XuatNhapTonReport)
                    {
                        builder.AppendLine($"{p.Mahh}, {p.Tenhh}, {p.Donvitinh}, {p.Soluongdauky}, {p.Dongiadauky}, {p.Soluonggiuakynhap}, {p.Dongiagiuakynhap}, {p.Soluonggiuakyxuat}, {p.Dongiagiuakyxuat}, {p.Soluongcuoiky}, {p.Dongiacuoiky}");
                    }
                    return File(new UTF8Encoding().GetBytes(builder.ToString()), "text/csv", "xuatnhapton.csv");
                }

                return View();
            }

            return View();

        }



        public async Task<IActionResult> ShowReport(DateTime? from, DateTime? to, string action, int? Idhh)
        {
            ViewBag.Head = "Export Phiếu Nhập Kho";
            List<Noidungpnk> Listndpnk = new List<Noidungpnk>();

            if (from != null && to != null)
            {
                Listndpnk = await _context.Noidungpnk.Where(d => d.IdpnkNavigation.Ngaylap >= from && d.IdpnkNavigation.Ngaylap <= to).Include(p => p.IdpnkNavigation).Include(p => p.IdhhNavigation).Include(p => p.IdpnkNavigation.IdnccNavigation).ToListAsync();
            }
            else if (from != null && to != null && Idhh > 0)
            {
                Listndpnk = await _context.Noidungpnk.Where(d => d.IdpnkNavigation.Ngaylap >= from && d.IdpnkNavigation.Ngaylap <= to).Where(d => d.Idhh == Idhh).Include(p => p.IdpnkNavigation).Include(p => p.IdhhNavigation).Include(p => p.IdpnkNavigation.IdnccNavigation).ToListAsync();
            }
            else if (from == null && to == null && Idhh > 0)
            {
                Listndpnk = await _context.Noidungpnk.Where(d => d.Idhh == Idhh).Include(p => p.IdpnkNavigation).Include(p => p.IdhhNavigation).Include(p => p.IdpnkNavigation.IdnccNavigation).ToListAsync();
            }
            else if (from == null && to == null && Idhh == null)
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
                    worksheet.Cell(currentRow, 1).Value = "Linh kiện máy tính ElectronicsStore";
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


            var productQuantitiesNhap = _context.Noidungpnk.Include(p => p.IdhhNavigation).ToList()
                                               .GroupBy(item => item.Idhh)
                                               .Select(group => new ProductQuantityViewModel
                                               {
                                                   Idhh = group.Key,
                                                   Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                   Soluong = group.Sum(item => item.Soluong)
                                               })
                                               .ToList();

            var productQuantitiesXuat = _context.Noidungpxk.Include(p => p.IdhhNavigation).ToList()
                                               .GroupBy(item => item.Idhh)
                                               .Select(group => new ProductQuantityViewModel
                                               {
                                                   Idhh = group.Key,
                                                   Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                   Soluong = group.Sum(item => item.Soluong)
                                               })
                                               .ToList();
            //var productQuantitiesTonKho = productQuantitiesNhap.Join(
            //                    productQuantitiesXuat,
            //                    p => p.Idhh,
            //                    q => q.Idhh,
            //                    (p, q) => new ProductQuantityViewModel
            //                    {
            //                        Idhh = p.Idhh,
            //                        Tenhh = p.Tenhh,
            //                        Soluong = p.Soluong - q.Soluong
            //                    }).ToList();


            var productQuantitiesTonKho = _context.Hanghoa
                                                .GroupJoin(
                                                    productQuantitiesNhap,
                                                    p => p.Idhh,
                                                    qn => qn.Idhh,
                                                    (p, qn) => new { Product = p, QuantitiesNhap = qn })
                                                .GroupJoin(
                                                    productQuantitiesXuat,
                                                    pqn => pqn.Product.Idhh,
                                                    qx => qx.Idhh,
                                                    (pqn, qx) => new { pqn.Product, pqn.QuantitiesNhap, QuantitiesXuat = qx })
                                                .SelectMany(
                                                    pq => pq.QuantitiesNhap.DefaultIfEmpty(),
                                                    (p, qn) => new { p.Product, QuantitiesNhap = qn, p.QuantitiesXuat })
                                                .SelectMany(
                                                    pq => pq.QuantitiesXuat.DefaultIfEmpty(),
                                                    (p, qx) => new ProductQuantityViewModel
                                                    {
                                                        Idhh = p.Product.Idhh,
                                                        Tenhh = p.Product.Tenvl,
                                                        Soluong = (p.QuantitiesNhap != null ? p.QuantitiesNhap.Soluong : 0) - (qx != null ? qx.Soluong : 0)
                                                    })
                                                .ToList();


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
