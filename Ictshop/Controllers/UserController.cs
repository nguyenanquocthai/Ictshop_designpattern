using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;
namespace Ictshop.Controllers
{
    public class UserController : Controller
    {
        //Qlbanhang db = new Qlbanhang();
        ////ĐĂNG KÝ
        //public ActionResult Dangky()
        //{
        //    return View();
        //}

        //// ĐĂNG KÝ PHƯƠNG THỨC POST
        //[HttpPost]
        //public ActionResult Dangky(Nguoidung nguoidung)
        //{
        //    try
        //    {
        //        Session["userReg"] = nguoidung;

        //        // Thêm người dùng  mới
        //        db.Nguoidungs.Add(nguoidung);
        //        // Lưu lại vào cơ sở dữ liệu
        //        db.SaveChanges();
        //        // Nếu dữ liệu đúng thì trả về trang đăng nhập
        //        if (ModelState.IsValid)
        //        {
        //            //return RedirectToAction("Dangnhap");
        //            ViewBag.RegOk = "Đăng kí thành công. Đăng nhập ngay";
        //            ViewBag.isReg = true;
        //            return View("Dangky");

        //        }
        //        else
        //        {
        //            return View("Dangky");
        //        }

        //    }
        //    catch
        //    {
        //        return View();
        //    }

        //}
        public ActionResult Dangky()
        {
            return View();
        }
        //test proxy
        public class UserController : Controller
        {
            private readonly IDbProxy dbProxy;

            public UserController()
            {
                // Khởi tạo proxy
                dbProxy = new DbProxy();
            }

            // Đăng ký phương thức POST
            [HttpPost]
            public ActionResult Dangky(Nguoidung nguoidung)
            {
                try
                {
                    Session["userReg"] = nguoidung;

                    // Thêm người dùng mới thông qua proxy
                    dbProxy.AddUser(nguoidung);
                    // Lưu thay đổi vào cơ sở dữ liệu thông qua proxy
                    dbProxy.SaveChanges();

                    // Nếu dữ liệu đúng thì trả về trang đăng nhập
                    if (ModelState.IsValid)
                    {
                        ViewBag.RegOk = "Đăng kí thành công. Đăng nhập không?";
                        ViewBag.isReg = true;
                        return View("Dangky");
                    }
                    else
                    {
                        return View("Dangky");
                    }
                }
                catch
                {
                    return View();
                }
            }
        }
            public ActionResult Dangnhap()
        {
            return View();

        }

        //code cũ
        /*[HttpPost]
        public ActionResult Dangnhap(FormCollection userlog)
        {
            string userMail = userlog["userMail"].ToString();
            string password = userlog["password"].ToString();
            var islogin = db.Nguoidungs.SingleOrDefault(x => x.Email.Equals(userMail) && x.Matkhau.Equals(password));

            if (islogin != null)
            {
                if (userMail == "Admin@gmail.com")
                {
                    Session["use"] = islogin;
                    return RedirectToAction("Index", "Admin/Home");
                }
                else
                {
                    Session["use"] = islogin;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Fail = "Tài khoản hoặc mật khẩu không chính xác.";
                return View("Dangnhap");
            }

        }
        public ActionResult DangXuat()
        {
            Session["use"] = null;
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Profile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoidung nguoiDung = db.Nguoidungs.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoidung nguoidung = db.Nguoidungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", nguoidung.IDQuyen);
            return View(nguoidung);
        }*/

        //FACADE PATTERN
        [HttpPost]
        public ActionResult Dangnhap(FormCollection userlog)
        {
            string userMail = userlog["userMail"].ToString();
            string password = userlog["password"].ToString();

            // Sử dụng facade để xác thực người dùng
            IUserAuthentication userAuth = new UserAuthenticationFacade(db);
            bool isAuthenticated = userAuth.Authenticate(userMail, password);

            if (isAuthenticated)
            {
                // Xác thực thành công
                if (userMail == "Admin@gmail.com")
                {
                    Session["use"] = db.Nguoidungs.Single(x => x.Email.Equals(userMail));
                    return RedirectToAction("Index", "Admin/Home");
                }
                else
                {
                    Session["use"] = db.Nguoidungs.Single(x => x.Email.Equals(userMail));
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                // Xác thực thất bại
                ViewBag.Fail = "Tài khoản hoặc mật khẩu không chính xác.";
                return View("Dangnhap");
            }
        }

        // POST: Admin/Nguoidungs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNguoiDung,Hoten,Email,Dienthoai,Matkhau,IDQuyen, Anhdaidien,Diachi")] Nguoidung nguoidung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoidung).State = EntityState.Modified;
                db.SaveChanges();
                //@ViewBag.show = "Chỉnh sửa hồ sơ thành công";
                //return View(nguoidung);
                return RedirectToAction("Profile", new { id = nguoidung.MaNguoiDung });

            }
            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", nguoidung.IDQuyen);
            return View(nguoidung);
        }
        public static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        public static string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }

        ////proxy
        //public class YourController : Controller
        //{
        //    private readonly IDbProxy dbProxy;

        //    public YourController()
        //    {
        //        // Khởi tạo proxy
        //        dbProxy = new DbProxy();
        //    }

        //    // Đăng ký phương thức POST
        //    [HttpPost]
        //    public ActionResult Dangky(Nguoidung nguoidung)
        //    {
        //        try
        //        {
        //            Session["userReg"] = nguoidung;

        //            // Thêm người dùng mới thông qua proxy
        //            dbProxy.AddUser(nguoidung);
        //            // Lưu thay đổi vào cơ sở dữ liệu thông qua proxy
        //            dbProxy.SaveChanges();

        //            // Nếu dữ liệu đúng thì trả về trang đăng nhập
        //            if (ModelState.IsValid)
        //            {
        //                ViewBag.RegOk = "Đăng kí thành công. Đăng nhập không ?";
        //                ViewBag.isReg = true;
        //                return View("Dangky");
        //            }
        //            else
        //            {
        //                return View("Dangky");
        //            }
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
        //}
    }
}