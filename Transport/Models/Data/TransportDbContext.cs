using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Transport.Models.Data
{
    public partial class TransportDbContext : DbContext
    {
        public TransportDbContext()
        {
        }

        public TransportDbContext(DbContextOptions<TransportDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Hiring> Hirings { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<MaintainanceStatus> MaintainanceStatuses { get; set; }
        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<SparePart> SpareParts { get; set; }
        public virtual DbSet<SparePartQuantity> SparePartQuantities { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<TransportStaff> TransportStaffs { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleMaintenanceRequest> VehicleMaintenanceRequests { get; set; }
        public virtual DbSet<VehicleMaintenanceRequestStatus> VehicleMaintenanceRequestStatuses { get; set; }
        public virtual DbSet<VehicleMaintenanceSparepart> VehicleMaintenanceSpareparts { get; set; }
        public virtual DbSet<VehicleRoutineMaintenance> VehicleRoutineMaintenances { get; set; }
        public virtual DbSet<VehicleTransportStaff> VehicleTransportStaffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<College>(entity =>
            {
                entity.HasKey(e => e.CollegeId)
                    .IsClustered(false);

                entity.ToTable("College");

                entity.Property(e => e.CollegeName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .IsClustered(false);

                entity.ToTable("Department");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Hiring>(entity =>
            {
                entity.HasKey(e => e.HiringId)
                    .IsClustered(false);

                entity.ToTable("Hiring");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Hiree)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.TimeHired).HasColumnType("datetime");

                entity.Property(e => e.TimeReturned).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Hirings)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleHiring");
            });

            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.HasKey(e => e.InsuranceId)
                    .IsClustered(false);

                entity.ToTable("Insurance");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.InsurancePolicyName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<MaintainanceStatus>(entity =>
            {
                entity.HasKey(e => e.MaintainanceStatusId)
                    .HasName("PK27")
                    .IsClustered(false);

                entity.ToTable("MaintainanceStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Make>(entity =>
            {
                entity.HasKey(e => e.MakeId)
                    .IsClustered(false);

                entity.ToTable("Make");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.MakeName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SparePart>(entity =>
            {
                entity.HasKey(e => e.SparePartId)
                    .IsClustered(false);

                entity.ToTable("SparePart");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.SparePartName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SparePartQuantity>(entity =>
            {
                entity.HasKey(e => e.SparePartQuantityId)
                    .HasName("PK25")
                    .IsClustered(false);

                entity.ToTable("SparePartQuantity");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.SparePart)
                    .WithMany(p => p.SparePartQuantities)
                    .HasForeignKey(d => d.SparePartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefSparePart29");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .IsClustered(false);

                entity.ToTable("Status");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TransportStaff>(entity =>
            {
                entity.HasKey(e => e.TransportStaffId)
                    .IsClustered(false);

                entity.ToTable("TransportStaff");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Othernames)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StaffType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleId)
                    .IsClustered(false);

                entity.ToTable("Vehicle");

                entity.Property(e => e.ChasisNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Colour)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Desription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EngineNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FuelType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.GrossVehicleWeight).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Height).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Length).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NetVehicleWeight).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.OldRegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PolicyNumber).HasMaxLength(255);

                entity.Property(e => e.PostalAddress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ResidentialAddress).HasMaxLength(255);

                entity.Property(e => e.SizeOfFrontTyre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("SIzeOfFrontTyre");

                entity.Property(e => e.SizeOfRearTyre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SizeofMiddleTyre).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Width).HasColumnType("decimal(10, 0)");

                entity.HasOne(d => d.College)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CollegeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CollegeVehicle");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentVehicle");

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.InsuranceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InsuranceVehicle");

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.MakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MakeVehicle");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StatusVehicle");
            });

            modelBuilder.Entity<VehicleMaintenanceRequest>(entity =>
            {
                entity.HasKey(e => e.VehicleMaintenanceRequestId)
                    .HasName("PK_VehicleMaintenance")
                    .IsClustered(false);

                entity.ToTable("VehicleMaintenanceRequest");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.MaintainedBy).HasMaxLength(255);

                entity.Property(e => e.MainteinanceCost).HasColumnType("decimal(18, 9)");

                entity.Property(e => e.MaintenanceDescription).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehicleMaintenanceRequests)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleVehicleMaintenance");
            });

            modelBuilder.Entity<VehicleMaintenanceRequestStatus>(entity =>
            {
                entity.HasKey(e => e.VehicleMaintenanceRequestStatusId)
                    .HasName("PK28")
                    .IsClustered(false);

                entity.ToTable("VehicleMaintenanceRequestStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.MaintainanceStatus)
                    .WithMany(p => p.VehicleMaintenanceRequestStatuses)
                    .HasForeignKey(d => d.MaintainanceStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefMaintainanceStatus36");

                entity.HasOne(d => d.VehicleMaintenanceRequest)
                    .WithMany(p => p.VehicleMaintenanceRequestStatuses)
                    .HasForeignKey(d => d.VehicleMaintenanceRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefVehicleMaintenanceRequest31");
            });

            modelBuilder.Entity<VehicleMaintenanceSparepart>(entity =>
            {
                entity.HasKey(e => e.VehicleMaitenanceSparepartId)
                    .HasName("PK24")
                    .IsClustered(false);

                entity.ToTable("VehicleMaintenanceSparepart");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.NameOfPart)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("UpdatedON");

                entity.HasOne(d => d.VehicleMaintenanceRequest)
                    .WithMany(p => p.VehicleMaintenanceSpareparts)
                    .HasForeignKey(d => d.VehicleMaintenanceRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefVehicleMaintenanceRequest28");
            });

            modelBuilder.Entity<VehicleRoutineMaintenance>(entity =>
            {
                entity.HasKey(e => e.VehicleRoutineMaintenanceId)
                    .HasName("PK30")
                    .IsClustered(false);

                entity.ToTable("VehicleRoutineMaintenance");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.SparePart)
                    .WithMany(p => p.VehicleRoutineMaintenances)
                    .HasForeignKey(d => d.SparePartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefSparePart35");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehicleRoutineMaintenances)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefVehicle34");
            });

            modelBuilder.Entity<VehicleTransportStaff>(entity =>
            {
                entity.HasKey(e => e.VehicleTransportStaffId)
                    .IsClustered(false);

                entity.ToTable("VehicleTransportStaff");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StartTime)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.TransportStaff)
                    .WithMany(p => p.VehicleTransportStaffs)
                    .HasForeignKey(d => d.TransportStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransportStaffVehicleTransportStaff");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehicleTransportStaffs)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleVehicleTransportStaff");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
