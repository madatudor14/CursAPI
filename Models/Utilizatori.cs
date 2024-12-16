using System;
using System.Collections.Generic;

namespace LibraryProject.Models;

public partial class Utilizatori
{
    public int IdUtilizator { get; set; }

    public string NumeUtilizator { get; set; } = null!;

    public string PrenumeUtilizator { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefon { get; set; }

    public DateOnly? DataInregistrare { get; set; }

    public virtual ICollection<Imprumuturi> Imprumuturis { get; set; } = new List<Imprumuturi>();
}
