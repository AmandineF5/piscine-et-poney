﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PiscineEtPoney.Infrastructure.Persistence;

#nullable disable

namespace PiscineEtPoney.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Schedule")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.ChildActivity", b =>
                {
                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.HasKey("ChildId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.ToTable("ChildActivity");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.ChildPickupLocation", b =>
                {
                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("PickupLocationId")
                        .HasColumnType("int");

                    b.HasKey("ChildId", "PickupLocationId");

                    b.HasIndex("PickupLocationId");

                    b.ToTable("ChildPickupLocation");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.ParentChild", b =>
                {
                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.HasKey("ParentId", "ChildId");

                    b.HasIndex("ChildId");

                    b.ToTable("ParentChildren");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.PickupLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PickupLocation");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("ParentId");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.TransportChild", b =>
                {
                    b.Property<int>("TransportId")
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.HasKey("TransportId", "ChildId");

                    b.HasIndex("ChildId");

                    b.ToTable("TransportChild");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.ChildActivity", b =>
                {
                    b.HasOne("PiscineEtPoney.Domain.Entities.Activity", "Activity")
                        .WithMany("ChildActivities")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiscineEtPoney.Domain.Entities.Child", "Child")
                        .WithMany("ChildActivities")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Child");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.ChildPickupLocation", b =>
                {
                    b.HasOne("PiscineEtPoney.Domain.Entities.Child", "Child")
                        .WithMany("ChildPickupLocations")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiscineEtPoney.Domain.Entities.PickupLocation", "PickupLocation")
                        .WithMany("ChildPickupLocations")
                        .HasForeignKey("PickupLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("PickupLocation");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.ParentChild", b =>
                {
                    b.HasOne("PiscineEtPoney.Domain.Entities.Child", "Child")
                        .WithMany("ParentChildren")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiscineEtPoney.Domain.Entities.Parent", "Parent")
                        .WithMany("ParentChildren")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.Transport", b =>
                {
                    b.HasOne("PiscineEtPoney.Domain.Entities.Activity", "Activity")
                        .WithMany("Transports")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PiscineEtPoney.Domain.Entities.Parent", "Parent")
                        .WithMany("Transports")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.TransportChild", b =>
                {
                    b.HasOne("PiscineEtPoney.Domain.Entities.Child", "Child")
                        .WithMany("TransportChildren")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiscineEtPoney.Domain.Entities.Transport", "Transport")
                        .WithMany("TransportChildren")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.Activity", b =>
                {
                    b.Navigation("ChildActivities");

                    b.Navigation("Transports");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.Child", b =>
                {
                    b.Navigation("ChildActivities");

                    b.Navigation("ChildPickupLocations");

                    b.Navigation("ParentChildren");

                    b.Navigation("TransportChildren");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.Parent", b =>
                {
                    b.Navigation("ParentChildren");

                    b.Navigation("Transports");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.PickupLocation", b =>
                {
                    b.Navigation("ChildPickupLocations");
                });

            modelBuilder.Entity("PiscineEtPoney.Domain.Entities.Transport", b =>
                {
                    b.Navigation("TransportChildren");
                });
#pragma warning restore 612, 618
        }
    }
}
