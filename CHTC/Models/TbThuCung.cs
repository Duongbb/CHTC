using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CHTC.Models;

public partial class TbThuCung
{
    public int ID { get; set; }

    public string? MaThuCung { get; set; }

    public string? Ten { get; set; }

    public int? Tuoi { get; set; }

    public bool? GioiTinh { get; set; }

    public string? Giong { get; set; }

    public string? MoTa { get; set; }

    public string? AnhTc { get; set; }

    public int? IDloaiHang { get; set; }

    public bool? TinhTrang { get; set; }

    public double? Gia { get; set; }

    public bool? TrangThai { get; set; }

    public virtual TbLoaiHang? loaihangID { get; set; }

    public virtual ICollection<TbChiTietDh> TbChiTietDhs { get; set; } = new List<TbChiTietDh>();

    [NotMapped]
    [DisplayName("Upload file")]

    public IFormFile Imagefile { get; set; }
}
