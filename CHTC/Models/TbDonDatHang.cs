using System;
using System.Collections.Generic;

namespace CHTC.Models;

public partial class TbDonDatHang
{
    public int ID { get; set; }

    public int? IDnv { get; set; }

    public string? MaDonHang { get; set; }  

    public DateTime? NgayDatHang { get; set; }

    public int? IDkhachHang { get; set; }

    public virtual TbNhanVien? IDnvNavigation { get; set; }

    public virtual ICollection<TbChiTietDh> TbChiTietDhs { get; set; } = new List<TbChiTietDh>();
}
