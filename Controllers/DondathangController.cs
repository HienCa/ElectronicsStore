using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Http;
using ElectronicsStore.ViewModel;
using Newtonsoft.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ElectronicsStore.Controllers
{
    public class DondathangController : Controller
    {
        private readonly ElectronicsStoreContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DondathangController(ElectronicsStoreContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Dondathang
        [Authorize]

        public async Task<IActionResult> Index()
        {
            var electronicsStoreContext = await _context.Dondathang.Where(a => a.Active == 1).Include(p => p.IdkhNavigation).OrderByDescending(a => a.Iddh).ToListAsync();

            ViewBag.Head = "Quản Lý Đơn Đặt Hàng";
            ViewData["Khachhang"] = await _context.Khachhang.Where(a => a.Active == 1).ToListAsync();
            ViewData["Hanghoa"] = await _context.Hanghoa.Where(a => a.Active == 1).ToListAsync();
            return View(electronicsStoreContext);
        }
        public async Task<IActionResult> TrashList(int id)
        {
            var electronicsStoreContext = await _context.Dondathang.Where(a => a.Active == 0).Include(p => p.IdkhNavigation).ToListAsync();

            ViewBag.Head = "Khôi Phục Đơn Đặt Hàng";
            return View(electronicsStoreContext);
        }
        public async Task<IActionResult> ReStore(int id)
        {
            var dondathang = await _context.Dondathang
                .FirstOrDefaultAsync(m => m.Iddh == id);
            dondathang.Active = 1;
            _context.Update(dondathang);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrashList");
        }

        // GET: Dondathang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var noidungddh = await _context.Noidungddh
                                                 .Where(i => i.Iddh == id)
                                                .Include(p => p.IddhNavigation)
                                                .Include(p => p.IddhNavigation.IdkhNavigation)
                                                .Include(p => p.IdhhNavigation)
                                                .ToListAsync();

                List<NoidungddhViewModel> listnoidungviewmodel = new List<NoidungddhViewModel>();
                foreach (Noidungddh item in noidungddh)
                {
                    NoidungddhViewModel noidungviewmodel = new NoidungddhViewModel();
                    noidungviewmodel.Idndddh = item.Idndddh;
                    noidungviewmodel.Soluong = item.Soluong;
                    noidungviewmodel.Dongia = item.Dongia;
                    noidungviewmodel.Hethanbh = item.Hethanbh;
                    noidungviewmodel.Idhh = item.Idhh;
                    noidungviewmodel.Iddh = item.Iddh;
                    noidungviewmodel.Tenhh = item.IdhhNavigation.Tenvl;
                    noidungviewmodel.Hinhanh = item.IdhhNavigation.Hinhanh;


                    var currentStock = await _context.Noidungpnk
                                                            .Where(p => p.Idhh == item.Idhh)
                                                            .SumAsync(p => p.Soluong) - await _context.Noidungpxk
                                                                                                                .Where(p => p.Idhh == item.Idhh)
                                                                                                                .SumAsync(p => p.Soluong);

                    noidungviewmodel.SoLuongTon = currentStock;

                    //StatusViewModel statusviewmodel = new StatusViewModel();
                    if (currentStock < item.Soluong)
                    {
                        //trong kho thiếu
                        noidungviewmodel.SoLuongThieu = item.Soluong - currentStock;

                        ViewData["Status"] = 0;

                    }
                    else
                    {
                        //trong kho đủ

                        noidungviewmodel.SoLuongThieu = 0;
                        ViewData["Status"] = 1;


                    }

                    listnoidungviewmodel.Add(noidungviewmodel);

                }

                ViewData["Dondathang"] = await _context.Dondathang.Where(a => a.Iddh == id).FirstOrDefaultAsync();
                return View(listnoidungviewmodel);
            }
            catch
            {
                return RedirectToAction("Index", "Dondathang");

            }
        }


        // GET: Dondathang/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Dondathang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dondathang dondathang)
        {
            if (ModelState.IsValid)
            {

                string employeeEmail = Request.Cookies["HienCaCookie"];
                //RSAEncryption rsa = new RSAEncryption();

                //employeeEmail = rsa.Decrypt(employeeEmail);

                var nhanvien = await _context.Nhanvien.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
                dondathang.Ngaydat = DateTime.Now;
                dondathang.Trangthai = 0;

                dondathang.Madh = "DDH" + nhanvien.Manv + '-' + ((dondathang.Ngaydat).ToString()).Replace("/", "").Replace(" ", "");

                //Idnv từ đăng nhập
                _context.Add(dondathang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(dondathang);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateForGuest(Noidungddh ddh, Khachhang kh, string noidungphu, int ngaybaohanh)
        {
            try
            {

                string ipAddress = "";
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces)
                {
                    if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    {
                        IPInterfaceProperties ipProps = ni.GetIPProperties();
                        foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                        {
                            if (addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                ipAddress = addr.Address.ToString();
                            }
                        }
                    }
                }
                //ip có dấu chấm thay bằng X
                kh.Makh = ipAddress.Replace(".", "X") + kh.Sdt;
                Khachhang khachhangmoi = _context.Khachhang.Where(a => a.Makh.Equals(kh.Makh)).FirstOrDefault();
                if (khachhangmoi == null)
                {
                    kh.Gioitinh = 2.ToString();
                    _context.Khachhang.Add(kh);
                    await _context.SaveChangesAsync();
                }


                Khachhang khachhang = _context.Khachhang.Where(a => a.Makh.Equals(kh.Makh)).FirstOrDefault();
                Dondathang dondathang = new Dondathang();
                dondathang.Idkh = khachhang.Idkh;
                dondathang.Madh = GenerateOrderCode() + khachhang.Idkh;
                dondathang.Ngaydat = DateTime.Now;
                dondathang.Trangthai = 0;
                dondathang.Ghichu = noidungphu;

                _context.Dondathang.Add(dondathang);
                await _context.SaveChangesAsync();
                Dondathang dondathangmoi = _context.Dondathang.Where(ma => ma.Madh.Equals(dondathang.Madh)).FirstOrDefault();

                Noidungddh noidungddhmoi = new Noidungddh();
                noidungddhmoi.Iddh = dondathangmoi.Iddh;
                noidungddhmoi.Idhh = ddh.Idhh;
                noidungddhmoi.Soluong = ddh.Soluong;
                noidungddhmoi.Dongia = ddh.Dongia;

                //DateTime today = DateTime.Today;
                //DateTime hanbaohanh = today.AddDays(ngaybaohanh);
                //noidungddhmoi.Hethanbh = hanbaohanh;

                _context.Noidungddh.Add(noidungddhmoi);
                await _context.SaveChangesAsync();


                //Thông báo mail về đơn đặt hàng

                TempData["success"] = "Đặt hàng thành công!!!";
                TempData["Madh"] = dondathangmoi.Madh;
                TempData["Sdt"] = khachhang.Sdt;

                try
                {
                    if (khachhang.Email != null)
                    {
                        SendMailOrdered(khachhang, dondathangmoi);
                    }
                    if (khachhang.Sdt != null)
                    {
                        SendSMS(khachhang, dondathangmoi);
                    }
                }
                catch
                {
                    return RedirectToAction("Details", "Home", new { id = ddh.Idhh });

                }

                return RedirectToAction("Details", "Home", new { id = ddh.Idhh });

            }
            catch
            {
                return RedirectToAction("Details", "Home", new { id = ddh.Idhh });

            }

        }


        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateForGuestAuthen(Noidungddh ddh, Khachhang kh, string noidungphu, int ngaybaohanh)
        {
            try
            {

                Dondathang dondathang = new Dondathang();
                dondathang.Idkh = kh.Idkh;
                dondathang.Madh = GenerateOrderCode() + kh.Idkh;
                dondathang.Ngaydat = DateTime.Now;
                dondathang.Trangthai = 0;
                dondathang.Ghichu = noidungphu;

                _context.Dondathang.Add(dondathang);
                await _context.SaveChangesAsync();
                Dondathang dondathangmoi = _context.Dondathang.Where(ma => ma.Madh.Equals(dondathang.Madh)).FirstOrDefault();

                Noidungddh noidungddhmoi = new Noidungddh();
                noidungddhmoi.Iddh = dondathangmoi.Iddh;
                noidungddhmoi.Idhh = ddh.Idhh;
                noidungddhmoi.Soluong = ddh.Soluong;
                noidungddhmoi.Dongia = ddh.Dongia;

                //DateTime today = DateTime.Today;
                //DateTime hanbaohanh = today.AddDays(ngaybaohanh);
                //noidungddhmoi.Hethanbh = hanbaohanh;

                _context.Noidungddh.Add(noidungddhmoi);
                await _context.SaveChangesAsync();


                TempData["success"] = "Đặt hàng thành công!!!";
                TempData["Madh"] = dondathangmoi.Madh;
                TempData["Sdt"] = kh.Sdt;

                try
                {
                    if (kh.Email != null)
                    {
                        SendMailOrdered(kh, dondathangmoi);
                    }
                    if (kh.Sdt != null)
                    {
                        SendSMS(kh, dondathangmoi);
                    }
                }
                catch
                {
                    return RedirectToAction("Details", "Home", new { id = ddh.Idhh });

                }
                return RedirectToAction("Details", "Home", new { id = ddh.Idhh });

            }
            catch
            {
                return RedirectToAction("Details", "Home", new { id = ddh.Idhh });

            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateForGuestMultiOrder(Khachhang kh, string noidungphu, string cartItemsInput)
        {
            try
            {

                string ipAddress = "";
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces)
                {
                    if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    {
                        IPInterfaceProperties ipProps = ni.GetIPProperties();
                        foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                        {
                            if (addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                ipAddress = addr.Address.ToString();
                            }
                        }
                    }
                }
                //ip có dấu chấm thay bằng X
                kh.Makh = ipAddress.Replace(".", "X") + kh.Sdt;
                Khachhang khachhangmoi = _context.Khachhang.Where(a => a.Makh.Equals(kh.Makh)).FirstOrDefault();
                if (khachhangmoi == null)
                {
                    kh.Gioitinh = 2.ToString();
                    _context.Khachhang.Add(kh);
                    await _context.SaveChangesAsync();
                }


                Khachhang khachhang = _context.Khachhang.Where(a => a.Makh.Equals(kh.Makh)).FirstOrDefault();
                Dondathang dondathang = new Dondathang();
                dondathang.Idkh = khachhang.Idkh;
                dondathang.Madh = GenerateOrderCode() + khachhang.Idkh;
                dondathang.Ngaydat = DateTime.Now;
                dondathang.Trangthai = 0;
                dondathang.Ghichu = noidungphu;

                _context.Dondathang.Add(dondathang);
                await _context.SaveChangesAsync();
                Dondathang dondathangmoi = _context.Dondathang.Where(ma => ma.Madh.Equals(dondathang.Madh)).FirstOrDefault();


                List<CartItemViewModel> cartItems = JsonConvert.DeserializeObject<List<CartItemViewModel>>(cartItemsInput);

                foreach (CartItemViewModel item in cartItems)
                {
                    if (item.check == 1)
                    {
                        Noidungddh noidungddhmoi = new Noidungddh();
                        noidungddhmoi.Iddh = dondathangmoi.Iddh;

                        noidungddhmoi.Idhh = int.Parse(item.productId);
                        noidungddhmoi.Soluong = int.Parse(item.count);
                        noidungddhmoi.Dongia = int.Parse(item.productPrice);

                        //Hanghoa hanghoabaohanh = _context.Hanghoa.Where(id => id.Idhh == int.Parse(item.productId)).FirstOrDefault();
                        //DateTime today = DateTime.Today;
                        //DateTime hanbaohanh = today.AddDays(hanghoabaohanh.Thoigianbh);
                        //noidungddhmoi.Hethanbh = hanbaohanh;

                        _context.Noidungddh.Add(noidungddhmoi);
                        await _context.SaveChangesAsync();
                    }


                }
                TempData["success"] = "Đặt hàng thành công!!!";
                TempData["Madh"] = dondathang.Madh;
                TempData["Sdt"] = khachhang.Sdt;




                try
                {
                    if (khachhang.Email != null)
                    {
                        SendMailOrdered(khachhang, dondathangmoi);
                    }
                    if (khachhang.Sdt != null)
                    {
                        SendSMS(khachhang, dondathangmoi);
                    }
                }
                catch
                {
                    return RedirectToAction("Cart", "Home");

                }
                return RedirectToAction("Cart", "Home");

            }
            catch
            {
                //Response.StatusCode = 400;
                TempData["success"] = "Đặt hàng thất bại!!!";

                return RedirectToAction("Cart", "Home");

            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateForGuestMultiOrderAuthen(Khachhang kh, string noidungphu, string cartItemsInput)
        {
            try
            {
                //khách hàng đã đăng nhập hệ thống

                Dondathang dondathang = new Dondathang();
                dondathang.Idkh = kh.Idkh;
                dondathang.Madh = GenerateOrderCode() + kh.Idkh;
                dondathang.Ngaydat = DateTime.Now;
                dondathang.Trangthai = 0;
                dondathang.Ghichu = noidungphu;

                _context.Dondathang.Add(dondathang);
                await _context.SaveChangesAsync();
                Dondathang dondathangmoi = _context.Dondathang.Where(ma => ma.Madh.Equals(dondathang.Madh)).FirstOrDefault();


                List<CartItemViewModel> cartItems = JsonConvert.DeserializeObject<List<CartItemViewModel>>(cartItemsInput);

                foreach (CartItemViewModel item in cartItems)
                {
                    Noidungddh noidungddhmoi = new Noidungddh();
                    noidungddhmoi.Iddh = dondathangmoi.Iddh;

                    noidungddhmoi.Idhh = int.Parse(item.productId);
                    noidungddhmoi.Soluong = int.Parse(item.count);
                    noidungddhmoi.Dongia = int.Parse(item.productPrice);

                    //Hanghoa hanghoabaohanh = _context.Hanghoa.Where(id => id.Idhh == int.Parse(item.productId)).FirstOrDefault();
                    //DateTime today = DateTime.Today;
                    //DateTime hanbaohanh = today.AddDays(hanghoabaohanh.Thoigianbh);
                    //noidungddhmoi.Hethanbh = hanbaohanh;

                    _context.Noidungddh.Add(noidungddhmoi);
                    await _context.SaveChangesAsync();

                }
                TempData["success"] = "Đặt hàng thành công!!!";
                TempData["Madh"] = dondathang.Madh;
                TempData["Sdt"] = kh.Sdt;



                try
                {
                    if (kh.Email != null)
                    {
                        SendMailOrdered(kh, dondathangmoi);
                    }
                    if (kh.Sdt != null)
                    {
                        SendSMS(kh, dondathangmoi);
                    }
                }
                catch
                {
                    return RedirectToAction("Cart", "Home");

                }
                return RedirectToAction("Cart", "Home");

            }
            catch
            {
                TempData["success"] = "Đặt hàng thất bại!!!";

                return RedirectToAction("Cart", "Home");

            }

        }
        public static string GenerateOrderCode()
        {
            string orderCode = "";
            DateTime now = DateTime.Now;
            orderCode += now.Year.ToString().Substring(2, 2);
            orderCode += now.Month.ToString("00");
            orderCode += now.Day.ToString("00");
            orderCode += now.Hour.ToString("00");
            orderCode += now.Minute.ToString("00");
            orderCode += now.Second.ToString("00");
            orderCode += now.Millisecond.ToString("000");

            // Sinh chuỗi ngẫu nhiên với độ dài 4 ký tự
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            orderCode += new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());

            return orderCode;
        }




        // GET: Dondathang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dondathang = await _context.Dondathang.FindAsync(id);
            if (dondathang == null)
            {
                return NotFound();
            }

            return View(dondathang);
        }

        // POST: Dondathang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Dondathang dondathang)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    dondathang.Active = 1;

                    string employeeEmail = Request.Cookies["HienCaCookie"];
                    if (employeeEmail != null)
                    {
                        var nhanvien = await _context.Nhanvien.Where(e => (e.Email).Equals(employeeEmail)).FirstOrDefaultAsync();
                        //0 chuẩn bị hàng
                        //1 đóng gói
                        //2 xuất kho
                        //3 thanh toán
                        //4 hủy
                        if (nhanvien != null)
                        {

                            if (dondathang.Trangthai == 2)
                            {
                                List<Noidungddh> noidungdonhang = await _context.Noidungddh.Where(a => a.Iddh == dondathang.Iddh).Include(i => i.IddhNavigation).ToListAsync();

                                Phieuxuatkho phieuxuatkho = new Phieuxuatkho();
                                phieuxuatkho.Sophieu = GenerateOrderCode() + nhanvien.Idnv + dondathang.Idkh + dondathang.Iddh;
                                phieuxuatkho.Ngaylap = DateTime.Now;
                                phieuxuatkho.Idnv = nhanvien.Idnv;
                                phieuxuatkho.Idkh = dondathang.Idkh;

                                _context.Phieuxuatkho.Add(phieuxuatkho);
                                await _context.SaveChangesAsync();

                                Phieuxuatkho phieuxuatkhomoi = await _context.Phieuxuatkho.Where(a => a.Sophieu.Equals(phieuxuatkho.Sophieu)).FirstOrDefaultAsync();

                                foreach (Noidungddh item in noidungdonhang)
                                {
                                    Noidungpxk noidungpxk = new Noidungpxk();
                                    noidungpxk.Idpxk = phieuxuatkhomoi.Idpxk;

                                    noidungpxk.Idhh = item.Idhh;
                                    noidungpxk.Soluong = item.Soluong;
                                    noidungpxk.Dongia = item.Dongia;
                                    noidungpxk.Vat = 0;
                                    noidungpxk.Cktm = 0;

                                    _context.Noidungpxk.Add(noidungpxk);
                                    await _context.SaveChangesAsync();

                                    //Cập nhật hạn bảo hành
                                    Noidungddh hanghoabaohanh = await _context.Noidungddh.Where(dh => dh.Iddh == dondathang.Iddh).Where(h => h.Idhh == item.Idhh).FirstOrDefaultAsync();
                                    Hanghoa hh = await _context.Hanghoa.Where(i => i.Idhh == item.Idhh).FirstOrDefaultAsync();

                                    DateTime today = DateTime.Today;
                                    DateTime hanbaohanh = today.AddDays(hh.Thoigianbh);
                                    hanghoabaohanh.Hethanbh = hanbaohanh;

                                    _context.Noidungddh.Update(hanghoabaohanh);
                                    await _context.SaveChangesAsync();
                                }
                                Dondathang donhang = await _context.Dondathang.Where(a => a.Iddh == dondathang.Iddh).FirstOrDefaultAsync();
                                donhang.Trangthai = 2;
                                _context.Dondathang.Update(donhang);
                                await _context.SaveChangesAsync();


                                //gửi mail thông báo đến khách hàng
                                try
                                {
                                    Khachhang khachhang = await _context.Khachhang.Where(a => a.Idkh == dondathang.Idkh).FirstOrDefaultAsync();
                                    SendMailUpdateOrdered(khachhang, donhang, 2);
                                }
                                catch
                                {
                                    return RedirectToAction(nameof(Index));

                                }
                            }
                            else if (dondathang.Trangthai == 3)
                            {
                                float Tongtien = 0;
                                List<Noidungddh> noidungdonhang = await _context.Noidungddh.Where(a => a.Iddh == dondathang.Iddh).Include(i => i.IddhNavigation).ToListAsync();
                                foreach (Noidungddh item in noidungdonhang)
                                {
                                    Tongtien += item.Soluong * item.Dongia;
                                }

                                Phieuthunokh phieuthunokh = new Phieuthunokh();
                                phieuthunokh.Sophieu = "PTN" + GenerateOrderCode() + nhanvien.Idnv + dondathang.Idkh + dondathang.Iddh;
                                phieuthunokh.Ngaylap = DateTime.Now;
                                phieuthunokh.Idnv = nhanvien.Idnv;

                                //1 tiền mặt
                                //2 chuyển khoản
                                //3 nợ
                                phieuthunokh.Idhttt = 1;//mặc định
                                _context.Phieuthunokh.Add(phieuthunokh);
                                await _context.SaveChangesAsync();

                                Phieuthunokh phieuthunokhmoi = await _context.Phieuthunokh.Where(a => a.Sophieu.Equals(phieuthunokh.Sophieu)).FirstOrDefaultAsync();

                                Noidungthunoddh noidungthunoddh = new Noidungthunoddh();
                                noidungthunoddh.Idptnkh = phieuthunokhmoi.Idptnkh;
                                noidungthunoddh.Ngaythuno = DateTime.Now;
                                noidungthunoddh.Iddh = dondathang.Iddh;

                                //tổng tiền của đơn hàng - tất cả các nội dung đơn đặt hàng
                                noidungthunoddh.Sotien = Tongtien;

                                _context.Noidungthunoddh.Add(noidungthunoddh);
                                await _context.SaveChangesAsync();


                                Dondathang donhang = await _context.Dondathang.Where(a => a.Iddh == dondathang.Iddh).FirstOrDefaultAsync();
                                donhang.Trangthai = 3;
                                donhang.Ngaygiao = DateTime.Now;
                                _context.Dondathang.Update(donhang);

                                await _context.SaveChangesAsync();
                                

                                //gửi mail thông báo đến khách hàng
                                try
                                {
                                    Khachhang khachhang= await _context.Khachhang.Where(a => a.Idkh == dondathang.Idkh).FirstOrDefaultAsync();
                                    SendMailUpdateOrdered(khachhang, donhang, 3);
                                }
                                catch
                                {
                                    return RedirectToAction(nameof(Index));

                                }

                            }
                            //else if (dondathang.Trangthai == 4)
                            //{
                            //    List<Noidungddh> noidungddhtra = await _context.Noidungddh.Where(a => a.Iddh == dondathang.Iddh).ToListAsync();

                            //    foreach (Noidungddh noidungtra in noidungddhtra)
                            //    {
                            //        _context.Noidungddh.Remove(noidungtra);
                            //        await _context.SaveChangesAsync();
                            //    }


                            //}
                            else if (dondathang.Trangthai == 0 || dondathang.Trangthai == 1 || dondathang.Trangthai == 4)
                            {
                                Dondathang donhang = await _context.Dondathang.Where(a => a.Iddh == dondathang.Iddh).FirstOrDefaultAsync();
                                donhang.Trangthai = dondathang.Trangthai;
                                _context.Dondathang.Update(donhang);
                                await _context.SaveChangesAsync();

                            }
                        }
                    }


                }
                catch
                {
                    return RedirectToAction(nameof(Index));

                }
                return RedirectToAction(nameof(Index));
            }

            return View(dondathang);
        }

        // GET: Dondathang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dondathang = await _context.Dondathang
                .Include(p => p.IdkhNavigation)
                .FirstOrDefaultAsync(m => m.Iddh == id);
            if (dondathang == null)
            {
                return NotFound();
            }

            return View(dondathang);
        }

        // POST: Dondathang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dondathang = await _context.Dondathang.FindAsync(id);
            dondathang.Active = 0;
            _context.Dondathang.Update(dondathang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DondathangExists(int id)
        {
            return _context.Dondathang.Any(e => e.Iddh == id);
        }




        [HttpPost]
        public IActionResult SendMailOrdered(Khachhang kh, Dondathang dh)
        {
            try
            {

                string message = "";
                var address = kh.Email;

                var subject = "Trạng thái đơn đặt hàng";

                var mailContent = new MailContent();
                mailContent.Subject = subject;
                if (address != null)
                {
                    message = "Chào '" + kh.Tenkh + "'"
                                            + "<br/>Mã đơn hàng của quý khách là: " + dh.Madh
                                            + "<br/>Số điện thoại đã đặt hàng là: " + kh.Sdt
                                            + "<br/><br/>Quý khách vui lòng truy cập trang web vào mục 'Đơn hàng', nhập thông tin mã đơn hàng và số điện thoại để có thể xem lại và theo dõi đơn hàng vừa đặt."
                                            + "<br/><br/>Đơn hàng của bạn sẽ sớm đến nơi, quý khách vui lòng chú ý điện thoại của mình để không bỏ lỡ đơn hàng"
                                            + "<br/><br/> Chúc quý khách một ngày tốt lành!!!"
                                            + "<br/><br/> Xin cảm ơn quý khách!"
                                            + "<br/><br/>---Nguyễn Văn Hiền---";
                    mailContent.To = kh.Email;
                }
                else
                {
                    ViewData["CheckEmail"] = "Email không tồn tại, vui lòng kiểm tra lại!!!";
                }
                mailContent.Body = "<h1>Electronics Store</h1><br/>" + message;


                Service.SendMailService c = new Service.SendMailService();
                c.SendMail(mailContent);

                _context.SaveChanges();

                ViewData["SuccessMessage"] = "Chúng tôi đã gửi mail xác nhận đến cho bạn. Vui lòng kiểm tra mail!";

            }
            catch (Exception e)
            {
                ViewData["errorMessage"] = "Email không khả dụng";
            }

            return View();
        }
        [HttpPost]
        public IActionResult SendMailUpdateOrdered(Khachhang kh, Dondathang dh, int trangthai)
        {
            try
            {
                string mess = "";
                string employee = "";
                string message = "";
                var address = kh.Email;

                var subject = "Theo dõi tiến độ đơn đặt hàng";

                var mailContent = new MailContent();
                mailContent.Subject = subject;
                if (address != null)
                {
                    if(trangthai == 2)
                    {
                        mess = "<br/><br/>Đơn hàng của quý khách đã xuất kho.";
                        employee = "<br/><br/>Người giao: nhân viên bộ phận giao hàng Electronics Store";
                    }
                    if (trangthai == 3)
                    {
                        mess = "<br/><br/>Qúy khách đã hoàn tất thanh toán đơn hàng.";
                    }
                    message = "Chào '" + kh.Tenkh + "'"
                                            + "<br/>Mã đơn hàng của quý khách là: " + dh.Madh
                                            + "<br/>Số điện thoại đã đặt hàng là: " + kh.Sdt
                                            + mess
                                            + employee
                                            + "<br/><br/> Chúc quý khách một ngày tốt lành!!!"
                                            + "<br/><br/> Xin cảm ơn quý khách!"
                                            + "<br/><br/>---Nguyễn Văn Hiền---";
                    mailContent.To = kh.Email;
                }
                else
                {
                    ViewData["CheckEmail"] = "Email không tồn tại, vui lòng kiểm tra lại!!!";
                }
                mailContent.Body = "<h1>Electronics Store</h1><br/>" + message;


                Service.SendMailService c = new Service.SendMailService();
                c.SendMail(mailContent);

                _context.SaveChanges();

                ViewData["SuccessMessage"] = "Chúng tôi đã gửi mail xác nhận đến cho bạn. Vui lòng kiểm tra mail!";

            }
            catch (Exception e)
            {
                ViewData["errorMessage"] = "Email không khả dụng";
            }

            return View();
        }
        public string FormatPhoneNumber(string phoneNumber)
        {
            // Remove leading 0
            phoneNumber = phoneNumber.TrimStart('0');

            // Add +84 prefix
            phoneNumber = "+84" + phoneNumber;

            return phoneNumber;
        }


        public void SendSMS(Khachhang khachhang, Dondathang dondathang)
        {
            // Set up the Twilio client
            var accountSid = "ACceab86b7a7dc86fc3a5cf69aa7c22333";
            var authToken = "a770436f58146877b4625b76d0e64f4b";
            TwilioClient.Init(accountSid, authToken);

            // Send an SMS message
            var message = MessageResource.Create(
                body: "Xin chào " + khachhang.Tenkh
                                    + "!\nChúc mừng quý khách đã đặt hàng thành công."
                                    + "\nMã đơn hàng của bạn là: " + dondathang.Madh
                                    + ".\nSố điện thoại đặt hàng là: " + khachhang.Sdt
                                    + ".\nQúy khách vui lòng truy cập Electronics Stores để theo dõi đơn đặt hàng."
                                    + "Qúy khách vui lòng truy cập Electronics Stores để theo dõi đơn đặt hàng.",
                from: new Twilio.Types.PhoneNumber("+13184966314"),
                to: new Twilio.Types.PhoneNumber(FormatPhoneNumber(khachhang.Sdt))
            );

        }
    }
}
