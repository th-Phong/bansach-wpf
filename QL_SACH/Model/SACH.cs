//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_SACH.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            this.CT_HOADON = new HashSet<CT_HOADON>();
            this.CHITIETPHIEUNHAP = new HashSet<CHITIETPHIEUNHAP>();
        }
    
        public string MaSach { get; set; }
        public string MaTacGia { get; set; }
        public string MaTheLoai { get; set; }
        public string MaNhaXuatBan { get; set; }
        public string MaKM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOADON> CT_HOADON { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAP { get; set; }
        public virtual CHITIETSACH CHITIETSACH { get; set; }
        public virtual KHUYENMAI KHUYENMAI { get; set; }
        public virtual NHAXUATBAN NHAXUATBAN { get; set; }
        public virtual TACGIA TACGIA { get; set; }
        public virtual THELOAI THELOAI { get; set; }
    }
}
