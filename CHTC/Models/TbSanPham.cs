using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CHTC.Models;

public partial class TbSanPham
{
    public int ID { get; set; }

    public string? MaSanPham { get; set; }

    public string? TenSanPham { get; set; }

    public string? MoTa { get; set; }

    public string? AnhSp { get; set; }

    public int? IDloaiHang { get; set; }

    public bool? TinhTrang { get; set; }

    public double? Gia { get; set; }

    public virtual TbLoaiHang? loaihangID { get; set; }

    public virtual ICollection<TbChiTietDh> TbChiTietDhs { get; set; } = new List<TbChiTietDh>();

    [NotMapped]
    [DisplayName("Upload file")]

    public IFormFile Imagefile { get; set; }
}
