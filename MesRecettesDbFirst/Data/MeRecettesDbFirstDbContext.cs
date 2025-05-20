using System;
using System.Collections.Generic;
using MesRecettesDbFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace MesRecettesDbFirst.Data;

public partial class MeRecettesDbFirstDbContext : DbContext
{
    public MeRecettesDbFirstDbContext()
    {
    }

    public MeRecettesDbFirstDbContext(DbContextOptions<MeRecettesDbFirstDbContext> options)
        : base(options)
    {
    }    

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<OrigineAliment> OrigineAliments { get; set; }

    public virtual DbSet<Recette> Recettes { get; set; }

    public virtual DbSet<TypeAliment> TypeAliments { get; set; }

    public virtual DbSet<UniteDeMesure> UniteDeMesures { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasIndex(e => e.UniteDeMesureId, "IX_Ingredients_UniteDeMesureId");

            entity.HasOne(d => d.UniteDeMesure).WithMany(p => p.Ingredients).HasForeignKey(d => d.UniteDeMesureId);
        });

        modelBuilder.Entity<Recette>(entity =>
        {
            entity.HasIndex(e => e.OrigineAlimentId, "IX_Recettes_OrigineAlimentId");

            entity.HasIndex(e => e.TypeAlimentId, "IX_Recettes_TypeAlimentId");

            entity.HasOne(d => d.OrigineAliment).WithMany(p => p.Recettes).HasForeignKey(d => d.OrigineAlimentId);

            entity.HasOne(d => d.TypeAliment).WithMany(p => p.Recettes).HasForeignKey(d => d.TypeAlimentId);

            entity.HasMany(d => d.Ingredients).WithMany(p => p.Recettes)
                .UsingEntity<Dictionary<string, object>>(
                    "IngredientRecette",
                    r => r.HasOne<Ingredient>().WithMany().HasForeignKey("IngredientId"),
                    l => l.HasOne<Recette>().WithMany().HasForeignKey("RecetteId"),
                    j =>
                    {
                        j.HasKey("RecetteId", "IngredientId");
                        j.ToTable("IngredientRecettes");
                        j.HasIndex(new[] { "IngredientId" }, "IX_IngredientRecettes_IngredientId");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
