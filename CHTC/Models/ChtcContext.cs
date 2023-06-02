using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CHTC.Models;

public partial class ChtcContext : DbContext
{
    public ChtcContext()
    {
    }

    public ChtcContext(DbContextOptions<ChtcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbChiTietDh> TbChiTietDhs { get; set; }

    public virtual DbSet<TbChiTietDn> TbChiTietDns { get; set; }

    public virtual DbSet<TbDonDatHang> TbDonDatHangs { get; set; }

    public virtual DbSet<TbDonNhapHang> TbDonNhapHangs { get; set; }

    public virtual DbSet<TbKhacHang> TbKhacHangs { get; set; }

    public virtual DbSet<TbLoaiHang> TbLoaiHangs { get; set; }

    public virtual DbSet<TbNhaCc> TbNhaCcs { get; set; }

    public virtual DbSet<TbNhanVien> TbNhanViens { get; set; }

    public virtual DbSet<TbSanPham> TbSanPhams { get; set; }

    public virtual DbSet<TbTaiKhoan> TbTaiKhoans { get; set; }

    public virtual DbSet<TbThuCung> TbThuCungs { get; set; }

    public virtual DbSet<TbTiemChung> TbTiemChungs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-S8HJG16\\DUNO;Database=CHTC;Integrated Security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbChiTietDh>(entity =>
        {
            entity.ToTable("tbChiTietDh");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.IDdonHang).HasColumnName("IDDonHang");
            entity.Property(e => e.IDsanPham).HasColumnName("IDSanPham");
            entity.Property(e => e.IDthuCung).HasColumnName("IDThuCung");
            entity.Property(e => e.IDtiemChung).HasColumnName("IDTiemChung");

            entity.HasOne(d => d.IDdonHangNavigation).WithMany(p => p.TbChiTietDhs)
                .HasForeignKey(d => d.IDdonHang)
                .HasConstraintName("FK_tbChiTietDh_tbDonDatHang");

            entity.HasOne(d => d.IDsanPhamNavigation).WithMany(p => p.TbChiTietDhs)
                .HasForeignKey(d => d.IDsanPham)
                .HasConstraintName("FK_tbChiTietDh_tbSanPham");

            entity.HasOne(d => d.IDthuCungNavigation).WithMany(p => p.TbChiTietDhs)
                .HasForeignKey(d => d.IDthuCung)
                .HasConstraintName("FK_tbChiTietDh_tbThuCung");

            entity.HasOne(d => d.IDtiemchungNavigation).WithMany(p => p.TbChiTietDhs)
                .HasForeignKey(d => d.IDtiemChung)
                .HasConstraintName("FK_tbChiTietDh_tbTiemChung");
        });

        modelBuilder.Entity<TbChiTietDn>(entity =>
        {
            entity.ToTable("tbChiTietDN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IddonNhap).HasColumnName("IDDonNhap");
            entity.Property(e => e.IdloaiHang).HasColumnName("IDLoaiHang");

            entity.HasOne(d => d.IddonNhapNavigation).WithMany(p => p.TbChiTietDns)
                .HasForeignKey(d => d.IddonNhap)
                .HasConstraintName("FK_tbChiTietDN_tbDonNhapHang");

            entity.HasOne(d => d.IdloaiHangNavigation).WithMany(p => p.TbChiTietDns)
                .HasForeignKey(d => d.IdloaiHang)
                .HasConstraintName("FK_tbChiTietDN_tbLoaiHang");
        });

        modelBuilder.Entity<TbDonDatHang>(entity =>
        {
            entity.ToTable("tbDonDatHang");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.IDkhachHang).HasColumnName("IDKhachHang");
            entity.Property(e => e.IDnv).HasColumnName("IDNV");
            entity.Property(e => e.MaDonHang).HasMaxLength(20);
            entity.Property(e => e.NgayDatHang).HasColumnType("date");

            entity.HasOne(d => d.IDnvNavigation).WithMany(p => p.TbDonDatHangs)
                .HasForeignKey(d => d.IDnv)
                .HasConstraintName("FK_tbDonDatHang_tbNhanVien");
        });

        modelBuilder.Entity<TbDonNhapHang>(entity =>
        {
            entity.ToTable("tbDonNhapHang");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idncc).HasColumnName("IDNCC");
            entity.Property(e => e.Idnv).HasColumnName("IDNV");
            entity.Property(e => e.NgayNhap).HasColumnType("date");

            entity.HasOne(d => d.IdnccNavigation).WithMany(p => p.TbDonNhapHangs)
                .HasForeignKey(d => d.Idncc)
                .HasConstraintName("FK_tbDonNhapHang_tbNhaCC");

            entity.HasOne(d => d.IdnvNavigation).WithMany(p => p.TbDonNhapHangs)
                .HasForeignKey(d => d.Idnv)
                .HasConstraintName("FK_tbDonNhapHang_tbNhanVien");
        });

        modelBuilder.Entity<TbKhacHang>(entity =>
        {
            entity.ToTable("tbKhacHang");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(300);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.HoVaTen).HasMaxLength(50);
            entity.Property(e => e.IDtaiKhoan).HasColumnName("IDTaiKhoan");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .HasColumnName("SDT");

            entity.HasOne(d => d.IdtaiKhoanNavigation).WithMany(p => p.TbKhacHangs)
                .HasForeignKey(d => d.IDtaiKhoan)
                .HasConstraintName("FK_tbKhacHang_tbTaiKhoan");
        });

        modelBuilder.Entity<TbLoaiHang>(entity =>
        {
            entity.ToTable("tbLoaiHang");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.MaLh)
                .HasMaxLength(10)
                .HasColumnName("MaLH");
            entity.Property(e => e.TenLh)
                .HasMaxLength(20)
                .HasColumnName("TenLH");
        });

        modelBuilder.Entity<TbNhaCc>(entity =>
        {
            entity.ToTable("tbNhaCC");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.MaNhaCc).HasMaxLength(10);
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNhaCc).HasMaxLength(20);
        });

        modelBuilder.Entity<TbNhanVien>(entity =>
        {
            entity.ToTable("tbNhanVien");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.IDtaiKhoan).HasColumnName("IDTaiKhoan");
            entity.Property(e => e.MaNhanVien).HasMaxLength(10);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNhanVien).HasMaxLength(50);

            entity.HasOne(d => d.IdtaiKhoanNavigation).WithMany(p => p.TbNhanViens)
                .HasForeignKey(d => d.IDtaiKhoan)
                .HasConstraintName("FK_tbNhanVien_tbTaiKhoan");
        });

        modelBuilder.Entity<TbSanPham>(entity =>
        {
            entity.ToTable("tbSanPham");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.AnhSp).HasColumnName("AnhSp");
            entity.Property(e => e.MaSanPham).HasMaxLength(10);
            entity.Property(e => e.MoTa).HasMaxLength(150); 
            entity.Property(e => e.TenSanPham).HasMaxLength(20);
            entity.HasOne(d => d.loaihangID).WithMany(p => p.TbSanPhams)
                .HasForeignKey(d => d.IDloaiHang)
                .HasConstraintName("FK_tbSanPham_tbLoaiHang");
        });

        modelBuilder.Entity<TbTaiKhoan>(entity =>
        {
            entity.ToTable("tbTaiKhoan");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Quyen).HasColumnName("Quyen");
            entity.Property(e => e.TaiKhoan).HasMaxLength(30);
        });

        modelBuilder.Entity<TbThuCung>(entity =>
        {
            entity.ToTable("tbThuCung");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.AnhTc).HasColumnName("AnhTC");
            entity.Property(e => e.Giong).HasMaxLength(20);
            entity.Property(e => e.MaThuCung).HasMaxLength(10);
            entity.Property(e => e.MoTa).HasMaxLength(150);
            entity.Property(e => e.Ten).HasMaxLength(20);
            entity.Property(e => e.TinhTrang).HasColumnName("TInhTrang");
            entity.HasOne(d => d.loaihangID).WithMany(p => p.TbThuCungs)
                .HasForeignKey(d => d.IDloaiHang)
                .HasConstraintName("FK_tbThuCung_tbLoaiHang");
        });

        modelBuilder.Entity<TbTiemChung>(entity =>
        {
            entity.ToTable("tbTiemChung");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.IDloaiHang).HasColumnName("IDLoaiHang");
            entity.Property(e => e.MaTiemChung).HasMaxLength(10);
            entity.Property(e => e.MoTa).HasMaxLength(150);
            entity.Property(e => e.Ten).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
