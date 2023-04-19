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

namespace ElectronicsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ElectronicsStoreContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(ElectronicsStoreContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            //action Cart
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult> Index()
        {
            TempData["Nhomhh"] = await _context.Nhomhh.Where(a => a.Active == 1).ToListAsync();
            List<Hanghoa> h = await _context.Hanghoa.Where(a => a.Active == 1).ToListAsync();


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
                                                        Idnhh = hanghoa.Idnhh
                                                    })
                                                    .ToList();

            TempData["Hanghoa"] = hanghoaviewmodel;

            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
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

            string cartId = Request.Cookies["ElectronicsStore_shopping_cart_id"];

            // Nếu cookie không tồn tại thì tạo mới cookie và lưu vào client
            if (string.IsNullOrEmpty(cartId))
            {
                // Lấy địa chỉ IP của khách hàng
                string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();

                // Mã hóa địa chỉ IP bằng SHA512
                byte[] ipBytes = Encoding.ASCII.GetBytes(ipAddress);
                byte[] hashedIpBytes = SHA512.Create().ComputeHash(ipBytes);
                string hashedIpString = BitConverter.ToString(hashedIpBytes).Replace("-", "").ToLower();

                // Lưu chuỗi đã mã hóa vào cookie
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddYears(1); // Thiết lập thời gian sống của cookie
                Response.Cookies.Append("ElectronicsStore_shopping_cart_id", hashedIpString, cookieOptions);

                // Gán giá trị mới tạo cho biến cartId
                cartId = hashedIpString;
            }
            else
            {
                //truy xuất cart theo cartId;


            }

            // Tiếp tục xử lý dữ liệu và trả về View
            //List<Hanghoa> h = await _context.Hanghoa.Where(a => a.Idhh == id).Where(a => a.Active == 1).ToListAsync();
            return View();

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
