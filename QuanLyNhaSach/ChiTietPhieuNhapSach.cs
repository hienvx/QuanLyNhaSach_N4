//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyNhaSach
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietPhieuNhapSach
    {
        public string MaChiTietPhieuNhapSach { get; set; }
        public string MaPhieuNhapSach { get; set; }
        public string MaSach { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> GiaNhap { get; set; }
    
        public virtual PhieuNhapSach PhieuNhapSach { get; set; }
        public virtual Sach Sach { get; set; }
    }
}
