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
    
    public partial class CTPHIEUTRAHANG
    {
        public string MaHangTra { get; set; }
        public string SoPhieuTra { get; set; }
        public Nullable<int> SoLuongTra { get; set; }
        public Nullable<int> ThanhTien { get; set; }
        public string Lydotrahang { get; set; }
    
        public virtual HANGHOA HANGHOA { get; set; }
        public virtual PHIEUTRAHANG PHIEUTRAHANG { get; set; }
    }
}
