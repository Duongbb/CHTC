using System;
using System.Collections.Generic;

namespace CHTC.Models;

public partial class TbNhaCc
{
    public int ID { get; set; }

    public string? MaNhaCc { get; set; }

    public string? TenNhaCc { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<TbDonNhapHang> TbDonNhapHangs { get; set; } = new List<TbDonNhapHang>();
}
