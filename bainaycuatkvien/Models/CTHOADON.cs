//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bainaycuatkvien.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTHOADON
    {
        public string SoHD { get; set; }
        public string MaHH { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> DonGia { get; set; }
        public Nullable<int> ThanhTien { get; set; }
        public Nullable<int> VAT { get; set; }
        public string MaKM { get; set; }
    
        public virtual HANGHOA HANGHOA { get; set; }
        public virtual HOADON HOADON { get; set; }
        public virtual KHUYENMAI KHUYENMAI { get; set; }
    }
}
