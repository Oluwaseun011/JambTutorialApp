using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {}
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<StudentExamType> StudentExamTypes {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var user = new User
            {
                Id = Guid.Parse("048AC838-B778-47A3-B85F-AF54C30ECD09"),
                UserName = "admin@yopmaail.com",
                Salt = $"D4FD88A6-3544-47A0-A3D8-04D9DC1F3B08",
                Role = "Admin"
            };
            var pass = $"{user.Salt}admin123";
            user.HashPassword = new PasswordHasher<User>().HashPassword(user,pass);
            modelBuilder.Entity<User>().HasData(user);

        }
    }
    
}
