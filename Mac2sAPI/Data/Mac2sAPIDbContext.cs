
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mac2sAPI.Data
{
    public class Mac2sAPIDbContext:IdentityDbContext
    {
        public DbSet<Log> Logs { get; set; }
        public DbSet<Mold> Machines { get; set; }
        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StatusGroup> StatusGroups { get; set; }

        public DbSet<Status> Statuss { get; set; }
        public DbSet<LogDuration> LogDurations { get; set; }
        public  DbSet<GaugeParameter> GaugeParameters { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ScheduleParameter> ScheduleParameters { get; set; }
        public virtual DbSet<ActivityReport> ActivityReports { get; set; }
        public virtual DbSet<StatusDuration> StatusDurations { get; set; }
        public virtual DbSet<StatusGroupDuration> StatusGroupDurations { get; set; }

        public virtual DbSet<SensorUnique> SensorUniques { get; set; }
        public virtual DbSet<SensorGlobal> SensorGlobals { get; set; }

        public virtual DbSet<SensorPl> SensorPls { get; set; }


        public Mac2sAPIDbContext(DbContextOptions<Mac2sAPIDbContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
             new IdentityRole
             {
                 Name = "Monitor",
                 NormalizedName = "MONITEUR",
                 Id = "b5a136a0-dc53-4e4e-b5e0-68d10b70fe02"
             },
             new IdentityRole
             {
                 Name = "Administrator",
                 NormalizedName = "ADMINISTRATOR",
                 Id = "d9e1208e-5301-4fc9-8db0-f2562714a991"
             }
         );

            var hasher = new PasswordHasher<ApiUser>();

            modelBuilder.Entity<ApiUser>().HasData(
                new ApiUser
                {
                    Id = "43c38655-9aa0-48b4-aab1-7cd175500f09",
                    Email = "yicheng.yang@ermo-tech.com",
                    NormalizedEmail = "YICHENG.YANG@ERMO-TECH.COM",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    FirstName = "System",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                },
                new ApiUser
                {
                    Id = "5bda2409-9516-4983-90a3-08363427e744",
                    Email = "user@ermo-tech.com",
                    NormalizedEmail = "USER@ERMO-TECH.COM",
                    UserName = "user",
                    NormalizedUserName = "USER",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "d9e1208e-5301-4fc9-8db0-f2562714a991",
                    UserId = "43c38655-9aa0-48b4-aab1-7cd175500f09"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "b5a136a0-dc53-4e4e-b5e0-68d10b70fe02",
                    UserId = "5bda2409-9516-4983-90a3-08363427e744"
                }
            );


            //modelBuilder
            //.Entity<LogDuration>()
            //.Property(t => t.Duration).HasConversion(new TimeSpanToTicksConverter());
            modelBuilder
           .Entity<LogDuration>()
           .ToView(nameof(LogDuration))
            .HasKey(t => t.Id)
            ;

            modelBuilder.Entity<ActivityReport>().ToView(nameof(ActivityReport)).HasNoKey();
            modelBuilder.Entity<StatusDuration>().ToView(nameof(StatusDuration)).HasNoKey();
            modelBuilder.Entity<StatusGroupDuration>().ToView(nameof(StatusGroupDuration)).HasNoKey();

            modelBuilder.Entity<SensorGlobal>().ToView(nameof(SensorGlobal)).HasNoKey();
            modelBuilder.Entity<SensorUnique>().ToView(nameof(SensorUnique)).HasNoKey();
            modelBuilder.Entity<SensorPl>().ToView(nameof(SensorPl)).HasNoKey();


        }
    }
}
