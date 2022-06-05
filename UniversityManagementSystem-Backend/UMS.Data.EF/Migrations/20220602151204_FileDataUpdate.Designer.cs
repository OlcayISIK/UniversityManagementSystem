﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UMS.Data.EF;

namespace UMS.Data.EF.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220602151204_FileDataUpdate")]
    partial class FileDataUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UMS.Data.Entities.Admin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("UMS.Data.Entities.ChatMessage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("FromUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ToUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ToUserId");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("UMS.Data.Entities.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Administrator")
                        .HasColumnType("int");

                    b.Property<long>("Budget")
                        .HasColumnType("bigint");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("UMS.Data.Entities.ErrorLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExceptionMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExceptionStackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerExceptionMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerExceptionStackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Input")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("MethodName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ErrorLogs");
                });

            modelBuilder.Entity("UMS.Data.Entities.OfficeAssignment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseInstructorId")
                        .HasColumnType("int");

                    b.Property<long?>("CourseInstructorId1")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Timestamp")
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseInstructorId1");

                    b.ToTable("OfficeAssignments");
                });

            modelBuilder.Entity("UMS.Data.Entities.OnlineCourse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OnlineCourses");
                });

            modelBuilder.Entity("UMS.Data.Entities.OnsiteCourse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Days")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("OnsiteCourses");
                });

            modelBuilder.Entity("UMS.Data.Entities.StudentGrade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("Grade")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentGrades");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CourseInstructorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("FileId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OnlineCourseId")
                        .HasColumnType("bigint");

                    b.Property<long?>("OnsiteCourseId")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentCourseId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StudentGradeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseInstructorId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("OnlineCourseId")
                        .IsUnique()
                        .HasFilter("[OnlineCourseId] IS NOT NULL");

                    b.HasIndex("OnsiteCourseId")
                        .IsUnique()
                        .HasFilter("[OnsiteCourseId] IS NOT NULL");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.CourseInstructor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UniversitySocialClubId")
                        .HasColumnType("bigint");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UniversitySocialClubId")
                        .IsUnique()
                        .HasFilter("[UniversitySocialClubId] IS NOT NULL");

                    b.ToTable("CourseInstructors");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationHeader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Participants")
                        .HasColumnType("int");

                    b.Property<int>("Quota")
                        .HasColumnType("int");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.Property<long>("UniversitySocialClubId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UniversitySocialClubId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.File", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("DataFiles")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FileType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("FileId")
                        .HasColumnType("bigint");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStudentRepresentative")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("StudentCourseId")
                        .HasColumnType("bigint");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.StudentCourse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.StudentsUniversitySocialClub", b =>
                {
                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long>("UniversitySocialClubId")
                        .HasColumnType("bigint");

                    b.HasKey("StudentId", "UniversitySocialClubId");

                    b.HasIndex("UniversitySocialClubId");

                    b.ToTable("StudentsUniversitySocialClubs");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.University", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.UniversitySocialClub", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AdvisorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UniversitySocialClubs");
                });

            modelBuilder.Entity("UMS.Data.Entities.ChatMessage", b =>
                {
                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.Student", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.Student", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("UMS.Data.Entities.OfficeAssignment", b =>
                {
                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.CourseInstructor", "CourseInstructor")
                        .WithMany()
                        .HasForeignKey("CourseInstructorId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CourseInstructor");
                });

            modelBuilder.Entity("UMS.Data.Entities.StudentGrade", b =>
                {
                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.Course", "Course")
                        .WithMany("StudentGrades")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.Course", b =>
                {
                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.CourseInstructor", "CourseInstructor")
                        .WithMany("Courses")
                        .HasForeignKey("CourseInstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UMS.Data.Entities.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UMS.Data.Entities.OnlineCourse", "OnlineCourse")
                        .WithOne("Course")
                        .HasForeignKey("UMS.Data.Entities.UniversityBoundEntities.Course", "OnlineCourseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UMS.Data.Entities.OnsiteCourse", "OnsiteCourse")
                        .WithOne("Course")
                        .HasForeignKey("UMS.Data.Entities.UniversityBoundEntities.Course", "OnsiteCourseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CourseInstructor");

                    b.Navigation("Department");

                    b.Navigation("OnlineCourse");

                    b.Navigation("OnsiteCourse");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.CourseInstructor", b =>
                {
                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.UniversitySocialClub", "UniversitySocialClub")
                        .WithOne("CourseInstructor")
                        .HasForeignKey("UMS.Data.Entities.UniversityBoundEntities.CourseInstructor", "UniversitySocialClubId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("UniversitySocialClub");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.Event", b =>
                {
                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.UniversitySocialClub", "UniversitySocialClub")
                        .WithMany("Events")
                        .HasForeignKey("UniversitySocialClubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UniversitySocialClub");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.File", b =>
                {
                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.Course", "Course")
                        .WithMany("Files")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.Student", "Student")
                        .WithMany("Files")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.StudentCourse", b =>
                {
                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.StudentsUniversitySocialClub", b =>
                {
                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.Student", "Student")
                        .WithMany("StudentsUniversitySocialClubs")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UMS.Data.Entities.UniversityBoundEntities.UniversitySocialClub", "UniversitySocialClub")
                        .WithMany("StudentsUniversitySocialClubs")
                        .HasForeignKey("UniversitySocialClubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("UniversitySocialClub");
                });

            modelBuilder.Entity("UMS.Data.Entities.Department", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("UMS.Data.Entities.OnlineCourse", b =>
                {
                    b.Navigation("Course");
                });

            modelBuilder.Entity("UMS.Data.Entities.OnsiteCourse", b =>
                {
                    b.Navigation("Course");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.Course", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("StudentCourses");

                    b.Navigation("StudentGrades");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.CourseInstructor", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.Student", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("StudentCourses");

                    b.Navigation("StudentsUniversitySocialClubs");
                });

            modelBuilder.Entity("UMS.Data.Entities.UniversityBoundEntities.UniversitySocialClub", b =>
                {
                    b.Navigation("CourseInstructor");

                    b.Navigation("Events");

                    b.Navigation("StudentsUniversitySocialClubs");
                });
#pragma warning restore 612, 618
        }
    }
}
