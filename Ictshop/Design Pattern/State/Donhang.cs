using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.Design_Pattern.State
{
    public class Donhang
    {
        // Các trạng thái có thể
        public IDonhangState State { get; set; }

        public void ProcessState()
        {
            State.Process(this);
        }
    }
}
