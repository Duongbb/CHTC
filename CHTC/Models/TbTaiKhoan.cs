using System;
using System.Collections.Generic;

namespace CHTC.Models;

public partial class TbTaiKhoan
{
    public int Id { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public bool? Quyen { get; set; }
    

    public virtual ICollection<TbKhacHang> TbKhacHangs { get; set; } = new List<TbKhacHang>();

    public virtual ICollection<TbNhanVien> TbNhanViens { get; set; } = new List<TbNhanVien>();
}
