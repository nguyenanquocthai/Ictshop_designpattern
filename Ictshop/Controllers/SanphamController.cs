using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.DAO;
using Ictshop.Models;

namespace Ictshop.Controllers
{
    public class SanphamController : Controller
    {
        /*Qlbanhang db = new Qlbanhang();

        // GET: Sanpham
        public ActionResult dtiphonepartial()
        {
            var ip = db.Sanphams.Where(n=>n.Mahang==2).Take(4).ToList();
           return PartialView(ip);
        }
        public ActionResult dtsamsungpartial()
        {
            var ss = db.Sanphams.Where(n => n.Mahang == 1).Take(4).ToList();
            return PartialView(ss);
        }
        public ActionResult dtxiaomipartial()
        {
            var mi = db.Sanphams.Where(n => n.Mahang == 3).Take(4).ToList();
            return PartialView(mi);
        }
        //public ActionResult dttheohang()
        //{
        //    var mi = db.Sanphams.Where(n => n.Mahang == 5).Take(4).ToList();
        //    return PartialView(mi);
        //}
        public ActionResult xemchitiet(int Masp=0)
        {
            var chitiet = db.Sanphams.SingleOrDefault(n=>n.Masp==Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);

            //
            var sessionUser = (UserLogin)session[CommonConstants.USER_SESSION];
            ViewBag.MaNguoiDung = sessionUser;
            ViewBag.ListComment = new CommentDAO().ListCommentViewModel(0, id);
        }*/
        //
        private Qlbanhang db = new Qlbanhang();

        private Dictionary<string, SanphamPrototype> prototypes = new Dictionary<string, SanphamPrototype>();

        public SanphamController()
        {
            // Khởi tạo các prototype ở đây
            var ip = db.Sanphams.Where(n => n.Mahang == 2).Take(4).ToList();
            var ss = db.Sanphams.Where(n => n.Mahang == 1).Take(4).ToList();
            var mi = db.Sanphams.Where(n => n.Mahang == 3).Take(4).ToList();

            prototypes.Add("dtiphonepartial", new ConcreteSanphamPrototype(ip));
            prototypes.Add("dtsamsungpartial", new ConcreteSanphamPrototype(ss));
            prototypes.Add("dtxiaomipartial", new ConcreteSanphamPrototype(mi));
        }

        public ActionResult RenderPartial(string partialName)
        {
            // Sử dụng Prototype để tạo bản sao và render partial view
            if (prototypes.ContainsKey(partialName))
            {
                var clonedSanphams = prototypes[partialName].Clone();
                return PartialView(partialName, clonedSanphams);
            }

            // Nếu không tìm thấy partial name, trả về null hoặc xử lý khác tùy theo yêu cầu
            return null;
        }

        public ActionResult xemchitiet(int Masp = 0)
        {
            // Phần xem chi tiết ở đây
            var chitiet = db.Sanphams.SingleOrDefault(n => n.Masp == Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }
        //tim kiem san pham 
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Search(string searchString)
        {
            var sanphams = db.Sanphams.Include(s => s.LoaiSP);

            if (!string.IsNullOrEmpty(searchString))
            {
                sanphams = sanphams.Where(s => s.TenSP.Contains(searchString) || s.MoTa.Contains(searchString));
            }

            return View(sanphams.ToList());
        }
    }
}