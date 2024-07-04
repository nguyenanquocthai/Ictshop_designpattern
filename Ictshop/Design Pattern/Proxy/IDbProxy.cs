using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.Design_Pattern.Proxy
{
    // Tạo interface cho proxy
    public interface IDbProxy
    {
        void AddUser(Nguoidung nguoidung);
        void SaveChanges();
    }
}
