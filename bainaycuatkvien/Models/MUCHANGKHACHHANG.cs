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
    
    public partial class MUCHANGKHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MUCHANGKHACHHANG()
        {
            this.KHACHHANGs = new HashSet<KHACHHANG>();
        }
    
        public string MaMucHang { get; set; }
        public string TenMucHang { get; set; }
        public string ChietKhauTheoHang { get; set; }
        public Nullable<int> DiemYeuCau { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHACHHANG> KHACHHANGs { get; set; }
    }
}
