using System;
using System.Collections.Generic;

namespace MesRecettesDbFirst.Models;

public class Recette
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public int SystemeDeMesure { get; set; }

    public int? TemperatureDeCuisson { get; set; }

    public int? TempsDeCuisson { get; set; }

    public string? Instructions { get; set; }

    public int TypeAlimentId { get; set; }

    public int OrigineAlimentId { get; set; }

    public virtual OrigineAliment OrigineAliment { get; set; } = null!;

    public virtual TypeAliment TypeAliment { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
