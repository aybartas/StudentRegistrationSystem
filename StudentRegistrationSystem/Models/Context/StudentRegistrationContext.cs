using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using StudentRegistrationSystem.Models;
using StudentRegistrationSystem.Models.Entity;

namespace StudentRegistrationSystem.Models.Context
{
    public class StudentRegistrationContext : DbContext
    {
        public StudentRegistrationContext() : base("StudentRegistrationContext")
        {

            this.Configuration.LazyLoadingEnabled = true;
        }
        
        public DbSet<Department> Departments { get; set; }
   
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<User> Users { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
          //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<User>()
               .HasMany(s => s.Sections)
               .WithMany(c => c.Users)
               .Map(cs =>
               {
                   cs.MapLeftKey("StudentRefId");
                   cs.MapRightKey("SectionRefId");
                   cs.ToTable("Enrollment");
               });
            

        }


    }
}

