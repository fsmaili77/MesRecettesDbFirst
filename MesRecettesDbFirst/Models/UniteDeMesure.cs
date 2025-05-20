using System;
using System.Collections.Generic;

namespace MesRecettesDbFirst.Models;

public class UniteDeMesure
{
    public int Id { get; set; }

    public int SystemeDeMesure { get; set; }

    public string? Nom { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
