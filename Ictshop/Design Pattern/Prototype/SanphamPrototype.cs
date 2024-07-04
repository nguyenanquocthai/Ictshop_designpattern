using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.Design_Pattern.Prototype
{
    public abstract class SanphamPrototype
    {
        public abstract List<Sanpham> Clone();
    }
}
