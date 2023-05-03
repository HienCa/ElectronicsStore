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

        public async Task<IActionResult> Index()
        {
            ViewBag.Head = "THỐNG KÊ SỐ LIỆU";

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
       
    }
}
