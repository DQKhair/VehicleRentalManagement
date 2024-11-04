using Microsoft.EntityFrameworkCore;
using ProjectQLThueXe.Domain.Entities;

namespace ProjectQLThueXe.Infrastructure.DBContext
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {

        }

        #region
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<KCT> KCTs { get; set; }
        public DbSet<KT> KTs { get; set; }
        public DbSet<Receipts> Receipts { get; set; }
        public DbSet<ReceiptDetail> ReceiptsDetail { get; set; }
        public DbSet<CarStatus> CarStatus { get; set; }
        public DbSet<ReceiptStatus> ReceiptStatuses { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarType>(entity =>
            {
                entity.ToTable("CarType");
                entity.HasKey(e => e.CarType_ID);
                entity.Property(e => e.CarType_ID).UseIdentityColumn(1, 1);
                entity.Property(e => e.CarTypeName).HasMaxLength(50);

            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");
                entity.HasKey(e => e.Car_ID);
                entity.Property(e => e.Model).HasMaxLength(50);
                entity.Property(e => e.NumberPlate).HasMaxLength(10);

                entity.HasOne(d => d.CarStatus).WithMany(d => d.Cars)
                .HasForeignKey(d => d.CarStatus_ID)
                .HasConstraintName("FK_Car_CarStatus");

                entity.HasOne(d => d.KCT).WithMany(d => d.Cars)
                .HasForeignKey(d => d.KCT_ID)
                .HasConstraintName("FK_Car_KCT");

                entity.HasOne(d => d.CarType).WithMany(d => d.Cars)
               .HasForeignKey(d => d.CarType_ID)
               .HasConstraintName("FK_Car_CarType");

            });

            modelBuilder.Entity<KCT>(entity =>
            {
                entity.ToTable("KCT");
                entity.HasKey(e => e.KCT_ID);
                entity.Property(e => e.KCT_Name).HasMaxLength(50);
                entity.Property(e => e.KCT_Phone).HasMaxLength(12);
                entity.Property(e => e.KCT_address).HasMaxLength(100);
                entity.Property(e => e.KCT_CCCD).HasMaxLength(12);
                entity.Property(e => e.KCT_address).HasMaxLength(100);

            });

            modelBuilder.Entity<ReceiptDetail>(entity =>
            {
                entity.ToTable("ReceiptDetail");
                entity.HasKey(e => e.ReceiptDetail_ID);
                entity.Property(e => e.Car_model).HasMaxLength(50);

                entity.HasOne(d => d.Car).WithMany(d => d.ReceiptDetails)
                .HasForeignKey(d => d.Car_ID)
                .HasConstraintName("FK_ReceiptDetail_Car");

                entity.HasOne(d => d.Receipts).WithMany(d => d.ReceiptDetails)
                .HasForeignKey(d => d.Receipt_ID)
                .HasConstraintName("FK_ReceiptDetail_Receipts");
            });

            modelBuilder.Entity<Receipts>(entity =>
            {
                entity.ToTable("Receipts");
                entity.HasKey(e => e.Receipt_ID);
                entity.Property(e => e.ReceiptDescription).HasMaxLength(200);

                entity.HasOne(d => d.KT).WithMany(d => d.Receipts)
                .HasForeignKey(d => d.KT_ID)
                .HasConstraintName("FK_Receipts_KT");

                entity.HasOne(d => d.ReceiptStatus).WithMany(d => d.Receipts)
                .HasForeignKey(d => d.ReceiptStatus_ID)
                .HasConstraintName("FK_Receipt_ReceiptStatus");
            });

            modelBuilder.Entity<KT>(entity =>
            {
                entity.ToTable("KT");
                entity.HasKey(e => e.KT_ID);
                entity.Property(e => e.KT_Name).HasMaxLength(50);
                entity.Property(e => e.KT_Phone).HasMaxLength(12);
                entity.Property(e => e.KT_Address).HasMaxLength(100);
                entity.Property(e => e.KT_CCCD).HasMaxLength(12);
            });

            modelBuilder.Entity<CarStatus>(entity =>
            {
                entity.ToTable("CarStatus");
                entity.HasKey(e => e.CarStatus_ID);
                entity.Property(e => e.CarStatus_ID).UseIdentityColumn(1,1);
                entity.Property(e => e.CarStatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<ReceiptStatus>(entity =>
            {
                entity.ToTable("ReceiptStatus");
                entity.HasKey(e => e.ReceiptStatus_ID);
                entity.Property(e => e.ReceiptStatus_ID).UseIdentityColumn(1,1);
                entity.Property(e => e.ReceiptstatusName).HasMaxLength(50);
            });
        }
    }
}