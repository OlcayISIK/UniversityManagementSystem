using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core;
using UMS.Core.Utils;
using UMS.Data.Entities;
using UMS.Data.Entities.UniversityBoundEntities;

namespace UMS.Data.EF
{
    public partial class Context : DbContext
    {
        public readonly long UniversityId;
        public readonly DateTime Now;
        private readonly string _connectionString;
        private readonly bool _constructedManually = false;
        public Context(string connectionString)
        {
            Now = DateTime.UtcNow;
            _constructedManually = true;
            _connectionString = connectionString;
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var httpContextAccessor = (IHttpContextAccessor)ServiceLocator.ResolveService(typeof(IHttpContextAccessor));
            var claims = ClaimUtils.GetClaims(httpContextAccessor?.HttpContext?.User?.Claims);
            UniversityId = claims.UniversityId;
            Now = DateTime.UtcNow;
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseInstructor> CourseInstructors { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public virtual DbSet<OnlineCourse> OnlineCourses { get; set; }
        public virtual DbSet<OnsiteCourse> OnsiteCourses { get; set; }
        public virtual DbSet<UniversitySocialClub> UniversitySocialClubs { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<StudentGrade> StudentGrades { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_constructedManually)
                optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Owned<MultiString>();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //modelBuilder.Entity<Student>().Property(e => e.Id).ValueGeneratedNever();
            base.OnModelCreating(modelBuilder);
        }
    }
}
