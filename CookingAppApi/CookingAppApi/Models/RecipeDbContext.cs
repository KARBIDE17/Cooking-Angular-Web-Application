using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CookingAppApi.Models;

public partial class RecipeDbContext : DbContext
{
    public RecipeDbContext()
    {
    }

    public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Instruction> Instructions { get; set; }

    public virtual DbSet<Nutrition> Nutritions { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<FavoriteRecipe> FavoriteRecipe { get; set; } 

    string connectionString = Secret.ConnectionString;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Component>(entity =>
        {
            entity.HasKey(e => e.ComponentId).HasName("PK__Componen__D79CF04E7C3963A0");

            entity.Property(e => e.ComponentId).ValueGeneratedNever();

            entity.HasOne(d => d.Ingredient).WithMany(p => p.Components)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("FK__Component__Ingre__5BE2A6F2");

            entity.HasOne(d => d.Section).WithMany(p => p.Components)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK__Component__Secti__5AEE82B9");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("PK__Favorite__876A64D51DA25EA5");

            entity.Property(e => e.FavoriteId).HasColumnName("favoriteId");
            entity.Property(e => e.FavoriteDescription).HasColumnName("favoriteDescription");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__Favorites__Recip__656C112C");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Favorites__userI__6477ECF3");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PK__Ingredie__BEAEB25A520EA72B");

            entity.Property(e => e.IngredientId).ValueGeneratedNever();
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Recipe).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__Ingredien__Recip__5535A963");
        });

        modelBuilder.Entity<Instruction>(entity =>
        {
            entity.HasKey(e => e.InstructionId).HasName("PK__Instruct__CE069471EE3B9216");

            entity.Property(e => e.InstructionId).ValueGeneratedNever();

            entity.HasOne(d => d.Recipe).WithMany(p => p.Instructions)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__Instructi__Recip__52593CB8");
        });

        modelBuilder.Entity<Nutrition>(entity =>
        {
            entity.HasKey(e => e.NutritionId).HasName("PK__Nutritio__8A74A056E1999BA2");

            entity.ToTable("Nutrition");

            entity.Property(e => e.NutritionId).ValueGeneratedNever();
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Nutritions)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__Nutrition__Recip__4F7CD00D");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__Recipes__FDD988B06C86C8E3");

            entity.Property(e => e.RecipeId).ValueGeneratedNever();
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Yields).HasMaxLength(100);
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Sections__80EF08720BF0F213");

            entity.Property(e => e.SectionId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Recipe).WithMany(p => p.Sections)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__Sections__Recipe__5812160E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CDF175418F0");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .HasColumnName("userEmail");
            entity.Property(e => e.UserName)
                .HasMaxLength(40)
                .HasColumnName("userName");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(20)
                .HasColumnName("userPassword");
            entity.Property(e => e.UserPhone)
                .HasMaxLength(50)
                .HasColumnName("userPhone");
        });

        modelBuilder.Entity<FavoriteRecipe>(f =>
        {
            f.HasNoKey();
            f.ToView("FavoriteRecipe");
         });
       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
