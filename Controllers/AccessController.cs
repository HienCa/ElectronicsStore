﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Cryptography;
using ElectronicsStore.Models;
using ElectronicsStore.ViewModel;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
//Scaffold-DbContext “Data Source=.;Initial Catalog=ElectronicsStore;Persist Security Info=True;User ID=sa;Password=sa”  Microsoft.EntityFrameworkCore.SQLServer -f –Output Models
namespace ElectronicsStore.Controllers
{
    public class AccessController : Controller
    {
        private readonly ElectronicsStoreContext _context;

        public AccessController(ElectronicsStoreContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dondathang");

            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //HttpCookie cookie = new HttpCookie("HienCaCookie");
            //cookie.Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies.Add(cookie);
            if (Request.Cookies["HienCaCookie"] != null)
            {
                Response.Cookies.Delete("HienCaCookie");
            }
            else if (Request.Cookies["CustomerCookie"] != null)
            {
                Response.Cookies.Delete("CustomerCookie");
            }
            return RedirectToAction("Login", "Access");
        }
        public async Task<IActionResult> Signin()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Signin(Khachhang khachhang, string Matkhaunhaplai)
        {
            if (khachhang.Matkhau.Equals(Matkhaunhaplai))
            {
                Khachhang khachhangcu = await _context.Khachhang.Where(a => a.Email.Equals(khachhang.Email)).FirstOrDefaultAsync();
                if (khachhangcu == null)
                {
                    SHA512Encryption sha = new SHA512Encryption();

                    //khachhang.Email = rsa.Encrypt(khachhang.Email);
                    khachhang.Matkhau = sha.Encrypt(khachhang.Matkhau);

                    _context.Khachhang.Add(khachhang);
                    await _context.SaveChangesAsync();
                    ViewData["SigninSuccess"] = "Đăng ký thành công!!!";
                }
                else
                {
                    ViewData["SigninFailure"] = "Đăng ký thất bại!";
                    ViewData["Thongtin"] = khachhang;

                }
            }
            else
            {
                ViewData["PassInvalid"] = "Mật khẩu không trùng khớp!";

            }

            return View();
        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Account account)
        {
            if (ModelState.IsValid && account.Email != null)
            {
                SHA512Encryption sha = new SHA512Encryption();



                //Nhanvien employee = _context.Nhanvien.Where(tk => tk.Email.Equals(account.Email)).Where(tk => tk.Matkhau.Equals(rsa.Encrypt(account.PassWord))).FirstOrDefault();
                Nhanvien employee = _context.Nhanvien.Where(tk => tk.Email.Equals(account.Email)).Where(tk => tk.Active==1).FirstOrDefault();
                Khachhang customer = _context.Khachhang.Where(tk => tk.Email.Equals(account.Email)).Where(tk => tk.Active == 1).FirstOrDefault();

                var Role = "";

                if (employee != null || customer != null)
                {


                    if (employee != null)
                    {
                        if (sha.Verify(account.PassWord, employee.Matkhau))
                        {
                            Response.Cookies.Append("HienCaCookie", account.Email);

                            if (employee.Email.Equals("nguyenvanhien050601@gmail.com"))
                            {
                                Role = "admin";
                            }
                            else
                            {
                                Role = "manage";

                            }
                        }

                    }
                    else if (customer != null)
                    {
                        bool h = sha.Verify(account.PassWord, customer.Matkhau);
                        if (sha.Verify(account.PassWord, customer.Matkhau))
                        {
                            Response.Cookies.Append("CustomerCookie", account.Email);

                        }
                        //Response.Cookies.Append("CustomerCookie", account.Email);


                    }
                    List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, account.Email),
                    new Claim(ClaimTypes.Role, Role)

                };
                    ClaimsIdentity claimIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = account.KeepLoggedIn
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity), properties);



                    if (employee != null)
                    {

                        if (sha.Verify(account.PassWord, employee.Matkhau))
                        {
                            return RedirectToAction("Index", "Dondathang");
                        }
                        else
                        {
                            ViewData["WrongPass"] = "Mật khẩu không chính xác!";
                            return View();

                        }
                    }
                    else if (customer != null)
                    {
                        if (sha.Verify(account.PassWord, customer.Matkhau))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewData["WrongPass"] = "Mật khẩu không chính xác!";
                            return View();
                        }
                    }
                }
                else
                {
                    ViewData["LoginFailure"] = "Tài khoản đăng nhập không hợp lệ";
                    ViewData["Thongtin"] = account;

                }
            }

            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public string GenerateToken(int length)
        {
            using (RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider())
            {
                byte[] tokenBuffer = new byte[length];
                cryptRNG.GetBytes(tokenBuffer);
                return Convert.ToBase64String(tokenBuffer);
            }
        }
        [HttpPost]
        public IActionResult ForgotPassword(Account account)
        {

            var newPassword = GenerateToken(12);
            string errorMessage = "Email không chính xác. Vui lòng kiểm tra lại email!";


            try
            {
                Nhanvien nv = _context.Nhanvien.Where(tk => tk.Email.Equals(account.Email)).FirstOrDefault();
                Khachhang kh = _context.Khachhang.Where(tk => tk.Email.Equals(account.Email)).FirstOrDefault();

                string message = "";
                var address = account.Email;

                var subject = "Khôi phục mật khẩu";

                var mailContent = new MailContent();
                mailContent.Subject = subject;
                if (kh != null)
                {
                    message = "Xin Chào '" + kh.Tenkh + "' Mật khẩu mới của bạn là " + newPassword;
                    SHA512Encryption sha = new SHA512Encryption();
                    kh.Matkhau = sha.Encrypt(newPassword); 
                    mailContent.To = kh.Email;
                }
                if (nv != null)
                {
                    message = "Xin Chào '" + nv.Tennv + "' Mật khẩu mới của bạn là " + newPassword;
                    SHA512Encryption sha = new SHA512Encryption();

                    nv.Matkhau = sha.Encrypt(newPassword);
                    mailContent.To = nv.Email;
                }
                else
                {
                    ViewData["CheckEmail"] = "Email không tồn tại, vui lòng kiểm tra lại!!!";
                }
                mailContent.Body = "<h1>Từ Electronic Store</h1><br/>" + message;


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

        public static string RandomNumber(int numberRD)
        {
            string randomStr = "";
            try
            {

                int[] myIntArray = new int[numberRD];
                int x;
                //that is to create the random # and add it to string
                Random autoRand = new Random();
                for (x = 0; x < numberRD; x++)
                {
                    myIntArray[x] = System.Convert.ToInt32(autoRand.Next(0, 9));
                    randomStr += (myIntArray[x].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return randomStr;
        }


    }
}
