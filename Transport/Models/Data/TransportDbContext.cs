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

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public virtual DbSet<BusHiringDistance> BusHiringDistances { get; set; }
        public virtual DbSet<BusHiringPrice> BusHiringPrices { get; set; }
        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<FailedEmail> FailedEmails { get; set; }
        public virtual DbSet<FuelType> FuelTypes { get; set; }
        public virtual DbSet<Hirer> Hirers { get; set; }
        public virtual DbSet<HirerHiringStatus> HirerHiringStatuses { get; set; }
        public virtual DbSet<Hiring> Hirings { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<PermAxleLoad> PermAxleLoads { get; set; }
        public virtual DbSet<PhotoSection> PhotoSections { get; set; }
        public virtual DbSet<Quantity> Quantities { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<RequestTypeCharge> RequestTypeCharges { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
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
        public virtual DbSet<VehicleMaintenanceRequestItem> VehicleMaintenanceRequestItems { get; set; }
        public virtual DbSet<VehicleMaintenanceRequestStatus> VehicleMaintenanceRequestStatuses { get; set; }
        public virtual DbSet<VehiclePhoto> VehiclePhotos { get; set; }
        public virtual DbSet<VehicleRequestPhotoReceipt> VehicleRequestPhotoReceipts { get; set; }
        public virtual DbSet<VehicleRoutineMaintenance> VehicleRoutineMaintenances { get; set; }
        public virtual DbSet<VehicleTransportStaff> VehicleTransportStaffs { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<VehicleTypeForHire> VehicleTypeForHires { get; set; }
        public virtual DbSet<VehicleUse> VehicleUses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasKey(e => e.ApplicationUserId)
                    .IsClustered(false);

                entity.ToTable("ApplicationUser");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ApplicationUserRole>(entity =>
            {
                entity.HasKey(e => e.ApplicationUserRoleId)
                    .IsClustered(false);

                entity.ToTable("ApplicationUserRole");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.ApplicationUserRoles)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationUserRole_ApplicationUser");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ApplicationUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationUserRole_Role");
            });

            modelBuilder.Entity<BusHiringDistance>(entity =>
            {
                entity.HasKey(e => e.BusHiringDistanceId)
                    .IsClustered(false);

                entity.ToTable("BusHiringDistance");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<BusHiringPrice>(entity =>
            {
                entity.HasKey(e => e.BusHiringPriceId)
                    .IsClustered(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.BusHiringDistance)
                    .WithMany(p => p.BusHiringPrices)
                    .HasForeignKey(d => d.BusHiringDistanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusHiringPrices_BusHiringDistance");

                entity.HasOne(d => d.VehicleTypeForHire)
                    .WithMany(p => p.BusHiringPrices)
                    .HasForeignKey(d => d.VehicleTypeForHireId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusHiringPrices_VehicleTypeForHire");
            });

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

                entity.HasOne(d => d.College)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.CollegeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_College");
            });

            modelBuilder.Entity<FailedEmail>(entity =>
            {
                entity.HasKey(e => e.FailedEmailId)
                    .IsClustered(false);

                entity.ToTable("FailedEmail");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.SectionName).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.HasKey(e => e.FuelTypeId)
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

            modelBuilder.Entity<Hirer>(entity =>
            {
                entity.HasKey(e => e.HirerId)
                    .IsClustered(false);

                entity.ToTable("Hirer");

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DistanceCalaculatedFromOriginCost).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.DistanceCalculatedFromOrigin).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FinishDate).HasColumnType("date");

                entity.Property(e => e.OrganisationName).HasMaxLength(255);

                entity.Property(e => e.OtherContactNumber).HasMaxLength(255);

                entity.Property(e => e.PostalAddress).HasMaxLength(255);

                entity.Property(e => e.PrimaryContactNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PurposeOfHire).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.VehicleTypeForHire)
                    .WithMany(p => p.Hirers)
                    .HasForeignKey(d => d.VehicleTypeForHireId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hirer_VehicleTypeForHire");
            });

            modelBuilder.Entity<HirerHiringStatus>(entity =>
            {
                entity.HasKey(e => e.HirerHiringStatusId)
                    .IsClustered(false);

                entity.ToTable("HirerHiringStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Hirer)
                    .WithMany(p => p.HirerHiringStatuses)
                    .HasForeignKey(d => d.HirerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HirerHiringStatus_Hirer");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.HirerHiringStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_HirerHiringStatus_Status");
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

                entity.Property(e => e.DriverHireFee).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.HireCostFee).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.TimeHired).HasColumnType("datetime");

                entity.Property(e => e.TimeReturned).HasColumnType("datetime");

                entity.Property(e => e.TotalHirePrice).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.WashingFee).HasColumnType("decimal(10, 0)");

                entity.HasOne(d => d.Hirer)
                    .WithMany(p => p.Hirings)
                    .HasForeignKey(d => d.HirerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hiring_Hirer");

                entity.HasOne(d => d.TransportStaff)
                    .WithMany(p => p.Hirings)
                    .HasForeignKey(d => d.TransportStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hiring_TransportStaff");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Hirings)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hiring_Vehicle");
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
                    .HasConstraintName("FK_Model_Make");
            });

            modelBuilder.Entity<PermAxleLoad>(entity =>
            {
                entity.HasKey(e => e.PermAxleLoadId)
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
                    .IsClustered(false);

                entity.ToTable("PhotoSection");

                entity.Property(e => e.PhotoSectionName).HasMaxLength(50);
            });

            modelBuilder.Entity<Quantity>(entity =>
            {
                entity.HasKey(e => e.QuantityId)
                    .IsClustered(false);

                entity.ToTable("Quantity");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.HasKey(e => e.RequestTypeId)
                    .IsClustered(false);

                entity.ToTable("RequestType");

                entity.Property(e => e.RequestTypeName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<RequestTypeCharge>(entity =>
            {
                entity.HasKey(e => e.RequestTypeChargeId)
                    .IsClustered(false);

                entity.ToTable("RequestTypeCharge");

                entity.Property(e => e.ActiveFrom).HasColumnType("datetime");

                entity.Property(e => e.ActiveTo).HasColumnType("datetime");

                entity.Property(e => e.ChargeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ChargeValue).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.RequestTypeCharges)
                    .HasForeignKey(d => d.RequestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestTypeCharge_RequestType");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .IsClustered(false);

                entity.ToTable("Role");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.RoleName).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoutineMaintenanceActivity>(entity =>
            {
                entity.HasKey(e => e.RoutineMaintenanceActivityId)
                    .IsClustered(false);

                entity.ToTable("RoutineMaintenanceActivity");

                entity.Property(e => e.ActivityName).HasMaxLength(520);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoutineMaintenanceList>(entity =>
            {
                entity.HasKey(e => e.RoutineMaintenanceListId)
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
                    .HasConstraintName("FK_RoutineMaintenanceList_RoutineMaintenanceActivity");

                entity.HasOne(d => d.SparePart)
                    .WithMany(p => p.RoutineMaintenanceLists)
                    .HasForeignKey(d => d.SparePartId)
                    .HasConstraintName("FK_RoutineMaintenanceList_SparePart");

                entity.HasOne(d => d.VehicleRoutineMaintenance)
                    .WithMany(p => p.RoutineMaintenanceLists)
                    .HasForeignKey(d => d.VehicleRoutineMaintenanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoutineMaintenanceList_VehicleRoutineMaintenance");
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
                    .HasConstraintName("FK_SparePartQuantity_SparePart");
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
                    .HasConstraintName("FK_Vehicle_Quantity");

                entity.HasOne(d => d.College)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CollegeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_College");

                entity.HasOne(d => d.Colour)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ColourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Colour");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Country");

                entity.HasOne(d => d.CylinderCountNavigation)
                    .WithMany(p => p.VehicleCylinderCountNavigations)
                    .HasForeignKey(d => d.CylinderCount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Quanti4");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Department");

                entity.HasOne(d => d.FrontPermAxleLoadNavigation)
                    .WithMany(p => p.VehicleFrontPermAxleLoadNavigations)
                    .HasForeignKey(d => d.FrontPermAxleLoad)
                    .HasConstraintName("FK_Vehicle_PermAxleL45");

                entity.HasOne(d => d.FrontTyreSizeNavigation)
                    .WithMany(p => p.VehicleFrontTyreSizeNavigations)
                    .HasForeignKey(d => d.FrontTyreSize)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_TyreSi7");

                entity.HasOne(d => d.FuelType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.FuelTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_FuelType");

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.InsuranceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Insurance");

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.MakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Make");

                entity.HasOne(d => d.MiddlePermAxleLoadNavigation)
                    .WithMany(p => p.VehicleMiddlePermAxleLoadNavigations)
                    .HasForeignKey(d => d.MiddlePermAxleLoad)
                    .HasConstraintName("FK_Vehicle_PermAxleL44");

                entity.HasOne(d => d.MiddleTyreSizeNavigation)
                    .WithMany(p => p.VehicleMiddleTyreSizeNavigations)
                    .HasForeignKey(d => d.MiddleTyreSize)
                    .HasConstraintName("FK_Vehicle_TyreSi8");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Model");

                entity.HasOne(d => d.PersonCountNavigation)
                    .WithMany(p => p.VehiclePersonCountNavigations)
                    .HasForeignKey(d => d.PersonCount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Quanti2");

                entity.HasOne(d => d.RearPermAxleLoadNavigation)
                    .WithMany(p => p.VehicleRearPermAxleLoadNavigations)
                    .HasForeignKey(d => d.RearPermAxleLoad)
                    .HasConstraintName("FK_Vehicle_PermAxleLoad");

                entity.HasOne(d => d.RearTyreSizeNavigation)
                    .WithMany(p => p.VehicleRearTyreSizeNavigations)
                    .HasForeignKey(d => d.RearTyreSize)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_TyreSize");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Status");

                entity.HasOne(d => d.TransmissionType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.TransmissionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_TransmissionType");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_VehicleType");

                entity.HasOne(d => d.VehicleUse)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleUseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_VehicleUse");

                entity.HasOne(d => d.WheelCountNavigation)
                    .WithMany(p => p.VehicleWheelCountNavigations)
                    .HasForeignKey(d => d.WheelCount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Quanti3");
            });

            modelBuilder.Entity<VehicleDocument>(entity =>
            {
                entity.HasKey(e => e.VehicleDocumentId)
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
                    .HasConstraintName("FK_VehicleDocument_Vehicle");
            });

            modelBuilder.Entity<VehicleMaintenanceRequest>(entity =>
            {
                entity.HasKey(e => e.VehicleMaintenanceRequestId)
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
                    .HasConstraintName("FK_VehicleMaintenanceRequest_Vehicle");
            });

            modelBuilder.Entity<VehicleMaintenanceRequestItem>(entity =>
            {
                entity.HasKey(e => e.VehicleMaintenanceRequestItemId)
                    .IsClustered(false);

                entity.ToTable("VehicleMaintenanceRequestItem");

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

                entity.HasOne(d => d.RequestTypeCharge)
                    .WithMany(p => p.VehicleMaintenanceRequestItems)
                    .HasForeignKey(d => d.RequestTypeChargeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleMaintenanceRequestItem_RequestTypeCharge");

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.VehicleMaintenanceRequestItems)
                    .HasForeignKey(d => d.RequestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleMaintenanceRequestItem_RequestType");

                entity.HasOne(d => d.VehicleMaintenanceRequest)
                    .WithMany(p => p.VehicleMaintenanceRequestItems)
                    .HasForeignKey(d => d.VehicleMaintenanceRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleMaintenanceRequestItem_VehicleMaintenanceRequest");
            });

            modelBuilder.Entity<VehicleMaintenanceRequestStatus>(entity =>
            {
                entity.HasKey(e => e.VehicleMaintenanceRequestStatusId)
                    .IsClustered(false);

                entity.ToTable("VehicleMaintenanceRequestStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.VehicleMaintenanceRequestStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_VehicleMaintenanceRequestStatus_Status");

                entity.HasOne(d => d.VehicleMaintenanceRequest)
                    .WithMany(p => p.VehicleMaintenanceRequestStatuses)
                    .HasForeignKey(d => d.VehicleMaintenanceRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleMaintenanceRequestStatus_VehicleMaintenanceRequest");
            });

            modelBuilder.Entity<VehiclePhoto>(entity =>
            {
                entity.HasKey(e => e.VehiclePhotoId)
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
                    .HasConstraintName("FK_VehiclePhoto_PhotoSection");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehiclePhotos)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_VehiclePhoto_Vehicle");
            });

            modelBuilder.Entity<VehicleRequestPhotoReceipt>(entity =>
            {
                entity.HasKey(e => e.VehicleRequestRecieptId)
                    .IsClustered(false);

                entity.ToTable("VehicleRequestPhotoReceipt");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(255);

                entity.Property(e => e.ReceiptPhotoStreamFileId).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.VehicleMaintenanceRequest)
                    .WithMany(p => p.VehicleRequestPhotoReceipts)
                    .HasForeignKey(d => d.VehicleMaintenanceRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleRequestPhotoReceipt_VehicleMaintenanceRequest");
            });

            modelBuilder.Entity<VehicleRoutineMaintenance>(entity =>
            {
                entity.HasKey(e => e.VehicleRoutineMaintenanceId)
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
                    .HasConstraintName("FK_VehicleRoutineMaintenance_Vehicle");
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
                    .HasConstraintName("FK_VehicleTransportStaff_TransportStaff");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehicleTransportStaffs)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleTransportStaff_Vehicle");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.HasKey(e => e.VehicleTypeId)
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

            modelBuilder.Entity<VehicleTypeForHire>(entity =>
            {
                entity.HasKey(e => e.VehicleTypeForHireId)
                    .IsClustered(false);

                entity.ToTable("VehicleTypeForHire");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.VehicleType)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<VehicleUse>(entity =>
            {
                entity.HasKey(e => e.VehicleUseId)
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
