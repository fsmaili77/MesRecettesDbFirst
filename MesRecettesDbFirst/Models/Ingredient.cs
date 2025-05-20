using System;
using System.Collections.Generic;

namespace MesRecettesDbFirst.Models;

public class Ingredient
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public double Quantite { get; set; }

    public int? UniteDeMesureId { get; set; }

    public virtual UniteDeMesure? UniteDeMesure { get; set; }

    public virtual ICollection<Recette> Recettes { get; set; } = new List<Recette>();
}
