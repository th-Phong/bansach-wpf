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
    
    public partial class CT_HOADON
    {
        public string SoHD { get; set; }
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
    
        public virtual SACH SACH { get; set; }
        public virtual HOADON HOADON { get; set; }
    }
}
