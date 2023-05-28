using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using ElectronicsStore.ViewModel;

namespace ElectronicsStore.Controllers
{
    [Authorize]

    public class DataVisualizationController : Controller
    {
        private readonly ElectronicsStoreContext _context;

        public DataVisualizationController(ElectronicsStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(DateTime? from, DateTime? to, int? Idhh)
        {
            ViewBag.Head = "THỐNG KÊ SỐ LIỆU";

            if (from != null && to != null && Idhh != null)
            {
                ViewData["Date"] = "Dữ liệu từ: " + from?.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) + "đến: " + to?.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                var allHanghoa = await _context.Hanghoa.ToListAsync();

                var productQuantitiesNhap = _context.Noidungpnk.Include(p => p.IdhhNavigation).Where(i => i.Idhh == Idhh).Where(f => f.IdpnkNavigation.Ngaylap >= from && f.IdpnkNavigation.Ngaylap <= to).ToList()
                                                   .GroupBy(item => item.Idhh)
                                                   .Select(group => new ProductQuantityViewModel
                                                   {
                                                       Idhh = group.Key,
                                                       Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                       Soluong = group.Sum(item => item.Soluong)
                                                   })
                                                   .ToList();


                var productQuantitiesXuat = _context.Noidungpxk.Include(p => p.IdhhNavigation).Where(i => i.Idhh == Idhh).Where(f => f.IdpxkNavigation.Ngaylap >= from && f.IdpxkNavigation.Ngaylap <= to).ToList()
                                                   .GroupBy(item => item.Idhh)
                                                   .Select(group => new ProductQuantityViewModel
                                                   {
                                                       Idhh = group.Key,
                                                       Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                       Soluong = group.Sum(item => item.Soluong)
                                                   })
                                                   .ToList();



                var productQuantitiesTonKho = productQuantitiesNhap.Select(p => new ProductQuantityViewModel
                {
                    Idhh = p.Idhh,
                    Tenhh = p.Tenhh,
                    Soluong = p.Soluong - (productQuantitiesXuat.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0)
                }).ToList();

                //var productQuantitiesTonKho = new List<ProductQuantityViewModel>();
                //foreach (var hanghoa in allHanghoa)
                //{
                //    var tonkho = new ProductQuantityViewModel
                //    {
                //        Idhh = hanghoa.Idhh,
                //        Tenhh = hanghoa.Tenvl,
                //        Soluong = (productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0) - (productQuantitiesXuat.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0),
                //    };

                //    productQuantitiesTonKho.Add(tonkho);
                //}


                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };
                ViewBag.productQuantitiesNhap = JsonConvert.SerializeObject(productQuantitiesNhap, settings);
                ViewBag.productQuantitiesXuat = JsonConvert.SerializeObject(productQuantitiesXuat, settings);
                ViewBag.productQuantitiesTonKho = JsonConvert.SerializeObject(productQuantitiesTonKho, settings);
                return View();

            }
            else if (from != null && to != null)
            {
                ViewData["Date"] = "Dữ liệu từ: " + from?.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) + " đến: " + to?.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                var allHanghoa = await _context.Hanghoa.ToListAsync();

                var productQuantitiesNhap = _context.Noidungpnk.Include(p => p.IdhhNavigation).Where(f => f.IdpnkNavigation.Ngaylap >= from && f.IdpnkNavigation.Ngaylap <= to).ToList()
                                                   .GroupBy(item => item.Idhh)
                                                   .Select(group => new ProductQuantityViewModel
                                                   {
                                                       Idhh = group.Key,
                                                       Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                       Soluong = group.Sum(item => item.Soluong)
                                                   })
                                                   .ToList();


                var productQuantitiesXuat = _context.Noidungpxk.Include(p => p.IdhhNavigation).Where(f => f.IdpxkNavigation.Ngaylap >= from && f.IdpxkNavigation.Ngaylap <= to).ToList()
                                                   .GroupBy(item => item.Idhh)
                                                   .Select(group => new ProductQuantityViewModel
                                                   {
                                                       Idhh = group.Key,
                                                       Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                       Soluong = group.Sum(item => item.Soluong)
                                                   })
                                                   .ToList();



                var productQuantitiesTonKho = productQuantitiesNhap.Select(p => new ProductQuantityViewModel
                {
                    Idhh = p.Idhh,
                    Tenhh = p.Tenhh,
                    Soluong = p.Soluong - (productQuantitiesXuat.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0)
                }).ToList();

                //var productQuantitiesTonKho = new List<ProductQuantityViewModel>();
                //foreach (var hanghoa in allHanghoa)
                //{
                //    var tonkho = new ProductQuantityViewModel
                //    {
                //        Idhh = hanghoa.Idhh,
                //        Tenhh = hanghoa.Tenvl,
                //        Soluong = (productQuantitiesNhap.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0) - (productQuantitiesXuat.FirstOrDefault(q => q.Idhh == hanghoa.Idhh)?.Soluong ?? 0),
                //    };

                //    productQuantitiesTonKho.Add(tonkho);
                //}


                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };
                ViewBag.productQuantitiesNhap = JsonConvert.SerializeObject(productQuantitiesNhap, settings);
                ViewBag.productQuantitiesXuat = JsonConvert.SerializeObject(productQuantitiesXuat, settings);
                ViewBag.productQuantitiesTonKho = JsonConvert.SerializeObject(productQuantitiesTonKho, settings);
                return View();

            }
            else if (from == null && to == null && Idhh != null)
            {

                var allHanghoa = await _context.Hanghoa.ToListAsync();
                ViewData["Date"] = "Dữ liệu cho: " + allHanghoa.Where(i => i.Idhh == Idhh).FirstOrDefault().Tenvl;

                var productQuantitiesNhap = _context.Noidungpnk.Include(p => p.IdhhNavigation).Where(f => f.Idhh == Idhh).ToList()
                                                   .GroupBy(item => item.Idhh)
                                                   .Select(group => new ProductQuantityViewModel
                                                   {
                                                       Idhh = group.Key,
                                                       Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                       Soluong = group.Sum(item => item.Soluong)
                                                   })
                                                   .ToList();

                var productQuantitiesXuat = _context.Noidungpxk.Include(p => p.IdhhNavigation).Where(f => f.Idhh == Idhh).ToList()
                                                   .GroupBy(item => item.Idhh)
                                                   .Select(group => new ProductQuantityViewModel
                                                   {
                                                       Idhh = group.Key,
                                                       Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                       Soluong = group.Sum(item => item.Soluong)
                                                   })
                                                   .ToList();



                var productQuantitiesTonKho = productQuantitiesNhap.Select(p => new ProductQuantityViewModel
                {
                    Idhh = p.Idhh,
                    Tenhh = p.Tenhh,
                    Soluong = p.Soluong - (productQuantitiesXuat.Where(q => q.Idhh == p.Idhh).FirstOrDefault()?.Soluong ?? 0)
                }).ToList();



                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };
                ViewBag.productQuantitiesNhap = JsonConvert.SerializeObject(productQuantitiesNhap, settings);
                ViewBag.productQuantitiesXuat = JsonConvert.SerializeObject(productQuantitiesXuat, settings);
                ViewBag.productQuantitiesTonKho = JsonConvert.SerializeObject(productQuantitiesTonKho, settings);
                return View();

            }
            return View();

        }



        public async Task<IActionResult> Others(DateTime? from, DateTime? to, int? Idhh)
        {
            ViewBag.Head = "THỐNG KÊ SỐ LIỆU";

            if (from != null && to != null && Idhh != null)
            {
                ViewData["Date"] = "Dữ liệu từ: " + from?.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) + "đến: " + to?.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                var allHanghoa = await _context.Hanghoa.ToListAsync();

              


                var top5ProductbySales = _context.Noidungpxk.Include(p => p.IdhhNavigation).Where(i => i.Idhh == Idhh).Where(f => f.IdpxkNavigation.Ngaylap >= from && f.IdpxkNavigation.Ngaylap <= to).ToList()
                                                   .GroupBy(item => item.Idhh)
                                                   .Select(group => new ProductQuantityViewModel
                                                   {
                                                       Idhh = group.Key,
                                                       Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                       Mahh = group.FirstOrDefault().IdhhNavigation.Mavl,
                                                       Soluong = group.Sum(item => item.Soluong),
                                                       Dongia = group.Sum(item => item.Dongia),
                                                       Tongtien = group.Sum(item => item.Soluong) * group.Sum(item => item.Dongia)
                                                   })
                                                   .OrderByDescending(a=>a.Tongtien).Take(5).ToList();

                var top5Customer = _context.Noidungpxk.Include(p => p.IdhhNavigation).Include(p => p.IdpxkNavigation.IdkhNavigation).Where(i => i.Idhh == Idhh).Where(f => f.IdpxkNavigation.Ngaylap >= from && f.IdpxkNavigation.Ngaylap <= to).ToList()
                                                   .GroupBy(item => item.IdpxkNavigation.IdkhNavigation.Idkh)
                                                   .Select(group => new CustomerQuantityViewModel
                                                   {
                                                       Idkh = group.Key,
                                                       Tenkh = group.FirstOrDefault().IdpxkNavigation.IdkhNavigation.Tenkh,
                                                       Makh = group.FirstOrDefault().IdpxkNavigation.IdkhNavigation.Makh,
                                                       Gioitinh = group.FirstOrDefault().IdpxkNavigation.IdkhNavigation.Gioitinh,
                                                       Tongtien = group.Sum(item => item.Soluong * item.Dongia)
                                                   })
                                                   .OrderByDescending(a => a.Tongtien).Take(5).ToList();



                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };
                ViewBag.productQuantitiesNhap = JsonConvert.SerializeObject(top5ProductbySales, settings);
                ViewBag.productQuantitiesXuat = JsonConvert.SerializeObject(top5Customer, settings);
                return View();

            }
            else if (from != null && to != null)
            {
                ViewData["Date"] = "Dữ liệu từ: " + from?.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) + " đến: " + to?.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                var allHanghoa = await _context.Hanghoa.ToListAsync();

                var top5ProductbySales = _context.Noidungpxk.Include(p => p.IdhhNavigation).Where(f => f.IdpxkNavigation.Ngaylap >= from && f.IdpxkNavigation.Ngaylap <= to).ToList()
                                                    .GroupBy(item => item.Idhh)
                                                    .Select(group => new ProductQuantityViewModel
                                                    {
                                                        Idhh = group.Key,
                                                        Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                        Mahh = group.FirstOrDefault().IdhhNavigation.Mavl,
                                                        Soluong = group.Sum(item => item.Soluong),
                                                        Dongia = group.Sum(item => item.Dongia),
                                                        Tongtien = group.Sum(item => item.Soluong) * group.Sum(item => item.Dongia)
                                                    })
                                                    .OrderByDescending(a => a.Tongtien).Take(5).ToList();

                var top5Customer = _context.Noidungpxk.Include(p => p.IdhhNavigation).Include(p => p.IdpxkNavigation.IdkhNavigation).Where(f => f.IdpxkNavigation.Ngaylap >= from && f.IdpxkNavigation.Ngaylap <= to).ToList()
                                                   .GroupBy(item => item.IdpxkNavigation.IdkhNavigation.Idkh)
                                                   .Select(group => new CustomerQuantityViewModel
                                                   {
                                                       Idkh = group.Key,
                                                       Tenkh = group.FirstOrDefault().IdpxkNavigation.IdkhNavigation.Tenkh,
                                                       Makh = group.FirstOrDefault().IdpxkNavigation.IdkhNavigation.Makh,
                                                       Gioitinh = group.FirstOrDefault().IdpxkNavigation.IdkhNavigation.Gioitinh,
                                                       Tongtien = group.Sum(item => item.Soluong * item.Dongia)
                                                   })
                                                   .OrderByDescending(a => a.Tongtien).Take(5).ToList();


                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };
                ViewBag.top5ProductbySales = JsonConvert.SerializeObject(top5ProductbySales, settings);
                ViewBag.top5Customer = JsonConvert.SerializeObject(top5Customer, settings);
                return View();

            }
            else if (from == null && to == null && Idhh != null)
            {

                var allHanghoa = await _context.Hanghoa.ToListAsync();
                ViewData["Date"] = "Dữ liệu cho: " + allHanghoa.Where(i => i.Idhh == Idhh).FirstOrDefault().Tenvl;

                var top5ProductbySales = _context.Noidungpxk.Include(p => p.IdhhNavigation).Where(i => i.Idhh == Idhh).ToList()
                                                   .GroupBy(item => item.Idhh)
                                                   .Select(group => new ProductQuantityViewModel
                                                   {
                                                       Idhh = group.Key,
                                                       Tenhh = group.FirstOrDefault().IdhhNavigation.Tenvl,
                                                       Mahh = group.FirstOrDefault().IdhhNavigation.Mavl,
                                                       Soluong = group.Sum(item => item.Soluong),
                                                       Dongia = group.Sum(item => item.Dongia),
                                                       Tongtien = group.Sum(item => item.Soluong) * group.Sum(item => item.Dongia)
                                                   })
                                                   .OrderByDescending(a => a.Tongtien).Take(5).ToList();

                var top5Customer = _context.Noidungpxk.Include(p => p.IdhhNavigation).Include(p => p.IdpxkNavigation.IdkhNavigation).Where(i => i.Idhh == Idhh).ToList()
                                                   .GroupBy(item => item.IdpxkNavigation.IdkhNavigation.Idkh)
                                                   .Select(group => new CustomerQuantityViewModel
                                                   {
                                                       Idkh = group.Key,
                                                       Tenkh = group.FirstOrDefault().IdpxkNavigation.IdkhNavigation.Tenkh,
                                                       Makh = group.FirstOrDefault().IdpxkNavigation.IdkhNavigation.Makh,
                                                       Gioitinh = group.FirstOrDefault().IdpxkNavigation.IdkhNavigation.Gioitinh,
                                                       Tongtien = group.Sum(item => item.Soluong * item.Dongia)
                                                   })
                                                   .OrderByDescending(a => a.Tongtien).Take(5).ToList();



                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };
                ViewBag.productQuantitiesNhap = JsonConvert.SerializeObject(top5ProductbySales, settings);
                ViewBag.productQuantitiesXuat = JsonConvert.SerializeObject(top5Customer, settings);
                return View();

            }
            return View();

        }

    }
}
