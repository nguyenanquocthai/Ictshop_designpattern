using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.Design_Pattern.State
{
    public class DonhangStatePending : IDonhangState
    {
        public void Process(Donhang donhang)
        {
            // Xử lý khi đơn hàng đang chờ xử lý
            donhang.Tinhtrang = 1; // Đã xác nhận
        }
    }
}
