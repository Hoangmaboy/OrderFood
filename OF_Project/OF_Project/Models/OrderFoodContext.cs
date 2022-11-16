using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OF_Project.Models;

public partial class OrderFoodContext : DbContext
{
    public OrderFoodContext()
    {
    }

    public OrderFoodContext(DbContextOptions<OrderFoodContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    //        optionsBuilder.UseSqlServer(config.GetConnectionString("APConStr"));
    //    }
    //}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string constr = config.GetConnectionString("APConStr");
            optionsBuilder.UseSqlServer(constr);
        }
    }

    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    // => optionsBuilder.UseSqlServer("server =DESKTOP-211LKEJ; database = OrderFood;uid=Hoang;pwd=1234;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.ToTable("Category");

            entity.Property(e => e.TypeId)
                .ValueGeneratedNever()
                .HasColumnName("TypeID");
            entity.Property(e => e.NameCategory).HasMaxLength(50);
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.ToTable("Food");

            entity.Property(e => e.TypeId)
                .ValueGeneratedNever()
                .HasColumnName("TypeID");
            entity.Property(e => e.Detail).HasColumnName("detail");
            entity.Property(e => e.Img).HasColumnName("img");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
