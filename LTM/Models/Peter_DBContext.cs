using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LTM.Models
{
    public partial class Peter_DBContext : DbContext
    {
        public virtual DbSet<SysLicensePlateData> SysLicensePlateData { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUserRank> SysUserRank { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=123.207.253.130;Database=Peter_DB;User=sa;Password=;MultipleActiveResultSets=True");
        //}
        public Peter_DBContext(DbContextOptions<Peter_DBContext> options):base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysLicensePlateData>(entity =>
            {
                entity.ToTable("Sys_LicensePlateData");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Anthunpassuserid).HasColumnName("anthunpassuserid");

                entity.Property(e => e.Authpassdate).HasColumnName("authpassdate");

                entity.Property(e => e.Authpassuserid).HasColumnName("authpassuserid");

                entity.Property(e => e.Authstatus)
                    .HasColumnName("authstatus")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Authunpassdate).HasColumnName("authunpassdate");

                entity.Property(e => e.Createdate).HasColumnName("createdate");

                entity.Property(e => e.Createuserid).HasColumnName("createuserid");

                entity.Property(e => e.Licenseplate)
                    .IsRequired()
                    .HasColumnName("licenseplate")
                    .HasMaxLength(32);

                entity.Property(e => e.Licenseplatetype)
                    .HasColumnName("licenseplatetype")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.ToTable("Sys_User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate).HasColumnName("createdate");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(32);

                entity.Property(e => e.Qqopenid)
                    .HasColumnName("qqopenid")
                    .HasMaxLength(50);

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Useremail)
                    .HasColumnName("useremail")
                    .HasMaxLength(50);

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Userphone)
                    .HasColumnName("userphone")
                    .HasMaxLength(50);

                entity.Property(e => e.Userstatus)
                    .HasColumnName("userstatus")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Wechatopenid)
                    .HasColumnName("wechatopenid")
                    .HasMaxLength(50);

                entity.Property(e => e.Weiboopenid)
                    .HasColumnName("weiboopenid")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SysUserRank>(entity =>
            {
                entity.ToTable("Sys_UserRank");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Anthunpasstimes)
                    .HasColumnName("anthunpasstimes")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Authpasstimes)
                    .HasColumnName("authpasstimes")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Usetimes)
                    .HasColumnName("usetimes")
                    .HasDefaultValueSql("0");
            });
        }
    }
}
