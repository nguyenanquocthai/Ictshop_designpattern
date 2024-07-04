using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.Design_Pattern.Proxy
{
    // Lớp proxy thực thi interface IDbProxy
    public class DbProxy : IDbProxy
    {
        private Qlbanhang db;

        public DbProxy()
        {
            // Khởi tạo đối tượng cơ sở dữ liệu
            db = new Qlbanhang();
        }

        public void AddUser(Nguoidung nguoidung)
        {
            // Thêm người dùng mới vào cơ sở dữ liệu
            db.Nguoidungs.Add(nguoidung);
        }

        public void SaveChanges()
        {
            // Lưu thay đổi vào cơ sở dữ liệu
            db.SaveChanges();
        }
    }
}
