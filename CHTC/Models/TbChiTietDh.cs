using System;
using System.Collections.Generic;

namespace CHTC.Models;

public partial class TbChiTietDh
{
    public int ID { get; set; }

    public int? IDdonHang { get; set; }

    public int? IDsanPham { get; set; }

    public int? IDthuCung { get; set; }

    public int? IDtiemChung { get;set; } 

    public int? SoLuong { get; set; }

    public double? Gia { get; set; }

    public virtual TbDonDatHang? IDdonHangNavigation { get; set; }

    public virtual TbSanPham? IDsanPhamNavigation { get; set; }

    public virtual TbTiemChung? IDtiemchungNavigation { get; set; }

    public virtual TbThuCung? IDthuCungNavigation { get; set; }
}
