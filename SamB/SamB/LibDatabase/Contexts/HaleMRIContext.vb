Imports System
Imports System.Collections.Generic
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.VisualBasic

Namespace Contexts
    Partial Public Class HaleMRIContext
        Inherits DbContext

        Public Sub New()
        End Sub

        Public Sub New(options As DbContextOptions(Of HaleMRIContext))
            MyBase.New(options)
        End Sub

        Public Overridable Property Blades As DbSet(Of Blade)

        Public Overridable Property CellMeasurements As DbSet(Of CellMeasurement)

        Public Overridable Property CountryCodes As DbSet(Of CountryCode)

        Public Overridable Property Cups As DbSet(Of Cup)

        Public Overridable Property Customers As DbSet(Of Customer)

        Public Overridable Property Employees As DbSet(Of Employee)

        Public Overridable Property Exclusions As DbSet(Of Exclusion)

        Public Overridable Property ExtremeMeasurements As DbSet(Of ExtremeMeasurement)

        Public Overridable Property Jobs As DbSet(Of Job)

        Public Overridable Property JobDetails As DbSet(Of JobDetail)

        Public Overridable Property Manufacturers As DbSet(Of Manufacturer)

        Public Overridable Property Materials As DbSet(Of Material)

        Public Overridable Property Propellers As DbSet(Of Propeller)

        Public Overridable Property RadiusMeasurements As DbSet(Of RadiusMeasurement)

        Public Overridable Property Rotations As DbSet(Of Rotation)

        Public Overridable Property Settings As DbSet(Of Setting)

        Public Overridable Property StateCodes As DbSet(Of StateCode)

        Public Overridable Property Styles As DbSet(Of Style)

        Public Overridable Property Tolerances As DbSet(Of Tolerance)

        Public Overridable Property Vessels As DbSet(Of Vessel)

        Public Overridable Property VesselServiceTypes As DbSet(Of VesselServiceType)

        Public Overridable Property Workstations As DbSet(Of Workstation)

        Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
            'TODO /!\ To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseJet("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\82002\source\repos\Hale-MRI\Hale-MRI\LibDatabase\HaleMRI.accdb")
        End Sub

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            modelBuilder.Entity(Of Blade)(
                Sub(entity)
                    entity.HasKey(Function(e) e.BladeCount).HasName("PrimaryKey")

                    entity.ToTable("~Blades")

                    entity.HasIndex(Function(e) e.BladeCount, "Measurement").IsUnique()

                    entity.Property(Function(e) e.BladeCount).
                        ValueGeneratedNever().
                        HasColumnName("Blade Count")
                End Sub)

            modelBuilder.Entity(Of CellMeasurement)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PrimaryKey")

                    entity.ToTable("Cell Measurements")

                    entity.HasIndex(Function(e) e.Id, "ID")

                    entity.HasIndex(Function(e) e.JobDetailsId, "Radius ID")

                    entity.Property(Function(e) e.Id).
                        HasColumnType("counter").
                        HasColumnName("ID")
                    entity.Property(Function(e) e.JobDetailsId).HasColumnName("Job Details ID")

                    entity.HasOne(Function(d) d.JobDetails).WithMany(Function(p) p.CellMeasurements).
                        HasForeignKey(Function(d) d.JobDetailsId).
                        HasConstraintName("Job DetailsCell Measurements")
                End Sub)

            modelBuilder.Entity(Of CountryCode)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Alpha2Code).HasName("PrimaryKey")

                    entity.ToTable("~Country Codes")

                    entity.HasIndex(Function(e) e.Alpha2Code, "Alpha-2 code")

                    entity.HasIndex(Function(e) e.Alpha3Code, "Alpha-3 code")

                    entity.HasIndex(Function(e) e.Numeric, "Numeric")

                    entity.Property(Function(e) e.Alpha2Code).HasColumnName("Alpha-2 code")
                    entity.Property(Function(e) e.Alpha3Code).HasColumnName("Alpha-3 code")
                    entity.Property(Function(e) e.Country).HasMaxLength(255)
                End Sub)

            modelBuilder.Entity(Of Cup)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Cup1).HasName("PrimaryKey")

                    entity.ToTable("~Cups")

                    entity.HasIndex(Function(e) e.Cup1, "Measurement").IsUnique()

                    entity.Property(Function(e) e.Cup1).HasColumnName("Cup")
                End Sub)

            modelBuilder.Entity(Of Customer)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PrimaryKey")

                    entity.Property(Function(e) e.Id).
                        HasColumnType("counter").
                        HasColumnName("ID")
                    entity.Property(Function(e) e.Address).HasMaxLength(80)
                    entity.Property(Function(e) e.City).HasMaxLength(64)
                    entity.Property(Function(e) e.CountryCode).
                        HasMaxLength(2).
                        HasColumnName("Country Code")
                    entity.Property(Function(e) e.CustomerName).
                        IsRequired().
                        HasMaxLength(64).
                        HasColumnName("Customer Name")
                    entity.Property(Function(e) e.Email).HasMaxLength(255)
                    entity.Property(Function(e) e.PostalCode).
                        HasMaxLength(255).
                        HasColumnName("Postal Code")
                    entity.Property(Function(e) e.State).HasMaxLength(2)
                    entity.Property(Function(e) e.Telephone).HasMaxLength(255)
                    entity.Property(Function(e) e.Website).HasMaxLength(64)

                    entity.HasOne(Function(d) d.CountryCodeNavigation).WithMany(Function(p) p.Customers).
                        HasForeignKey(Function(d) d.CountryCode).
                        HasConstraintName("~Country CodesCustomers")

                    entity.HasOne(Function(d) d.StateNavigation).WithMany(Function(p) p.Customers).
                        HasForeignKey(Function(d) d.State).
                        HasConstraintName("~State CodesCustomers")
                End Sub)

            modelBuilder.Entity(Of Employee)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PrimaryKey")

                    entity.HasIndex(Function(e) e.Id, "ID")

                    entity.Property(Function(e) e.Id).
                        HasColumnType("counter").
                        HasColumnName("ID")
                    entity.Property(Function(e) e.EmployeeName).
                        IsRequired().
                        HasMaxLength(64).
                        HasColumnName("Employee Name")
                End Sub)

            modelBuilder.Entity(Of Exclusion)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Exclusion1).HasName("PrimaryKey")

                    entity.ToTable("~Exclusions")

                    entity.HasIndex(Function(e) e.Exclusion1, "Measurement").IsUnique()

                    entity.Property(Function(e) e.Exclusion1).HasColumnName("Exclusion")
                End Sub)

            modelBuilder.Entity(Of ExtremeMeasurement)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PrimaryKey")

                    entity.ToTable("Extreme Measurements")

                    entity.HasIndex(Function(e) e.BladeId, "Blade ID")

                    entity.HasIndex(Function(e) e.Id, "ID")

                    entity.HasIndex(Function(e) e.JobDetailsId, "Job Details ID")

                    entity.Property(Function(e) e.Id).
                        HasColumnType("counter").
                        HasColumnName("ID")
                    entity.Property(Function(e) e.BladeId).HasColumnName("Blade ID")
                    entity.Property(Function(e) e.JobDetailsId).HasColumnName("Job Details ID")

                    entity.HasOne(Function(d) d.JobDetails).WithMany(Function(p) p.ExtremeMeasurements).
                        HasForeignKey(Function(d) d.JobDetailsId).
                        HasConstraintName("Job DetailsExtremeMeasurements")
                End Sub)

            modelBuilder.Entity(Of Job)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PrimaryKey")

                    entity.HasIndex(Function(e) e.Id, "ID")

                    entity.HasIndex(Function(e) e.JobNumber, "Job Number").IsUnique()

                    entity.HasIndex(Function(e) e.ManufacturerId, "Manufacturer ID")

                    entity.HasIndex(Function(e) e.Material, "Prop Material ID")

                    entity.HasIndex(Function(e) e.VesselId, "Vessel ID")

                    entity.Property(Function(e) e.Id).
                        HasColumnType("counter").
                        HasColumnName("ID")
                    entity.Property(Function(e) e.Description).HasMaxLength(80)
                    entity.Property(Function(e) e.InspectedBy).HasColumnName("Inspected By")
                    entity.Property(Function(e) e.JobNumber).HasColumnName("Job Number")
                    entity.Property(Function(e) e.ManufacturerId).HasColumnName("Manufacturer ID")
                    entity.Property(Function(e) e.Material).HasMaxLength(16)
                    entity.Property(Function(e) e.PartDescription).
                        HasMaxLength(40).
                        HasColumnName("Part Description")
                    entity.Property(Function(e) e.PartNumber).
                        HasMaxLength(16).
                        HasColumnName("Part Number")
                    entity.Property(Function(e) e.SerialNumber).
                        HasMaxLength(32).
                        HasColumnName("Serial Number")
                    entity.Property(Function(e) e.StampNumber).
                        HasMaxLength(32).
                        HasColumnName("Stamp Number")
                    entity.Property(Function(e) e.StartDate).HasColumnName("Start Date")
                    entity.Property(Function(e) e.Style).HasMaxLength(255)
                    entity.Property(Function(e) e.VesselId).HasColumnName("Vessel ID")

                    entity.HasOne(Function(d) d.InspectedByNavigation).WithMany(Function(p) p.Jobs).
                        HasForeignKey(Function(d) d.InspectedBy).
                        HasConstraintName("EmployeesJobs")

                    entity.HasOne(Function(d) d.Manufacturer).WithMany(Function(p) p.Jobs).
                        HasForeignKey(Function(d) d.ManufacturerId).
                        HasConstraintName("ManufacturersJobs")

                    entity.HasOne(Function(d) d.Vessel).WithMany(Function(p) p.Jobs).
                        HasForeignKey(Function(d) d.VesselId).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("VesselsJobs")
                End Sub)

            modelBuilder.Entity(Of JobDetail)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PrimaryKey")

                    entity.ToTable("Job Details")

                    entity.HasIndex(Function(e) e.Id, "ID")

                    entity.HasIndex(Function(e) e.JobId, "Job ID")

                    entity.HasIndex(Function(e) e.LeExclusion, "LE Exclusion")

                    entity.HasIndex(Function(e) e.TeExclusion, "TE Exclusion")

                    entity.Property(Function(e) e.Id).
                        HasColumnType("counter").
                        HasColumnName("ID")
                    entity.Property(Function(e) e.Bore).HasMaxLength(9)
                    entity.Property(Function(e) e.[Class]).HasMaxLength(4)
                    entity.Property(Function(e) e.Dar).HasColumnName("DAR")
                    entity.Property(Function(e) e.Description).HasMaxLength(16)
                    entity.Property(Function(e) e.DesiredPitch).HasColumnName("Desired Pitch")
                    entity.Property(Function(e) e.FileName).
                        HasMaxLength(255).
                        HasColumnName("File Name")
                    entity.Property(Function(e) e.JobId).HasColumnName("Job ID")
                    entity.Property(Function(e) e.LeExclusion).HasColumnName("LE Exclusion")
                    entity.Property(Function(e) e.MarkedPitch).HasColumnName("Marked Pitch")
                    entity.Property(Function(e) e.PerformedBy).HasColumnName("Performed By")
                    entity.Property(Function(e) e.Rotation).HasMaxLength(1)
                    entity.Property(Function(e) e.StartDate).HasColumnName("Start Date")
                    entity.Property(Function(e) e.TeExclusion).HasColumnName("TE Exclusion")
                    entity.Property(Function(e) e.WheelPitch).HasColumnName("Wheel Pitch")

                    entity.HasOne(Function(d) d.ClassNavigation).WithMany(Function(p) p.JobDetails).
                        HasForeignKey(Function(d) d.Class).
                        HasConstraintName("~ClassesPropellers")

                    entity.HasOne(Function(d) d.CupNavigation).WithMany(Function(p) p.JobDetails).
                        HasForeignKey(Function(d) d.Cup).
                        HasConstraintName("~CupsPropellers")

                    entity.HasOne(Function(d) d.Job).WithMany(Function(p) p.JobDetails).
                        HasForeignKey(Function(d) d.JobId).
                        HasConstraintName("JobsJob Details")

                    entity.HasOne(Function(d) d.LeExclusionNavigation).WithMany(Function(p) p.JobDetailLeExclusionNavigations).
                        HasForeignKey(Function(d) d.LeExclusion).
                        HasConstraintName("~ExclusionsPropellers")

                    entity.HasOne(Function(d) d.PerformedByNavigation).WithMany(Function(p) p.JobDetails).
                        HasForeignKey(Function(d) d.PerformedBy).
                        HasConstraintName("EmployeesPropellers")

                    entity.HasOne(Function(d) d.RotationNavigation).WithMany(Function(p) p.JobDetails).
                        HasForeignKey(Function(d) d.Rotation).
                        HasConstraintName("~RotationsPropellers")

                    entity.HasOne(Function(d) d.TeExclusionNavigation).WithMany(Function(p) p.JobDetailTeExclusionNavigations).
                        HasForeignKey(Function(d) d.TeExclusion).
                        HasConstraintName("~ExclusionsPropellers1")
                End Sub)

            modelBuilder.Entity(Of Manufacturer)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PrimaryKey")

                    entity.HasIndex(Function(e) e.Id, "ID")

                    entity.HasIndex(Function(e) e.PostalCode, "Postal Code")

                    entity.Property(Function(e) e.Id).
                        HasColumnType("counter").
                        HasColumnName("ID")
                    entity.Property(Function(e) e.Address).HasMaxLength(80)
                    entity.Property(Function(e) e.City).HasMaxLength(64)
                    entity.Property(Function(e) e.CountryCode).
                        HasMaxLength(2).
                        HasColumnName("Country Code")
                    entity.Property(Function(e) e.Email).HasMaxLength(64)
                    entity.Property(Function(e) e.ManufacturerName).
                        HasMaxLength(64).
                        HasColumnName("Manufacturer Name")
                    entity.Property(Function(e) e.PostalCode).
                        HasMaxLength(16).
                        HasColumnName("Postal Code")
                    entity.Property(Function(e) e.State).HasMaxLength(2)
                    entity.Property(Function(e) e.Telephone).HasMaxLength(20)
                    entity.Property(Function(e) e.Website).HasMaxLength(64)

                    entity.HasOne(Function(d) d.CountryCodeNavigation).WithMany(Function(p) p.Manufacturers).
                        HasForeignKey(Function(d) d.CountryCode).
                        HasConstraintName("~Country CodesManufacturers")

                    entity.HasOne(Function(d) d.StateNavigation).WithMany(Function(p) p.Manufacturers).
                        HasForeignKey(Function(d) d.State).
                        HasConstraintName("~State CodesManufacturers")
                End Sub)

            modelBuilder.Entity(Of Material)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Material1).HasName("PrimaryKey")

                    entity.ToTable("~Materials")

                    entity.HasIndex(Function(e) e.Material1, "Material").IsUnique()

                    entity.Property(Function(e) e.Material1).
                        HasMaxLength(16).
                        HasColumnName("Material")
                End Sub)

            modelBuilder.Entity(Of Propeller)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PrimaryKey")

                    entity.HasIndex(Function(e) e.Id, "ID")

                    entity.HasIndex(Function(e) e.ManufacturerId, "Manufacturer ID")

                    entity.Property(Function(e) e.Id).
                        HasColumnType("counter").
                        HasColumnName("ID")
                    entity.Property(Function(e) e.BladeArea).HasColumnName("Blade Area")
                    entity.Property(Function(e) e.BladeWidth).HasColumnName("Blade Width")
                    entity.Property(Function(e) e.Description).HasMaxLength(64)
                    entity.Property(Function(e) e.ManufacturerId).HasColumnName("Manufacturer ID")
                    entity.Property(Function(e) e.PartNumber).
                        HasMaxLength(32).
                        HasColumnName("Part Number")
                    entity.Property(Function(e) e.RotationlInertia).HasColumnName("Rotationl Inertia")
                    entity.Property(Function(e) e.Style).HasMaxLength(16)

                    entity.HasOne(Function(d) d.BladesNavigation).WithMany(Function(p) p.Propellers).
                        HasForeignKey(Function(d) d.Blades).
                        HasConstraintName("~BladesProducts")

                    entity.HasOne(Function(d) d.Manufacturer).WithMany(Function(p) p.Propellers).
                        HasForeignKey(Function(d) d.ManufacturerId).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("ManufacturersProducts")

                    entity.HasOne(Function(d) d.StyleNavigation).WithMany(Function(p) p.Propellers).
                        HasForeignKey(Function(d) d.Style).
                        HasConstraintName("~StylesProducts")
                End Sub)

            modelBuilder.Entity(Of RadiusMeasurement)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PrimaryKey")

                    entity.ToTable("Radius Measurements")

                    entity.HasIndex(Function(e) e.BladeId, "Blade ID")

                    entity.HasIndex(Function(e) e.Id, "ID")

                    entity.HasIndex(Function(e) e.JobDetailsId, "Job ID")

                    entity.Property(Function(e) e.Id).
                        HasColumnType("counter").
                        HasColumnName("ID")
                    entity.Property(Function(e) e.BladeId).HasColumnName("Blade ID")
                    entity.Property(Function(e) e.JobDetailsId).HasColumnName("Job Details ID")
                    entity.Property(Function(e) e.LeCell).HasColumnName("LE Cell")
                    entity.Property(Function(e) e.TeCell).HasColumnName("TE Cell")

                    entity.HasOne(Function(d) d.JobDetails).WithMany(Function(p) p.RadiusMeasurements).
                        HasForeignKey(Function(d) d.JobDetailsId).
                        HasConstraintName("PropellersRadius Measurements")
                End Sub)

            modelBuilder.Entity(Of Rotation)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Rotation1).HasName("PrimaryKey")

                    entity.ToTable("~Rotations")

                    entity.Property(Function(e) e.Rotation1).
                        HasMaxLength(1).
                        HasColumnName("Rotation")
                End Sub)

            modelBuilder.Entity(Of Setting)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PrimaryKey")

                    entity.ToTable("~Settings")

                    entity.HasIndex(Function(e) e.Id, "ID")

                    entity.Property(Function(e) e.Id).
                        HasColumnType("counter").
                        HasColumnName("ID")
                    entity.Property(Function(e) e.EncoderCalibrationSampleRate).HasColumnName("Encoder Calibration Sample Rate")
                    entity.Property(Function(e) e.EncoderDataInitialDirectory).
                        HasMaxLength(255).
                        HasColumnName("Encoder Data Initial Directory")
                    entity.Property(Function(e) e.JobNumberMin).HasColumnName("Job Number Min")
                    entity.Property(Function(e) e.ShopName).
                        HasMaxLength(40).
                        HasColumnName("Shop Name")
                End Sub)

            modelBuilder.Entity(Of StateCode)(
                Sub(entity)
                    entity.HasKey(Function(e) e.StateCode1).HasName("PrimaryKey")

                    entity.ToTable("~State Codes")

                    entity.HasIndex(Function(e) e.StateCode1, "State Code").IsUnique()

                    entity.HasIndex(Function(e) e.StateName, "State Name").IsUnique()

                    entity.Property(Function(e) e.StateCode1).
                        HasMaxLength(2).
                        HasColumnName("State Code")
                    entity.Property(Function(e) e.StateName).
                        IsRequired().
                        HasMaxLength(32).
                        HasColumnName("State Name")
                End Sub)

            modelBuilder.Entity(Of Style)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Style1).HasName("PrimaryKey")

                    entity.ToTable("~Styles")

                    entity.HasIndex(Function(e) e.Style1, "Style").IsUnique()

                    entity.Property(Function(e) e.Style1).
                        HasMaxLength(16).
                        HasColumnName("Style")
                End Sub)

            modelBuilder.Entity(Of Tolerance)(
                Sub(entity)
                    entity.HasKey(Function(e) e.ToleranceClass).HasName("PrimaryKey")

                    entity.ToTable("~Tolerances")

                    entity.HasIndex(Function(e) e.ToleranceClass, "Class Name").IsUnique()

                    entity.Property(Function(e) e.ToleranceClass).
                        HasMaxLength(4).
                        HasColumnName("Tolerance Class")
                End Sub)

            modelBuilder.Entity(Of Vessel)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PrimaryKey")

                    entity.HasIndex(Function(e) e.CustomerId, "Customer ID")

                    entity.HasIndex(Function(e) e.Id, "ID")

                    entity.Property(Function(e) e.Id).
                        HasColumnType("counter").
                        HasColumnName("ID")
                    entity.Property(Function(e) e.BuildYear).HasColumnName("Build Year")
                    entity.Property(Function(e) e.CallSign).
                        HasMaxLength(64).
                        HasColumnName("Call Sign")
                    entity.Property(Function(e) e.CustomerId).HasColumnName("Customer ID")
                    entity.Property(Function(e) e.Flag).HasMaxLength(16)
                    entity.Property(Function(e) e.HullIdNumber).
                        HasMaxLength(16).
                        HasColumnName("Hull ID Number")
                    entity.Property(Function(e) e.PrimaryVesselNumber).
                        HasMaxLength(16).
                        HasColumnName("Primary Vessel Number")
                    entity.Property(Function(e) e.ServiceTypeId).HasColumnName("Service Type ID")
                    entity.Property(Function(e) e.VesselName).
                        IsRequired().
                        HasMaxLength(64).
                        HasColumnName("Vessel Name")

                    entity.HasOne(Function(d) d.Customer).WithMany(Function(p) p.Vessels).
                        HasForeignKey(Function(d) d.CustomerId).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("CustomersVessels")

                    entity.HasOne(Function(d) d.ServiceType).WithMany(Function(p) p.Vessels).
                        HasForeignKey(Function(d) d.ServiceTypeId).
                        HasConstraintName("~Vessel Service TypesVessels")
                End Sub)

            modelBuilder.Entity(Of VesselServiceType)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PrimaryKey")

                    entity.ToTable("~Vessel Service Types")

                    entity.Property(Function(e) e.Id).
                        ValueGeneratedNever().
                        HasColumnName("ID")
                    entity.Property(Function(e) e.Description).HasMaxLength(100)
                    entity.Property(Function(e) e.ServiceType).
                        HasMaxLength(40).
                        HasColumnName("Service Type")
                End Sub)

            modelBuilder.Entity(Of Workstation)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PrimaryKey")

                    entity.HasIndex(Function(e) e.Hostname, "Hostname").IsUnique()

                    entity.Property(Function(e) e.Id).
                        HasColumnType("counter").
                        HasColumnName("ID")
                    entity.Property(Function(e) e.AngleCalibration).HasColumnName("Angle Calibration")
                    entity.Property(Function(e) e.AngleResolution).HasColumnName("Angle Resolution")
                    entity.Property(Function(e) e.DepthCalibration).HasColumnName("Depth Calibration")
                    entity.Property(Function(e) e.DepthResolution).HasColumnName("Depth Resolution")
                    entity.Property(Function(e) e.FixedOffset).HasColumnName("Fixed Offset")
                    entity.Property(Function(e) e.HalfProbeDiameter).HasColumnName("HalfProbe Diameter")
                    entity.Property(Function(e) e.Hostname).
                        IsRequired().
                        HasMaxLength(40)
                    entity.Property(Function(e) e.RadiusCalibration).HasColumnName("Radius Calibration")
                    entity.Property(Function(e) e.RadiusOffset).HasColumnName("Radius Offset")
                    entity.Property(Function(e) e.RadiusOffsetL).HasColumnName("Radius Offset L")
                    entity.Property(Function(e) e.RadiusResolution).HasColumnName("Radius Resolution")
                    entity.Property(Function(e) e.ScanIncrement).HasColumnName("Scan Increment")
                    entity.Property(Function(e) e.StationName).
                        HasMaxLength(40).
                        HasColumnName("Station Name")
                End Sub)

            OnModelCreatingPartial(modelBuilder)
        End Sub

        Partial Private Sub OnModelCreatingPartial(modelBuilder As ModelBuilder)
        End Sub
    End Class
End Namespace
