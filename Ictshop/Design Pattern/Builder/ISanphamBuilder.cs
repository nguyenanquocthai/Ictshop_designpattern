using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.Design_Pattern.Builder
{
    public interface ISanphamBuilder
    {
        ISanphamBuilder SetTensp(string tensp);
        ISanphamBuilder SetGiatien(decimal giatien);
        ISanphamBuilder SetSoluong(int soluong);
        ISanphamBuilder SetMota(string mota);
        ISanphamBuilder SetAnhbia(string anhbia);
        ISanphamBuilder SetBonhotrong(int bonhotrong);
        ISanphamBuilder SetRam(int ram);
        ISanphamBuilder SetThesim(bool thesim);
        ISanphamBuilder SetMahang(string mahang);
        ISanphamBuilder SetMahdh(string mahdh);
        Sanpham Build();
    }
}
