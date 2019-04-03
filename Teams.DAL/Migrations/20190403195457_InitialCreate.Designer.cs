﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teams.DAL;

namespace Teams.DAL.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190403195457_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Teams.DAL.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<Guid?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Teams.DAL.Entities.GroupUserPermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GroupId");

                    b.Property<Guid?>("MemberId");

                    b.Property<int>("Permit");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("MemberId");

                    b.ToTable("GroupsUserPermissions");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Media", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GroupId");

                    b.Property<Guid?>("MemberId");

                    b.Property<Guid?>("ParentId");

                    b.Property<string>("Text");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("MemberId");

                    b.HasIndex("ParentId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GroupId");

                    b.Property<Guid?>("MemberId");

                    b.Property<int>("State");

                    b.Property<string>("Text");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("MemberId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Teams.DAL.Entities.TaskAssignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("MemberId");

                    b.Property<Guid?>("TaskId");

                    b.Property<Guid?>("TaskStateChangeId");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("TaskId");

                    b.HasIndex("TaskStateChangeId");

                    b.ToTable("TaskAssignments");
                });

            modelBuilder.Entity("Teams.DAL.Entities.TaskStateChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GroupId");

                    b.Property<Guid?>("MemberId");

                    b.Property<int>("State");

                    b.Property<Guid?>("TaskId");

                    b.Property<string>("Text");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("MemberId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskStateChange");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Teams.DAL.Entities.TeamMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("MemberId");

                    b.Property<Guid?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMember");
                });

            modelBuilder.Entity("Teams.DAL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Image");

                    b.Property<DateTime>("LastLogin");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<Guid?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Group", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.GroupUserPermission", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Group", "Group")
                        .WithMany("GroupUserPermissions")
                        .HasForeignKey("GroupId");

                    b.HasOne("Teams.DAL.Entities.User", "Member")
                        .WithMany("GroupUserPermissions")
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Media", b =>
                {
                    b.HasOne("Teams.DAL.Entities.User")
                        .WithMany("MediaEntities")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Message", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("Teams.DAL.Entities.User", "Member")
                        .WithMany("Messages")
                        .HasForeignKey("MemberId");

                    b.HasOne("Teams.DAL.Entities.Message", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Task", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("Teams.DAL.Entities.User", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.TaskAssignment", b =>
                {
                    b.HasOne("Teams.DAL.Entities.User", "Member")
                        .WithMany("Tasks")
                        .HasForeignKey("MemberId");

                    b.HasOne("Teams.DAL.Entities.Task", "Task")
                        .WithMany("TaskAssignments")
                        .HasForeignKey("TaskId");

                    b.HasOne("Teams.DAL.Entities.TaskStateChange")
                        .WithMany("TaskAssignments")
                        .HasForeignKey("TaskStateChangeId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.TaskStateChange", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("Teams.DAL.Entities.User", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.HasOne("Teams.DAL.Entities.Task")
                        .WithMany("TaskStateChanges")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.TeamMember", b =>
                {
                    b.HasOne("Teams.DAL.Entities.User", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.HasOne("Teams.DAL.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.User", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId");
                });
#pragma warning restore 612, 618
        }
    }
}
