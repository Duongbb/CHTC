using System;
using System.Collections.Generic;

namespace CHTC.Models;

public partial class TbKhacHang
{
    public int ID { get; set; }

    public int? IDtaiKhoan { get; set; }

    public string? HoVaTen { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public virtual TbTaiKhoan? IdtaiKhoanNavigation { get; set; }
}
