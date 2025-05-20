using System;
using System.Collections.Generic;

namespace MesRecettesDbFirst.Models;

public class TypeAliment
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public virtual ICollection<Recette> Recettes { get; set; } = new List<Recette>();
}
