﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceSphere.repositery.Data;

#nullable disable

namespace ServiceSphere.repositery.Data.Migrations
{
    [DbContext(typeof(ServiceSphereContext))]
    [Migration("20240219234344_updateService")]
    partial class updateService
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CategoryFreelancer", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<string>("FreelancersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoriesId", "FreelancersId");

                    b.HasIndex("FreelancersId");

                    b.ToTable("CategoryFreelancer");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Agreements.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProposalId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Terms")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProposalId")
                        .IsUnique();

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Agreements.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Availability")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverLetter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Inquiries")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<string>("Milestones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectPostingId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProposedBudget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProposedTimeframe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServicePostingId")
                        .HasColumnType("int");

                    b.Property<string>("WorkPlan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPostingId");

                    b.HasIndex("ServicePostingId");

                    b.ToTable("Proposals");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Assessments.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FreelancerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("FreelancerId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Assessments.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FreelancerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("FreelancerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Identity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUser");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppUser");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Posting.ProjectPosting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClientId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("ProjectPostings");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Posting.ServicePosting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClientId");

                    b.ToTable("ServicePostings");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Services.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Services.ProjectSubCategory", b =>
                {
                    b.Property<int>("ProjectPostingId")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TeamMembersRequired")
                        .HasColumnType("int");

                    b.HasKey("ProjectPostingId", "SubCategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("ProjectSubCategory");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Services.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FreelancerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FreelancerId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Services.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Users.Freelancer.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProjectPostingId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPostingId")
                        .IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Users.Client", b =>
                {
                    b.HasBaseType("ServiceSphere.core.Entities.Identity.AppUser");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleAccount")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Users.Freelancer.Freelancer", b =>
                {
                    b.HasBaseType("ServiceSphere.core.Entities.Identity.AppUser");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Freelancer_Bio");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleAccount")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<string>("WorkStyle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("experienceLevel")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Freelancer");
                });

            modelBuilder.Entity("CategoryFreelancer", b =>
                {
                    b.HasOne("ServiceSphere.core.Entities.Services.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceSphere.core.Entities.Users.Freelancer.Freelancer", null)
                        .WithMany()
                        .HasForeignKey("FreelancersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Agreements.Contract", b =>
                {
                    b.HasOne("ServiceSphere.core.Entities.Users.Client", "Client")
                        .WithMany("Contracts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ServiceSphere.core.Entities.Agreements.Proposal", "Proposal")
                        .WithOne("Contract")
                        .HasForeignKey("ServiceSphere.core.Entities.Agreements.Contract", "ProposalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Proposal");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Agreements.Proposal", b =>
                {
                    b.HasOne("ServiceSphere.core.Entities.Posting.ProjectPosting", "ProjectPosting")
                        .WithMany("Proposals")
                        .HasForeignKey("ProjectPostingId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ServiceSphere.core.Entities.Posting.ServicePosting", "ServicePosting")
                        .WithMany("Proposals")
                        .HasForeignKey("ServicePostingId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ProjectPosting");

                    b.Navigation("ServicePosting");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Assessments.Notification", b =>
                {
                    b.HasOne("ServiceSphere.core.Entities.Users.Client", null)
                        .WithMany("Notifications")
                        .HasForeignKey("ClientId");

                    b.HasOne("ServiceSphere.core.Entities.Users.Freelancer.Freelancer", null)
                        .WithMany("Notifications")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Assessments.Review", b =>
                {
                    b.HasOne("ServiceSphere.core.Entities.Users.Client", null)
                        .WithMany("Reviews")
                        .HasForeignKey("ClientId");

                    b.HasOne("ServiceSphere.core.Entities.Users.Freelancer.Freelancer", null)
                        .WithMany("Reviews")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Identity.Address", b =>
                {
                    b.HasOne("ServiceSphere.core.Entities.Identity.AppUser", "User")
                        .WithOne("Address")
                        .HasForeignKey("ServiceSphere.core.Entities.Identity.Address", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Posting.ProjectPosting", b =>
                {
                    b.HasOne("ServiceSphere.core.Entities.Services.Category", "Category")
                        .WithMany("ProjectPostings")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceSphere.core.Entities.Users.Client", null)
                        .WithMany("ProjectPostings")
                        .HasForeignKey("ClientId");

                    b.HasOne("ServiceSphere.core.Entities.Services.SubCategory", null)
                        .WithMany("ProjectPostings")
                        .HasForeignKey("SubCategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Posting.ServicePosting", b =>
                {
                    b.HasOne("ServiceSphere.core.Entities.Services.Category", "Category")
                        .WithMany("ServicePostings")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceSphere.core.Entities.Users.Client", null)
                        .WithMany("ServicePostings")
                        .HasForeignKey("ClientId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Services.ProjectSubCategory", b =>
                {
                    b.HasOne("ServiceSphere.core.Entities.Posting.ProjectPosting", "ProjectPosting")
                        .WithMany("ProjectSubCategories")
                        .HasForeignKey("ProjectPostingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceSphere.core.Entities.Services.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProjectPosting");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Services.Service", b =>
                {
                    b.HasOne("ServiceSphere.core.Entities.Services.Category", "Category")
                        .WithMany("Services")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceSphere.core.Entities.Users.Freelancer.Freelancer", null)
                        .WithMany("Services")
                        .HasForeignKey("FreelancerId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Services.SubCategory", b =>
                {
                    b.HasOne("ServiceSphere.core.Entities.Services.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Users.Freelancer.Team", b =>
                {
                    b.HasOne("ServiceSphere.core.Entities.Posting.ProjectPosting", "ProjectPosting")
                        .WithOne("Team")
                        .HasForeignKey("ServiceSphere.core.Entities.Users.Freelancer.Team", "ProjectPostingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectPosting");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Agreements.Proposal", b =>
                {
                    b.Navigation("Contract")
                        .IsRequired();
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Identity.AppUser", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Posting.ProjectPosting", b =>
                {
                    b.Navigation("ProjectSubCategories");

                    b.Navigation("Proposals");

                    b.Navigation("Team")
                        .IsRequired();
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Posting.ServicePosting", b =>
                {
                    b.Navigation("Proposals");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Services.Category", b =>
                {
                    b.Navigation("ProjectPostings");

                    b.Navigation("ServicePostings");

                    b.Navigation("Services");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Services.SubCategory", b =>
                {
                    b.Navigation("ProjectPostings");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Users.Client", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("Notifications");

                    b.Navigation("ProjectPostings");

                    b.Navigation("Reviews");

                    b.Navigation("ServicePostings");
                });

            modelBuilder.Entity("ServiceSphere.core.Entities.Users.Freelancer.Freelancer", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Reviews");

                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
