using ElectronicsStore.Models;
using ElectronicsStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ElectronicsStore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly ElectronicsStoreContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment webHostEkhironment;

        public HomeController(ElectronicsStoreContext context, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHost)
        {
            _context = context;
            //action Cart
            _httpContextAccessor = httpContextAccessor;
            webHostEkhironment = webHost;
        }

        private readonly int PageSize = 10;
        public async Task<IActionResult> Index(int? id, int page = 1)
        {



            string employeeEmail = Request.Cookies["HienCaCookie"];
            if (employeeEmail != null)
            {
                var khachhang = _context.Khachhang.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefault();
                if (khachhang != null)
                {
                    ViewData["isExist"] = "Exist";
                    ViewData["Info"] = khachhang;
                    KhachhangViewModel khachhangview = new KhachhangViewModel();
                    khachhangview.Tenkh = khachhang.Tenkh;
                    khachhangview.ExistingImage = khachhang.Hinhanh;
                    ViewData["Login"] = khachhangview;
                }
            }
            List<Hanghoa> h = new List<Hanghoa>();
            int totalPages = 0;
            if (id != null)
            {
                h = await _context.Hanghoa.Where(a => a.Active == 1 && a.IdnhhNavigation.Idnhh == id).Include(a => a.IdnhhNavigation).ToListAsync();
                int totalItems = h.Count();// Lấy tổng số phần tử từ cơ sở dữ liệu

                // Tính tổng số trang
                totalPages = (int)Math.Ceiling((double)totalItems / PageSize);
            }
            else
            {
                h = await _context.Hanghoa.Where(a => a.Active == 1).Include(a => a.IdnhhNavigation).ToListAsync();
                int totalItems = h.Count();// Lấy tổng số phần tử từ cơ sở dữ liệu

                // Tính tổng số trang
                totalPages = (int)Math.Ceiling((double)totalItems / PageSize);
            }
            ViewData["Nhomhh"] = await _context.Nhomhh.Where(a => a.Active == 1).ToListAsync();



            List<HanghoaViewModel> hanghoaviewmodel = h
                                                    .Select(hanghoa => new HanghoaViewModel
                                                    {
                                                        ExistingImage = hanghoa.Hinhanh,
                                                        Idhh = hanghoa.Idhh,
                                                        Mavl = hanghoa.Mavl,
                                                        Tenvl = hanghoa.Tenvl,
                                                        Giakm = hanghoa.Giakm,
                                                        Giaban = hanghoa.Giaban,
                                                        Tinhtrang = hanghoa.Tinhtrang,
                                                        Mausac = hanghoa.Mausac,
                                                        Donvitinh = hanghoa.Donvitinh,
                                                        Thoigianbh = hanghoa.Thoigianbh,
                                                        Mota = hanghoa.Mota,
                                                        Idnsx = hanghoa.Idnsx,
                                                        Idth = hanghoa.Idth,
                                                        Idnhh = hanghoa.Idnhh,
                                                    })
                                                     .Skip((page - 1) * PageSize)
                                                     .Take(PageSize)
                                                    .ToList();

            TempData["Hanghoa"] = hanghoaviewmodel;


            var items = hanghoaviewmodel;// Lấy các phần tử từ cơ sở dữ liệu với số lượng bắt đầu từ (page - 1) * PageSize với số lượng tối đa là PageSize

            // Truyền dữ liệu cho view
            ViewBag.PageNumber = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Items = items;
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {

            string employeeEmail = Request.Cookies["HienCaCookie"];
            if (employeeEmail != null)
            {
                var khachhang = _context.Khachhang.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefault();
                if (khachhang != null)
                {
                    ViewData["isExist"] = "Exist";
                    ViewData["Info"] = khachhang;
                    KhachhangViewModel khachhangview = new KhachhangViewModel();
                    khachhangview.Tenkh = khachhang.Tenkh;
                    khachhangview.ExistingImage = khachhang.Hinhanh;
                    ViewData["Login"] = khachhangview;
                }
            }
            Hanghoa hanghoa = await _context.Hanghoa
                         .Where(h => h.Active == 1 && h.Idhh == id)
                         .FirstOrDefaultAsync();

            if (hanghoa != null)
            {
                HanghoaViewModel hanghoaViewModel = new HanghoaViewModel
                {
                    ExistingImage = hanghoa.Hinhanh,
                    Idhh = hanghoa.Idhh,
                    Mavl = hanghoa.Mavl,
                    Tenvl = hanghoa.Tenvl,
                    Giakm = hanghoa.Giakm,
                    Giaban = hanghoa.Giaban,
                    Tinhtrang = hanghoa.Tinhtrang,
                    Mausac = hanghoa.Mausac,
                    Donvitinh = hanghoa.Donvitinh,
                    Thoigianbh = hanghoa.Thoigianbh,
                    Mota = hanghoa.Mota,
                    Idnsx = hanghoa.Idnsx,
                    Idth = hanghoa.Idth,
                    Idnhh = hanghoa.Idnhh,
                };
                return View(hanghoaViewModel);

            }
            else
            {
                return RedirectToAction(nameof(Index));

            }

        }
        public async Task<IActionResult> Cart()
        {

            //string cartId = Request.Cookies["ElectronicsStore_shopping_cart_id"];

            //if (string.IsNullOrEmpty(cartId))
            //{
            //    string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            //    byte[] ipBytes = Encoding.ASCII.GetBytes(ipAddress);
            //    byte[] hashedIpBytes = SHA512.Create().ComputeHash(ipBytes);
            //    string hashedIpString = BitConverter.ToString(hashedIpBytes).Replace("-", "").ToLower();

            //    CookieOptions cookieOptions = new CookieOptions();
            //    cookieOptions.Expires = DateTime.Now.AddYears(1);
            //    Response.Cookies.Append("ElectronicsStore_shopping_cart_id", hashedIpString, cookieOptions);

            //    cartId = hashedIpString;
            //}
            //else
            //{


            //}


            string employeeEmail = Request.Cookies["HienCaCookie"];
            if (employeeEmail != null)
            {
                var khachhang = _context.Khachhang.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefault();
                if (khachhang != null)
                {
                    ViewData["isExist"] = "Exist";
                    ViewData["Info"] = khachhang;
                    KhachhangViewModel khachhangview = new KhachhangViewModel();
                    khachhangview.Tenkh = khachhang.Tenkh;
                    khachhangview.ExistingImage = khachhang.Hinhanh;
                    ViewData["Login"] = khachhangview;
                }
            }

            return View();

        }

        public async Task<IActionResult> OrderedDetails(string Madh, string sdt)
        {
            try
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                if (employeeEmail != null)
                {
                    var khachhang = await _context.Khachhang.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
                    if (khachhang != null)
                    {
                        // khách đã đăng nhập
                        var donhang = await _context.Dondathang
                                                               .Where(ma => ma.Idkh == khachhang.Idkh)
                                                               .OrderByDescending(a => a.Iddh)
                                                                        .ToListAsync();
                        ViewData["OrderedDetails"] = donhang;

                        KhachhangViewModel khachhangview = new KhachhangViewModel();
                        khachhangview.Tenkh = khachhang.Tenkh;
                        khachhangview.ExistingImage = khachhang.Hinhanh;
                        ViewData["Login"] = khachhangview;
                        return View();

                    }
                    else
                    {
                        //thông qua mã đơn khách cung cấp
                        var donhang = await _context.Dondathang.Include(kh => kh.IdkhNavigation)
                                                                        .Where(ma => ma.Madh.Equals(Madh) && ma.IdkhNavigation.Sdt.Equals(sdt))
                                                                         .OrderByDescending(a => a.Iddh)
                                                                        .ToListAsync();
                        ViewData["OrderedDetails"] = donhang;

                        return View();

                    }
                }

                return RedirectToAction("Index", "Home");


            }
            catch
            {
                return RedirectToAction("Index", "Home");

            }


        }
        public async Task<IActionResult> OrderedDetailsRedict(int id)
        {
            try
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                if (employeeEmail != null)
                {
                    var khachhang = await _context.Khachhang.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
                    if (khachhang != null)
                    {
                        // khách đã đăng nhập
                        var donhang = await _context.Dondathang
                                                               .Where(ma => ma.Idkh == khachhang.Idkh)
                                                               .OrderByDescending(a => a.Iddh)
                                                                        .ToListAsync();
                        ViewData["OrderedDetails"] = donhang;

                        KhachhangViewModel khachhangview = new KhachhangViewModel();
                        khachhangview.Tenkh = khachhang.Tenkh;
                        khachhangview.ExistingImage = khachhang.Hinhanh;
                        ViewData["Login"] = khachhangview;
                        return RedirectToAction("OrderedDetails", "Home");


                    }
                    else
                    {
                        //thông qua mã đơn khách cung cấp
                        var donhang = await _context.Dondathang.Include(kh => kh.IdkhNavigation)
                                                                        .Where(ma => ma.Iddh == id)
                                                                         .OrderByDescending(a => a.Iddh)
                                                                        .ToListAsync();
                        ViewData["OrderedDetails"] = donhang;

                        return RedirectToAction("OrderedDetails", "Home");


                    }
                }

                return RedirectToAction("Index", "Home");


            }
            catch
            {
                return RedirectToAction("Index", "Home");

            }


        }
        public async Task<IActionResult> OrderedDetailsMulti(int id)
        {
            try
            {
                //chi tiết đơn
                var noidungdonhang = await _context.Noidungddh.Include(dh => dh.IddhNavigation)
                                                               .Include(dh => dh.IdhhNavigation)
                                                                .Include(dh => dh.IddhNavigation.IdkhNavigation)
                                                                .Where(ma => ma.Iddh == id)
                                                                 .OrderByDescending(a => a.Iddh)
                                                                .ToListAsync();
                ViewData["OrderedDetailsMulti"] = noidungdonhang;
                ViewData["Dondathang"] = await _context.Dondathang.Where(ma => ma.Iddh == id).FirstOrDefaultAsync();
                string employeeEmail = Request.Cookies["HienCaCookie"];
                if (employeeEmail != null)
                {
                    var khachhang = await _context.Khachhang.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
                    if (khachhang != null)
                    {
                        // khách đã đăng nhập

                        KhachhangViewModel khachhangview = new KhachhangViewModel();
                        khachhangview.Tenkh = khachhang.Tenkh;
                        khachhangview.ExistingImage = khachhang.Hinhanh;
                        ViewData["Login"] = khachhangview;
                        return View();

                    }

                }
                return View();

            }
            catch
            {
                return RedirectToAction("Index", "Home");

            }

        }

        public async Task<IActionResult> PersonalPage()
        {
            try
            {
                //chi tiết đơn
                string employeeEmail = Request.Cookies["HienCaCookie"];
                if (employeeEmail != null)
                {
                    var khachhang = await _context.Khachhang.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
                    if (khachhang != null)
                    {

                        KhachhangViewModel khachhangview = new KhachhangViewModel();
                        khachhangview.Idkh = khachhang.Idkh;
                        khachhangview.Makh = khachhang.Makh;
                        khachhangview.Tenkh = khachhang.Tenkh;
                        khachhangview.Cccd = khachhang.Cccd;
                        khachhangview.Ngaysinh = khachhang.Ngaysinh;
                        khachhangview.Gioitinh = khachhang.Gioitinh;
                        khachhangview.Diachi = khachhang.Diachi;
                        khachhangview.Sdt = khachhang.Sdt;
                        khachhangview.Email = khachhang.Email;
                        khachhangview.Masothue = khachhang.Masothue;
                        khachhangview.Matkhau = khachhang.Matkhau;
                        khachhangview.Ghichu = khachhang.Ghichu;
                        khachhangview.Facebook = khachhang.Facebook;
                        khachhangview.Zalo = khachhang.Zalo;
                        khachhangview.Active = khachhang.Active;
                        khachhangview.ExistingImage = khachhang.Hinhanh;



                        ViewData["Login"] = khachhangview;

                        return View(khachhangview);

                    }
                }

            }
            catch
            {
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> PersonalPageEdit(Khachhang khachhang)
        {
            try
            {
                //chi tiết đơn
                string employeeEmail = Request.Cookies["HienCaCookie"];
                if (employeeEmail != null)
                {
                    var khachhangview = await _context.Khachhang.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
                    if (khachhangview != null)
                    {
                        khachhangview.Idkh = khachhang.Idkh;
                        khachhangview.Makh = khachhang.Makh;
                        khachhangview.Tenkh = khachhang.Tenkh;
                        khachhangview.Cccd = khachhang.Cccd;
                        khachhangview.Ngaysinh = khachhang.Ngaysinh;
                        khachhangview.Gioitinh = khachhang.Gioitinh;
                        khachhangview.Diachi = khachhang.Diachi;
                        khachhangview.Sdt = khachhang.Sdt;
                        khachhangview.Email = khachhang.Email;
                        khachhangview.Masothue = khachhang.Masothue;
                        khachhangview.Matkhau = khachhang.Matkhau;
                        khachhangview.Ghichu = khachhang.Ghichu;
                        khachhangview.Facebook = khachhang.Facebook;
                        khachhangview.Zalo = khachhang.Zalo;
                        khachhangview.Active = 1;


                        _context.Update(khachhangview);
                        await _context.SaveChangesAsync();



                        return RedirectToAction("PersonalPage", "Home");
                    }
                }

            }
            catch
            {
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> PersonalPageEditPass(string Matkhau)
        {
            try
            {
                //chi tiết đơn
                string employeeEmail = Request.Cookies["HienCaCookie"];
                if (employeeEmail != null)
                {
                    var khachhang = await _context.Khachhang.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
                    if (khachhang != null)
                    {
                        khachhang.Matkhau = Matkhau;
                        _context.Update(khachhang);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("PersonalPage", "Home");
                    }
                }

            }
            catch
            {
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home");

        }
        private string UploadedFile(KhachhangViewModel model)
        {
            string uniqueFileName = null;

            if (model.Hinhanh != null)
            {
                string uploadsFolder = Path.Combine(webHostEkhironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Hinhanh.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Hinhanh.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public async Task<IActionResult> PersonalPageEditImage(KhachhangViewModel khview)
        {
            try
            {
                //chi tiết đơn
                string khachhangEmail = Request.Cookies["HienCaCookie"];
                if (khachhangEmail != null)
                {
                    var khachhang = await _context.Khachhang.Where(e => (e.Email).Equals(khachhangEmail)).FirstOrDefaultAsync();
                    if (khachhang != null)
                    {

                        if (khview.Hinhanh != null)
                        {
                            string uniqueFileName = UploadedFile(khview);

                            khachhang.Hinhanh = uniqueFileName;
                        }
                        _context.Khachhang.Update(khachhang);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("PersonalPage", "Home");
                    }
                }

            }
            catch
            {
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
