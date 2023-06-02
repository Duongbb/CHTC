using System;
using System.Collections.Generic;

namespace CHTC.Models;

public partial class TbChiTietDn
{
    public int Id { get; set; }

    public int? IddonNhap { get; set; }

    public int? SoLuong { get; set; }

    public double? Gia { get; set; }

    public int? IdloaiHang { get; set; }

    public virtual TbDonNhapHang? IddonNhapNavigation { get; set; }

    public virtual TbLoaiHang? IdloaiHangNavigation { get; set; }
}
