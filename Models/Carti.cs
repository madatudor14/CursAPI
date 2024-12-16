using System;
using System.Collections.Generic;

namespace LibraryProject.Models;

public partial class Carti
{
    public int IdCarte { get; set; }

    public string Titlu { get; set; } = null!;

    public int IdCategorie { get; set; }

    public int IdAutor { get; set; }

    public int? AnPublicare { get; set; }

    public int? NumarPagini { get; set; }

    public int? StocDisponibil { get; set; }

    public virtual Autori IdAutorNavigation { get; set; } = null!;

    public virtual Categorii IdCategorieNavigation { get; set; } = null!;

    public virtual ICollection<Imprumuturi> Imprumuturis { get; set; } = new List<Imprumuturi>();
}
