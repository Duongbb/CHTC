using System;
using System.Collections.Generic;

namespace CHTC.Models;

public partial class TbTiemChung
{
    public int ID { get; set; }

    public string? MaTiemChung { get; set; }

    public string? Ten { get; set; }

    public string? MoTa { get; set; }

    public int? IDloaiHang { get; set; }

    public double? Gia { get; set; }

    public virtual ICollection<TbChiTietDh> TbChiTietDhs { get; set; } = new List<TbChiTietDh>();
}
