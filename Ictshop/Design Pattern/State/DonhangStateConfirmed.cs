using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.Design_Pattern.State
{
    public class DonhangStateConfirmed : IDonhangState
    {
        public void Process(Donhang donhang)
        {
            // Xử lý khi đơn hàng đã được xác nhận
            donhang.Tinhtrang = 2; // Đã xác nhận
        }
    }
}
