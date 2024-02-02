using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace btl1.Models;

public partial class QlbanKhanContext : DbContext
{
	public QlbanKhanContext()
	{
	}

	public QlbanKhanContext(DbContextOptions<QlbanKhanContext> options)
		: base(options)
	{
	}
	public virtual DbSet<AnhSp> AnhSps { get; set; }

	public virtual DbSet<ChatLieu> ChatLieus { get; set; }

	public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }

	public virtual DbSet<Donhang> Donhangs { get; set; }

	public virtual DbSet<Hangsanxuat> Hangsanxuats { get; set; }

	public virtual DbSet<Nguoidung> Nguoidungs { get; set; }

	public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

	public virtual DbSet<Sanpham> Sanphams { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseSqlServer("Data Source=GANYUWU;Initial Catalog=QLBanKhan;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ChatLieu>(entity =>
		{
			entity.HasKey(e => e.MaCl);

			entity.ToTable("ChatLieu");

			entity.Property(e => e.MaCl).HasColumnName("MaCL");
			entity.Property(e => e.TenCl)
				.HasMaxLength(10)
				.IsFixedLength()
				.HasColumnName("TenCL");
		});

		modelBuilder.Entity<Chitietdonhang>(entity =>
		{
			entity.HasKey(e => new { e.Madon, e.Masp });

			entity.ToTable("Chitietdonhang");

			entity.Property(e => e.Dongia).HasColumnType("decimal(18, 0)");
			entity.Property(e => e.Thanhtien).HasColumnType("decimal(18, 0)");

			entity.HasOne(d => d.MadonNavigation).WithMany(p => p.Chitietdonhangs)
				.HasForeignKey(d => d.Madon)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Chitietdonhang_Donhang");

			entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Chitietdonhangs)
				.HasForeignKey(d => d.Masp)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Chitietdonhang_Sanpham");
		});

		modelBuilder.Entity<Donhang>(entity =>
		{
			entity.HasKey(e => e.Madon);

			entity.ToTable("Donhang");

			entity.Property(e => e.Ngaydat).HasColumnType("datetime");

			entity.HasOne(d => d.MaNguoidungNavigation).WithMany(p => p.Donhangs)
				.HasForeignKey(d => d.MaNguoidung)
				.HasConstraintName("FK_Donhang_Khachhang");
		});

		modelBuilder.Entity<Hangsanxuat>(entity =>
		{
			entity.HasKey(e => e.Mahang);

			entity.ToTable("Hangsanxuat");

			entity.Property(e => e.Tenhang)
				.HasMaxLength(20)
				.IsFixedLength();
		});

		modelBuilder.Entity<Nguoidung>(entity =>
		{
			entity.HasKey(e => e.MaNguoiDung).HasName("PK_Khachhang");

			entity.ToTable("Nguoidung");

			entity.Property(e => e.Diachi).HasMaxLength(100);
			entity.Property(e => e.Dienthoai)
				.HasMaxLength(10)
				.IsFixedLength();
			entity.Property(e => e.Email).HasMaxLength(50);
			entity.Property(e => e.Hoten).HasMaxLength(50);
			entity.Property(e => e.Idquyen)
				.HasDefaultValueSql("((0))")
				.HasColumnName("IDQuyen");
			entity.Property(e => e.Matkhau)
				.HasMaxLength(50)
				.IsUnicode(false);

			entity.HasOne(d => d.IdquyenNavigation).WithMany(p => p.Nguoidungs)
				.HasForeignKey(d => d.Idquyen)
				.HasConstraintName("FK_Nguoidung_Nguoidung");
		});

		modelBuilder.Entity<PhanQuyen>(entity =>
		{
			entity.HasKey(e => e.Idquyen);

			entity.ToTable("PhanQuyen");

			entity.Property(e => e.Idquyen).HasColumnName("IDQuyen");
			entity.Property(e => e.TenQuyen).HasMaxLength(20);
		});
		modelBuilder.Entity<AnhSp>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("AnhSP");

			entity.Property(e => e.Fileanh)
				.HasMaxLength(30)
				.IsFixedLength()
				.HasColumnName("fileanh");
		});

		modelBuilder.Entity<Sanpham>(entity =>
		{
			entity.HasKey(e => e.Masp);

			entity.ToTable("Sanpham");

			entity.Property(e => e.Anhbia).HasMaxLength(10);
			entity.Property(e => e.Giatien).HasColumnType("decimal(18, 0)");
			entity.Property(e => e.MaCl).HasColumnName("MaCL");
			entity.Property(e => e.Mota).HasColumnType("ntext");
			entity.Property(e => e.Tensp).HasMaxLength(50);

			entity.HasOne(d => d.MaClNavigation).WithMany(p => p.Sanphams)
				.HasForeignKey(d => d.MaCl)
				.HasConstraintName("FK_Sanpham_ChatLieu");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
