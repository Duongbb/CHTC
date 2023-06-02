using System;
using System.Collections.Generic;

namespace CHTC.Models;

public partial class TbNhanVien
{
    public int ID { get; set; }

    public int? IDtaiKhoan { get; set; }

    public string? MaNhanVien { get; set; }

    public string? TenNhanVien { get; set; }

    public string? DiaChi { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public virtual TbTaiKhoan? IdtaiKhoanNavigation { get; set; }

    public virtual ICollection<TbDonDatHang> TbDonDatHangs { get; set; } = new List<TbDonDatHang>();

    public virtual ICollection<TbDonNhapHang> TbDonNhapHangs { get; set; } = new List<TbDonNhapHang>();
}
