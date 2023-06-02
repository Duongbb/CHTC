using System;
using System.Collections.Generic;

namespace CHTC.Models;

public partial class TbLoaiHang
{
    public int ID { get; set; }

    public string? MaLh { get; set; }

    public string? TenLh { get; set; }

    public virtual ICollection<TbThuCung> TbThuCungs { get; set; } = new List<TbThuCung>();
    public virtual ICollection<TbSanPham> TbSanPhams { get; set; } = new List<TbSanPham>();
    public virtual ICollection<TbChiTietDn> TbChiTietDns { get; set; } = new List<TbChiTietDn>();

}