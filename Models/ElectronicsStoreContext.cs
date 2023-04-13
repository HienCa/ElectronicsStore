using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class ElectronicsStoreContext : DbContext
    {
        public ElectronicsStoreContext()
        {
        }

        public ElectronicsStoreContext(DbContextOptions<ElectronicsStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ctnganhangkh> Ctnganhangkh { get; set; }
        public virtual DbSet<Ctnganhangncc> Ctnganhangncc { get; set; }
        public virtual DbSet<Dondathang> Dondathang { get; set; }
        public virtual DbSet<Hanghoa> Hanghoa { get; set; }
        public virtual DbSet<Hinhthucthanhtoan> Hinhthucthanhtoan { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Nganhang> Nganhang { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcap { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Nhomhh> Nhomhh { get; set; }
        public virtual DbSet<Noidungddh> Noidungddh { get; set; }
        public virtual DbSet<Noidungpnk> Noidungpnk { get; set; }
        public virtual DbSet<Noidungthunoddh> Noidungthunoddh { get; set; }
        public virtual DbSet<Noidungtranoncc> Noidungtranoncc { get; set; }
        public virtual DbSet<Nuosx> Nuosx { get; set; }
        public virtual DbSet<Phieunhapkho> Phieunhapkho { get; set; }
        public virtual DbSet<Phieuthunokh> Phieuthunokh { get; set; }
        public virtual DbSet<Phieutranoncc> Phieutranoncc { get; set; }
        public virtual DbSet<Thuonghieu> Thuonghieu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ElectronicsStore;Persist Security Info=True;User ID=sa;Password=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ctnganhangkh>(entity =>
            {
                entity.HasKey(e => new { e.Idctnhkh, e.Idkh, e.Idnh })
                    .HasName("PK__CTNGANHA__D882C9193054B28D");

                entity.ToTable("CTNGANHANGKH");

                entity.Property(e => e.Idctnhkh)
                    .HasColumnName("IDCTNHKH")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idkh).HasColumnName("IDKH");

                entity.Property(e => e.Idnh).HasColumnName("IDNH");

                entity.Property(e => e.Stk).HasColumnName("STK");

                entity.HasOne(d => d.IdkhNavigation)
                    .WithMany(p => p.Ctnganhangkh)
                    .HasForeignKey(d => d.Idkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCTNGANHANG63746");

                entity.HasOne(d => d.IdnhNavigation)
                    .WithMany(p => p.Ctnganhangkh)
                    .HasForeignKey(d => d.Idnh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCTNGANHANG333690");
            });

            modelBuilder.Entity<Ctnganhangncc>(entity =>
            {
                entity.HasKey(e => new { e.Idctnhncc, e.Idnh, e.Idncc })
                    .HasName("PK__CTNGANHA__A94E2341ACED9441");

                entity.ToTable("CTNGANHANGNCC");

                entity.Property(e => e.Idctnhncc)
                    .HasColumnName("IDCTNHNCC")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idnh).HasColumnName("IDNH");

                entity.Property(e => e.Idncc).HasColumnName("IDNCC");

                entity.Property(e => e.Stk).HasColumnName("STK");

                entity.HasOne(d => d.IdnccNavigation)
                    .WithMany(p => p.Ctnganhangncc)
                    .HasForeignKey(d => d.Idncc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCTNGANHANG648720");

                entity.HasOne(d => d.IdnhNavigation)
                    .WithMany(p => p.Ctnganhangncc)
                    .HasForeignKey(d => d.Idnh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCTNGANHANG844559");
            });

            modelBuilder.Entity<Dondathang>(entity =>
            {
                entity.HasKey(e => e.Iddh)
                    .HasName("PK__DONDATHA__B87DB8980419B6CC");

                entity.ToTable("DONDATHANG");

                entity.Property(e => e.Iddh).HasColumnName("IDDH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Idkh).HasColumnName("IDKH");

                entity.Property(e => e.Madh)
                    .HasColumnName("MADH")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaydat)
                    .HasColumnName("NGAYDAT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ngaygiao)
                    .HasColumnName("NGAYGIAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Trangthai).HasColumnName("TRANGTHAI");

                entity.HasOne(d => d.IdkhNavigation)
                    .WithMany(p => p.Dondathang)
                    .HasForeignKey(d => d.Idkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDONDATHANG344447");
            });

            modelBuilder.Entity<Hanghoa>(entity =>
            {
                entity.HasKey(e => e.Idhh)
                    .HasName("PK__HANGHOA__B87C1A03ABD5E68F");

                entity.ToTable("HANGHOA");

                entity.Property(e => e.Idhh).HasColumnName("IDHH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Donvitinh)
                    .IsRequired()
                    .HasColumnName("DONVITINH")
                    .HasMaxLength(255);

                entity.Property(e => e.Giaban).HasColumnName("GIABAN");

                entity.Property(e => e.Giakm).HasColumnName("GIAKM");

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("HINHANH")
                    .HasMaxLength(255);

                entity.Property(e => e.Idnhh).HasColumnName("IDNHH");

                entity.Property(e => e.Idnsx).HasColumnName("IDNSX");

                entity.Property(e => e.Idth).HasColumnName("IDTH");

                entity.Property(e => e.Mausac)
                    .HasColumnName("MAUSAC")
                    .HasMaxLength(255);

                entity.Property(e => e.Mavl)
                    .HasColumnName("MAVL")
                    .HasMaxLength(255);

                entity.Property(e => e.Mota)
                    .IsRequired()
                    .HasColumnName("MOTA")
                    .HasMaxLength(4000);

                entity.Property(e => e.Tenvl)
                    .IsRequired()
                    .HasColumnName("TENVL")
                    .HasMaxLength(255);

                entity.Property(e => e.Thoigianbh).HasColumnName("THOIGIANBH");

                entity.Property(e => e.Tinhtrang).HasColumnName("TINHTRANG");

                entity.HasOne(d => d.IdnhhNavigation)
                    .WithMany(p => p.Hanghoa)
                    .HasForeignKey(d => d.Idnhh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKHANGHOA58581");

                entity.HasOne(d => d.IdnsxNavigation)
                    .WithMany(p => p.Hanghoa)
                    .HasForeignKey(d => d.Idnsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKHANGHOA559869");

                entity.HasOne(d => d.IdthNavigation)
                    .WithMany(p => p.Hanghoa)
                    .HasForeignKey(d => d.Idth)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKHANGHOA381251");
            });

            modelBuilder.Entity<Hinhthucthanhtoan>(entity =>
            {
                entity.HasKey(e => e.Idhttt)
                    .HasName("PK__HINHTHUC__9DCEA6E30D2B3A59");

                entity.ToTable("HINHTHUCTHANHTOAN");

                entity.Property(e => e.Idhttt).HasColumnName("IDHTTT");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mahttt)
                    .HasColumnName("MAHTTT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenhttt)
                    .IsRequired()
                    .HasColumnName("TENHTTT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Idkh)
                    .HasName("PK__KHACHHAN__B87DC1A74848C92D");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Idkh).HasColumnName("IDKH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cccd)
                    .HasColumnName("CCCD")
                    .HasMaxLength(255);

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasColumnName("DIACHI")
                    .HasMaxLength(4000);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Facebook)
                    .HasColumnName("FACEBOOK")
                    .HasMaxLength(255);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Gioitinh)
                    .IsRequired()
                    .HasColumnName("GIOITINH")
                    .HasMaxLength(255);

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("HINHANH")
                    .HasMaxLength(255);

                entity.Property(e => e.Makh)
                    .HasColumnName("MAKH")
                    .HasMaxLength(255);

                entity.Property(e => e.Masothue)
                    .HasColumnName("MASOTHUE")
                    .HasMaxLength(255);

                entity.Property(e => e.Matkhau)
                    .HasColumnName("MATKHAU")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("NGAYSINH")
                    .HasColumnType("date");

                entity.Property(e => e.Nvidsale).HasColumnName("NVIDSALE");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("SDT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenkh)
                    .IsRequired()
                    .HasColumnName("TENKH")
                    .HasMaxLength(255);

                entity.Property(e => e.Zalo)
                    .HasColumnName("ZALO")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Nganhang>(entity =>
            {
                entity.HasKey(e => e.Idnh)
                    .HasName("PK__NGANHANG__B87DC944A0551BC7");

                entity.ToTable("NGANHANG");

                entity.Property(e => e.Idnh).HasColumnName("IDNH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasColumnName("DIACHI")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Idhttt).HasColumnName("IDHTTT");

                entity.Property(e => e.Masothue)
                    .IsRequired()
                    .HasColumnName("MASOTHUE")
                    .HasMaxLength(255);

                entity.Property(e => e.Tennh)
                    .IsRequired()
                    .HasColumnName("TENNH")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdhtttNavigation)
                    .WithMany(p => p.Nganhang)
                    .HasForeignKey(d => d.Idhttt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNGANHANG536661");
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.HasKey(e => e.Idncc)
                    .HasName("PK__NHACUNGC__945E4705C06424F0");

                entity.ToTable("NHACUNGCAP");

                entity.Property(e => e.Idncc).HasColumnName("IDNCC");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasColumnName("DIACHI")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Facebook)
                    .HasColumnName("FACEBOOK")
                    .HasMaxLength(255);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Mancc)
                    .HasColumnName("MANCC")
                    .HasMaxLength(255);

                entity.Property(e => e.Masothue)
                    .IsRequired()
                    .HasColumnName("MASOTHUE")
                    .HasMaxLength(255);

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("SDT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenncc)
                    .IsRequired()
                    .HasColumnName("TENNCC")
                    .HasMaxLength(255);

                entity.Property(e => e.Zalo)
                    .HasColumnName("ZALO")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Idnv)
                    .HasName("PK__NHANVIEN__B87DC9B2588BE090");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cccd)
                    .HasColumnName("CCCD")
                    .HasMaxLength(255);

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasColumnName("DIACHI")
                    .HasMaxLength(4000);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Facebook)
                    .HasColumnName("FACEBOOK")
                    .HasMaxLength(255);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Gioitinh)
                    .IsRequired()
                    .HasColumnName("GIOITINH")
                    .HasMaxLength(255);

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("HINHANH")
                    .HasMaxLength(255);

                entity.Property(e => e.Manv)
                    .HasColumnName("MANV")
                    .HasMaxLength(255);

                entity.Property(e => e.Masothue)
                    .HasColumnName("MASOTHUE")
                    .HasMaxLength(255);

                entity.Property(e => e.Matkhau)
                    .HasColumnName("MATKHAU")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("NGAYSINH")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("SDT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tennv)
                    .IsRequired()
                    .HasColumnName("TENNV")
                    .HasMaxLength(255);

                entity.Property(e => e.Zalo)
                    .HasColumnName("ZALO")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Nhomhh>(entity =>
            {
                entity.HasKey(e => e.Idnhh)
                    .HasName("PK__NHOMHH__945F0A7D8A23E1BF");

                entity.ToTable("NHOMHH");

                entity.Property(e => e.Idnhh).HasColumnName("IDNHH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Manhh)
                    .HasColumnName("MANHH")
                    .HasMaxLength(255);

                entity.Property(e => e.Tennhh)
                    .IsRequired()
                    .HasColumnName("TENNHH")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Noidungddh>(entity =>
            {
                entity.HasKey(e => new { e.Idndddh, e.Idhh, e.Iddh })
                    .HasName("PK__NOIDUNGD__62A9AB406003CC87");

                entity.ToTable("NOIDUNGDDH");

                entity.Property(e => e.Idndddh)
                    .HasColumnName("IDNDDDH")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idhh).HasColumnName("IDHH");

                entity.Property(e => e.Iddh).HasColumnName("IDDH");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Hethanbh)
                    .HasColumnName("HETHANBH")
                    .HasColumnType("datetime");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.IddhNavigation)
                    .WithMany(p => p.Noidungddh)
                    .HasForeignKey(d => d.Iddh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGDDH501508");

                entity.HasOne(d => d.IdhhNavigation)
                    .WithMany(p => p.Noidungddh)
                    .HasForeignKey(d => d.Idhh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGDDH238686");
            });

            modelBuilder.Entity<Noidungpnk>(entity =>
            {
                entity.HasKey(e => new { e.Idndpnk, e.Idhh, e.Idpnk })
                    .HasName("PK__NOIDUNGP__5DBC27ECE1B22042");

                entity.ToTable("NOIDUNGPNK");

                entity.Property(e => e.Idndpnk)
                    .HasColumnName("IDNDPNK")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idhh).HasColumnName("IDHH");

                entity.Property(e => e.Idpnk).HasColumnName("IDPNK");

                entity.Property(e => e.Cktm).HasColumnName("CKTM");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Hansd)
                    .HasColumnName("HANSD")
                    .HasColumnType("date");

                entity.Property(e => e.Ngaysx)
                    .HasColumnName("NGAYSX")
                    .HasColumnType("date");

                entity.Property(e => e.Solo)
                    .HasColumnName("SOLO")
                    .HasMaxLength(255);

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Vat).HasColumnName("VAT");

                entity.HasOne(d => d.IdhhNavigation)
                    .WithMany(p => p.Noidungpnk)
                    .HasForeignKey(d => d.Idhh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGPNK226841");

                entity.HasOne(d => d.IdpnkNavigation)
                    .WithMany(p => p.Noidungpnk)
                    .HasForeignKey(d => d.Idpnk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGPNK363708");
            });

            modelBuilder.Entity<Noidungthunoddh>(entity =>
            {
                entity.HasKey(e => new { e.Idndtnddh, e.Idptnkh, e.Iddh })
                    .HasName("PK__NOIDUNGT__CCAC540FC4E98031");

                entity.ToTable("NOIDUNGTHUNODDH");

                entity.Property(e => e.Idndtnddh)
                    .HasColumnName("IDNDTNDDH")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idptnkh).HasColumnName("IDPTNKH");

                entity.Property(e => e.Iddh).HasColumnName("IDDH");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Ngaythuno)
                    .HasColumnName("NGAYTHUNO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sotien).HasColumnName("SOTIEN");

                entity.HasOne(d => d.IddhNavigation)
                    .WithMany(p => p.Noidungthunoddh)
                    .HasForeignKey(d => d.Iddh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTHU162083");

                entity.HasOne(d => d.IdptnkhNavigation)
                    .WithMany(p => p.Noidungthunoddh)
                    .HasForeignKey(d => d.Idptnkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTHU506148");
            });

            modelBuilder.Entity<Noidungtranoncc>(entity =>
            {
                entity.HasKey(e => new { e.Idndtnncc, e.Idptnncc, e.Idpnk })
                    .HasName("PK__NOIDUNGT__2762364915C6E049");

                entity.ToTable("NOIDUNGTRANONCC");

                entity.Property(e => e.Idndtnncc)
                    .HasColumnName("IDNDTNNCC")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idptnncc).HasColumnName("IDPTNNCC");

                entity.Property(e => e.Idpnk).HasColumnName("IDPNK");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Ngaytrano)
                    .HasColumnName("NGAYTRANO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sotien).HasColumnName("SOTIEN");

                entity.HasOne(d => d.IdpnkNavigation)
                    .WithMany(p => p.Noidungtranoncc)
                    .HasForeignKey(d => d.Idpnk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTRA430668");

                entity.HasOne(d => d.IdptnnccNavigation)
                    .WithMany(p => p.Noidungtranoncc)
                    .HasForeignKey(d => d.Idptnncc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTRA854248");
            });

            modelBuilder.Entity<Nuosx>(entity =>
            {
                entity.HasKey(e => e.Idnsx)
                    .HasName("PK__NUOSX__945EC52481023A2F");

                entity.ToTable("NUOSX");

                entity.Property(e => e.Idnsx).HasColumnName("IDNSX");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mansx)
                    .HasColumnName("MANSX")
                    .HasMaxLength(255);

                entity.Property(e => e.Tennsx)
                    .IsRequired()
                    .HasColumnName("TENNSX")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Phieunhapkho>(entity =>
            {
                entity.HasKey(e => e.Idpnk)
                    .HasName("PK__PHIEUNHA__98FEDC48DA73F9B5");

                entity.ToTable("PHIEUNHAPKHO");

                entity.Property(e => e.Idpnk).HasColumnName("IDPNK");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Idncc).HasColumnName("IDNCC");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Ngayhd)
                    .HasColumnName("NGAYHD")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ngaylap)
                    .HasColumnName("NGAYLAP")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sohd)
                    .HasColumnName("SOHD")
                    .HasMaxLength(255);

                entity.Property(e => e.Sophieu)
                    .IsRequired()
                    .HasColumnName("SOPHIEU")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdnccNavigation)
                    .WithMany(p => p.Phieunhapkho)
                    .HasForeignKey(d => d.Idncc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUNHAPK461022");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.Phieunhapkho)
                    .HasForeignKey(d => d.Idnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUNHAPK10246");
            });

            modelBuilder.Entity<Phieuthunokh>(entity =>
            {
                entity.HasKey(e => e.Idptnkh)
                    .HasName("PK__PHIEUTHU__02AF4104430836EA");

                entity.ToTable("PHIEUTHUNOKH");

                entity.Property(e => e.Idptnkh).HasColumnName("IDPTNKH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Idhttt).HasColumnName("IDHTTT");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Ngaylap)
                    .HasColumnName("NGAYLAP")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sophieu)
                    .HasColumnName("SOPHIEU")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdhtttNavigation)
                    .WithMany(p => p.Phieuthunokh)
                    .HasForeignKey(d => d.Idhttt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUTHUNO674725");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.Phieuthunokh)
                    .HasForeignKey(d => d.Idnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUTHUNO460360");
            });

            modelBuilder.Entity<Phieutranoncc>(entity =>
            {
                entity.HasKey(e => e.Idptnncc)
                    .HasName("PK__PHIEUTRA__B57294B7ADDA0229");

                entity.ToTable("PHIEUTRANONCC");

                entity.Property(e => e.Idptnncc).HasColumnName("IDPTNNCC");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Idhttt).HasColumnName("IDHTTT");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Ngaylap)
                    .HasColumnName("NGAYLAP")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sophieu)
                    .IsRequired()
                    .HasColumnName("SOPHIEU")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdhtttNavigation)
                    .WithMany(p => p.Phieutranoncc)
                    .HasForeignKey(d => d.Idhttt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUTRANO140505");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.Phieutranoncc)
                    .HasForeignKey(d => d.Idnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUTRANO695999");
            });

            modelBuilder.Entity<Thuonghieu>(entity =>
            {
                entity.HasKey(e => e.Idth)
                    .HasName("PK__THUONGHI__B87C3A8CE4D05CAB");

                entity.ToTable("THUONGHIEU");

                entity.Property(e => e.Idth).HasColumnName("IDTH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Math)
                    .HasColumnName("MATH")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenth)
                    .IsRequired()
                    .HasColumnName("TENTH")
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
