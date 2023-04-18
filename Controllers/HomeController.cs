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

namespace ElectronicsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ElectronicsStoreContext _context;

        public HomeController(ElectronicsStoreContext context)
        {
            _context = context;
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
        public async Task<IActionResult> Cart(int id)
        {
            List<Hanghoa> h = await _context.Hanghoa.Where(a => a.Idhh == id).Where(a => a.Active == 1).ToListAsync();
            return View(h);
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
