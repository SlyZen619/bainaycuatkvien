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
    
    public partial class CHAMCONG
    {
        public string MaChamCong { get; set; }
        public string MaNV { get; set; }
        public Nullable<int> Nam { get; set; }
        public Nullable<int> Thang { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}