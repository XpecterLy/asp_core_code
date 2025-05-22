using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TeamTask.Domain.Models;

public partial class DbTeamTaskContext : DbContext
{
    public DbTeamTaskContext()
    {
    }

    public DbTeamTaskContext(DbContextOptions<DbTeamTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DtTask> DtTasks { get; set; }

    public virtual DbSet<DtTaskList> DtTaskLists { get; set; }

    public virtual DbSet<DtUser> DtUsers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DtTask>(entity =>
        {
            entity.ToTable("dt_task");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(560)
                .HasColumnName("descripcion");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("due_date");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.TaskListId).HasColumnName("task_list_Id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(60)
                .HasColumnName("titulo");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.TaskList).WithMany(p => p.DtTasks)
                .HasForeignKey(d => d.TaskListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dt_task_dt_task_list");
        });

        modelBuilder.Entity<DtTaskList>(entity =>
        {
            entity.ToTable("dt_task_list");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserNit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_nit");

            entity.HasOne(d => d.UserNitNavigation).WithMany(p => p.DtTaskLists)
                .HasForeignKey(d => d.UserNit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dt_task_list_dt_user");
        });

        modelBuilder.Entity<DtUser>(entity =>
        {
            entity.HasKey(e => e.Nit);

            entity.ToTable("dt_user");

            entity.Property(e => e.Nit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("nit");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(150)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(60)
                .HasColumnName("user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
