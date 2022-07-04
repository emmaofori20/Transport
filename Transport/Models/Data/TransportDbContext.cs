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
        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<FuelType> FuelTypes { get; set; }
        public virtual DbSet<Hiring> Hirings { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<MaintenanceStatus> MaintenanceStatuses { get; set; }
        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<PermAxleLoad> PermAxleLoads { get; set; }
        public virtual DbSet<PhotoSection> PhotoSections { get; set; }
        public virtual DbSet<Quantity> Quantities { get; set; }
        public virtual DbSet<RoutineMaintenanceActivity> RoutineMaintenanceActivities { get; set; }
        public virtual DbSet<RoutineMaintenanceList> RoutineMaintenanceLists { get; set; }
        public virtual DbSet<SparePart> SpareParts { get; set; }
        public virtual DbSet<SparePartQuantity> SparePartQuantities { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<TransmissionType> TransmissionTypes { get; set; }
        public virtual DbSet<TransportStaff> TransportStaffs { get; set; }
        public virtual DbSet<TyreSize> TyreSizes { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleDocument> VehicleDocuments { get; set; }
        public virtual DbSet<VehicleMaintenanceRequest> VehicleMaintenanceRequests { get; set; }
        public virtual DbSet<VehicleMaintenanceRequestStatus> VehicleMaintenanceRequestStatuses { get; set; }
        public virtual DbSet<VehicleMaintenanceSparepart> VehicleMaintenanceSpareparts { get; set; }
        public virtual DbSet<VehiclePhoto> VehiclePhotos { get; set; }
        public virtual DbSet<VehicleRequestPhotoReceipt> VehicleRequestPhotoReceipts { get; set; }
        public virtual DbSet<VehicleRoutineMaintenance> VehicleRoutineMaintenances { get; set; }
        public virtual DbSet<VehicleTransportStaff> VehicleTransportStaffs { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<VehicleUse> VehicleUses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

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

            modelBuilder.Entity<Colour>(entity =>
            {
                entity.HasKey(e => e.ColourId)
                    .HasName("PK39")
                    .IsClustered(false);

                entity.ToTable("Colour");

                entity.Property(e => e.ColourName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK46")
                    .IsClustered(false);

                entity.ToTable("Country");

                entity.Property(e => e.CountryName)
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

            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.HasKey(e => e.FuelTypeId)
                    .HasName("PK38")
                    .IsClustered(false);

                entity.ToTable("FuelType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FuelTypeName)
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

            modelBuilder.Entity<MaintenanceStatus>(entity =>
            {
                entity.HasKey(e => e.MaintenanceStatusId)
                    .HasName("PK27")
                    .IsClustered(false);

                entity.ToTable("MaintenanceStatus");

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

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.ModelId)
                    .HasName("PK45")
                    .IsClustered(false);

                entity.ToTable("Model");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.MakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefMake73");
            });

            modelBuilder.Entity<PermAxleLoad>(entity =>
            {
                entity.HasKey(e => e.PermAxleLoadId)
                    .HasName("PK44")
                    .IsClustered(false);

                entity.ToTable("PermAxleLoad");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.PermAxleLoadValue).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<PhotoSection>(entity =>
            {
                entity.HasKey(e => e.PhotoSectionId)
                    .HasName("PK49")
                    .IsClustered(false);

                entity.ToTable("PhotoSection");

                entity.Property(e => e.PhotoSectionName).HasMaxLength(50);
            });

            modelBuilder.Entity<Quantity>(entity =>
            {
                entity.HasKey(e => e.QuantityId)
                    .HasName("PK42")
                    .IsClustered(false);

                entity.ToTable("Quantity");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoutineMaintenanceActivity>(entity =>
            {
                entity.HasKey(e => e.RoutineMaintenanceActivityId)
                    .HasName("PK34")
                    .IsClustered(false);

                entity.ToTable("RoutineMaintenanceActivity");

                entity.Property(e => e.ActivityName).HasMaxLength(520);

                entity.Property(e => e.CreatedBy).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoutineMaintenanceList>(entity =>
            {
                entity.HasKey(e => e.RoutineMaintenanceListId)
                    .HasName("PK35")
                    .IsClustered(false);

                entity.ToTable("RoutineMaintenanceList");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoutineMaintenanceList>(entity =>
            {
                entity.HasKey(e => e.RoutineMaintenanceListId)
                    .HasName("PK35")
                    .IsClustered(false);

                entity.ToTable("RoutineMaintenanceList");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.RoutineMaintenanceActivity)
                    .WithMany(p => p.RoutineMaintenanceLists)
                    .HasForeignKey(d => d.RoutineMaintenanceActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefRoutineMaintenanceActivity41");

                entity.HasOne(d => d.SparePart)
                    .WithMany(p => p.RoutineMaintenanceLists)
                    .HasForeignKey(d => d.SparePartId)
                    .HasConstraintName("RefSparePart42");

                entity.HasOne(d => d.VehicleRoutineMaintenance)
                    .WithMany(p => p.RoutineMaintenanceLists)
                    .HasForeignKey(d => d.VehicleRoutineMaintenanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefVehicleRoutineMaintenance40");
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

            modelBuilder.Entity<TransmissionType>(entity =>
            {
                entity.HasKey(e => e.TransmissionTypeId)
                    .HasName("PK43")
                    .IsClustered(false);

                entity.ToTable("TransmissionType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.TransmissionTypeName)
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

            modelBuilder.Entity<TyreSize>(entity =>
            {
                entity.HasKey(e => e.TyreSizeId)
                    .HasName("PK41")
                    .IsClustered(false);

                entity.ToTable("TyreSize");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.TyreSizeNumber)
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

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateOfEntry).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.EngineNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.GrossVehicleWeight).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Height).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Length).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.NetVehicleWeight).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.OldRegistrationNumber).HasMaxLength(255);

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PermCapacityLoad).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.PolicyNumber).HasMaxLength(255);

                entity.Property(e => e.PostalAddress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ResidentialAddress).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Width).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.AxleCountNavigation)
                    .WithMany(p => p.VehicleAxleCountNavigations)
                    .HasForeignKey(d => d.AxleCount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefQuantity69");

                entity.HasOne(d => d.College)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CollegeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CollegeVehicle");

                entity.HasOne(d => d.Colour)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ColourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefColour46");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefCountry61");

                entity.HasOne(d => d.CylinderCountNavigation)
                    .WithMany(p => p.VehicleCylinderCountNavigations)
                    .HasForeignKey(d => d.CylinderCount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefQuantity72");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentVehicle");

                entity.HasOne(d => d.FrontPermAxleLoadNavigation)
                    .WithMany(p => p.VehicleFrontPermAxleLoadNavigations)
                    .HasForeignKey(d => d.FrontPermAxleLoad)
                    .HasConstraintName("RefPermAxleLoad59");

                entity.HasOne(d => d.FrontTyreSizeNavigation)
                    .WithMany(p => p.VehicleFrontTyreSizeNavigations)
                    .HasForeignKey(d => d.FrontTyreSize)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefTyreSize48");

                entity.HasOne(d => d.FuelType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.FuelTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefFuelType45");

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

                entity.HasOne(d => d.MiddlePermAxleLoadNavigation)
                    .WithMany(p => p.VehicleMiddlePermAxleLoadNavigations)
                    .HasForeignKey(d => d.MiddlePermAxleLoad)
                    .HasConstraintName("RefPermAxleLoad58");

                entity.HasOne(d => d.MiddleTyreSizeNavigation)
                    .WithMany(p => p.VehicleMiddleTyreSizeNavigations)
                    .HasForeignKey(d => d.MiddleTyreSize)
                    .HasConstraintName("RefTyreSize51");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefModel79");

                entity.HasOne(d => d.PersonCountNavigation)
                    .WithMany(p => p.VehiclePersonCountNavigations)
                    .HasForeignKey(d => d.PersonCount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefQuantity70");

                entity.HasOne(d => d.RearPermAxleLoadNavigation)
                    .WithMany(p => p.VehicleRearPermAxleLoadNavigations)
                    .HasForeignKey(d => d.RearPermAxleLoad)
                    .HasConstraintName("RefPermAxleLoad60");

                entity.HasOne(d => d.RearTyreSizeNavigation)
                    .WithMany(p => p.VehicleRearTyreSizeNavigations)
                    .HasForeignKey(d => d.RearTyreSize)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefTyreSize47");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StatusVehicle");

                entity.HasOne(d => d.TransmissionType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.TransmissionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefTransmissionType53");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefVehicleType44");

                entity.HasOne(d => d.VehicleUse)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleUseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefVehicleUse38");

                entity.HasOne(d => d.WheelCountNavigation)
                    .WithMany(p => p.VehicleWheelCountNavigations)
                    .HasForeignKey(d => d.WheelCount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefQuantity71");
            });

            modelBuilder.Entity<VehicleDocument>(entity =>
            {
                entity.HasKey(e => e.VehicleDocumentId)
                    .HasName("PK47")
                    .IsClustered(false);

                entity.ToTable("VehicleDocument");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.VehicleDocumentFile).IsRequired();

                entity.Property(e => e.VehicleDocumentName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehicleDocuments)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefVehicle63");
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

                entity.Property(e => e.MaintenanceDescription).HasMaxLength(552);

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

                entity.HasOne(d => d.MaintenanceStatus)
                    .WithMany(p => p.VehicleMaintenanceRequestStatuses)
                    .HasForeignKey(d => d.MaintenanceStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefMaintenanceStatus36");

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

            modelBuilder.Entity<VehiclePhoto>(entity =>
            {
                entity.HasKey(e => e.VehiclePhotoId)
                    .HasName("PK31")
                    .IsClustered(false);

                entity.ToTable("VehiclePhoto");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.PhotoFile).IsRequired();

                entity.Property(e => e.PhotoName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.PhotoSection)
                    .WithMany(p => p.VehiclePhotos)
                    .HasForeignKey(d => d.PhotoSectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefPhotoSection82");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehiclePhotos)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefVehicle80");
            });

            modelBuilder.Entity<VehicleRequestPhotoReceipt>(entity =>
            {
                entity.HasKey(e => e.VehicleRequestRecieptId)
                    .HasName("PK33")
                    .IsClustered(false);

                entity.ToTable("VehicleRequestPhotoReceipt");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ReceiptName).HasMaxLength(255);

                entity.Property(e => e.ReceiptPhotoUrl).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.VehicleMaintenanceRequest)
                    .WithMany(p => p.VehicleRequestPhotoReceipts)
                    .HasForeignKey(d => d.VehicleMaintenanceRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefVehicleMaintenanceRequest39");
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

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

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

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.HasKey(e => e.VehicleTypeId)
                    .HasName("PK40")
                    .IsClustered(false);

                entity.ToTable("VehicleType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.VehicleTypeName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<VehicleUse>(entity =>
            {
                entity.HasKey(e => e.VehicleUseId)
                    .HasName("PK32")
                    .IsClustered(false);

                entity.ToTable("VehicleUse");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UseName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
