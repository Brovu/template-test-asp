//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Template_Test.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SinhVien
    {
        public string maSV { get; set; }
        public string hoSV { get; set; }
        public string tenSV { get; set; }
        public Nullable<System.DateTime> ngaySinh { get; set; }
        public string gioiTinh { get; set; }
        public string anhSV { get; set; }
        public string diaChi { get; set; }
        public string maLop { get; set; }
        public Nullable<int> age { get; set; }
    
        public virtual Lop Lop { get; set; }
    }
}
