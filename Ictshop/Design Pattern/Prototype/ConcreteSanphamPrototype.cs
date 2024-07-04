using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.Design_Pattern.Prototype
{
    public class ConcreteSanphamPrototype : SanphamPrototype
    {
        private List<Sanpham> sanphams;

        public ConcreteSanphamPrototype(List<Sanpham> list)
        {
            sanphams = list;
        }

        public override List<Sanpham> Clone()
        {
            return sanphams.Select(sp => new Sanpham { Masp = sp.Masp, TenSp = sp.TenSp, Mahang = sp.Mahang }).ToList();
        }
    }
}
