using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.Design_Pattern.Builder
{
    public class SanphamBuilder : ISanphamBuilder
    {
        private Sanpham _sanpham = new Sanpham();

        public ISanphamBuilder SetTensp(string tensp)
        {
            _sanpham.Tensp = tensp;
            return this;
        }

        public ISanphamBuilder SetGiatien(decimal giatien)
        {
            _sanpham.Giatien = giatien;
            return this;
        }

        public ISanphamBuilder SetSoluong(int soluong)
        {
            _sanpham.Soluong = soluong;
            return this;
        }

        public ISanphamBuilder SetMota(string mota)
        {
            _sanpham.Mota = mota;
            return this;
        }

        public ISanphamBuilder SetAnhbia(string anhbia)
        {
            _sanpham.Anhbia = anhbia;
            return this;
        }

        public ISanphamBuilder SetBonhotrong(int bonhotrong)
        {
            _sanpham.Bonhotrong = bonhotrong;
            return this;
        }

        public ISanphamBuilder SetRam(int ram)
        {
            _sanpham.Ram = ram;
            return this;
        }

        public ISanphamBuilder SetThesim(bool thesim)
        {
            _sanpham.Thesim = thesim;
            return this;
        }

        public ISanphamBuilder SetMahang(string mahang)
        {
            _sanpham.Mahang = mahang;
            return this;
        }

        public ISanphamBuilder SetMahdh(string mahdh)
        {
            _sanpham.Mahdh = mahdh;
            return this;
        }

        public Sanpham Build()
        {
            return _sanpham;
        }
    }
}
