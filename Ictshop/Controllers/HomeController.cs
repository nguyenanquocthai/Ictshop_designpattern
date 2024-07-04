using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ictshop.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index(string SearchString="")
        {
            //if (SearchString != "")
            //{
            //    var sanPhams = db.SanPhams.Include(s => s.LoaiSP).Where(x => x.TenSP.ToUpper().Contains(SearchString.ToUpper()));
            //    return View(sanPhams.ToList());
            //}
            //return View();

            IQueryable<SanPham> sanPhams = db.SanPhams.Include(s => s.LoaiSP);

            if (!string.IsNullOrEmpty(SearchString))
            {
                sanPhams = sanPhams.Where(x => x.TenSP.ToUpper().Contains(SearchString.ToUpper()));
            }

            var sanPhamList = sanPhams.ToList();

            if (sanPhamList.Count == 0)
            {
                ViewBag.Message = "Không tìm thấy sản phẩm nào phù hợp.";
            }

            return View(sanPhamList);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SlidePartial()
        {
            return PartialView();

        }

    }
}