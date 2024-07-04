using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ictshop.ViewModel.BaiViet
{
    public class BaiVietCreate
    {
        [Required(ErrorMessage = "Bạn chưa nhập tên bài viết")]
        public string TenBaiViet { get; set; }

        public string AnhChinh { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Bạn chưa nhập nội dung")]
        public string NoiDung { get; set; }

        public int MaTaiKhoan { get; set; }

        [Required(ErrorMessage = "Bạn chưa cập nhật trạng thái")]
        public bool TrangThai { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}
