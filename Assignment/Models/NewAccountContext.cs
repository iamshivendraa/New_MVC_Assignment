using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewProject.Models;

public partial class NewAccountContext : DbContext
{
    public NewAccountContext()
    {
    }

    public NewAccountContext(DbContextOptions<NewAccountContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.ToTable("UserDetail");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
