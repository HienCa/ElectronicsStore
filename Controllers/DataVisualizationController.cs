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
            var productQuantitiesTonKho = productQuantitiesNhap.Join(
                                productQuantitiesXuat,
                                p => p.Idhh,
                                q => q.Idhh,
                                (p, q) => new ProductQuantityViewModel
                                {
                                    Idhh = p.Idhh,
                                    Tenhh = p.Tenhh,
                                    Soluong = p.Soluong - q.Soluong
                                }).ToList();

            //       var productQuantitiesTonKho = _context.Hanghoa
            //.GroupJoin(
            //    productQuantitiesNhap,
            //    p => p.Idhh,
            //    qn => qn.Idhh,
            //    (p, qn) => new { Product = p, QuantitiesNhap = qn })
            //.GroupJoin(
            //    productQuantitiesXuat,
            //    pqn => pqn.Product.Idhh,
            //    qx => qx.Idhh,
            //    (pqn, qx) => new { pqn.Product, pqn.QuantitiesNhap, QuantitiesXuat = qx })
            //.SelectMany(
            //    pq => pq.QuantitiesNhap.DefaultIfEmpty(),
            //    (p, qn) => new { p.Product, QuantitiesNhap = qn, p.QuantitiesXuat })
            //.SelectMany(
            //    pq => pq.QuantitiesXuat.DefaultIfEmpty(),
            //    (p, qx) => new ProductQuantityViewModel
            //    {
            //        Idhh = p.Product.Idhh,
            //        Tenhh = p.Product.Tenvl,
            //        Soluong = (p.QuantitiesNhap != null ? p.QuantitiesNhap.Soluong : 0) - (qx != null ? qx.Soluong : 0)
            //    })
            //.ToList()
            //.AsQueryable()
            //.Where(pq => pq.Soluong > 0)
            //.ToList();



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
