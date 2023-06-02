using System;
using System.Collections.Generic;

namespace CHTC.Models;

public partial class TbDonNhapHang
{
    public int Id { get; set; }

    public int? Idnv { get; set; }

    public DateTime? NgayNhap { get; set; }

    public int? Idncc { get; set; }

    public virtual TbNhaCc? IdnccNavigation { get; set; }

    public virtual TbNhanVien? IdnvNavigation { get; set; }

    public virtual ICollection<TbChiTietDn> TbChiTietDns { get; set; } = new List<TbChiTietDn>();
}
