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
    
    public partial class ChiTietHoaDon
    {
        public string MaChiTietHoaDon { get; set; }
        public string MaHoaDon { get; set; }
        public string MaSach { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> GiaBan { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual Sach Sach { get; set; }
    }
}
