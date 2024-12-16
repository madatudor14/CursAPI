using System;
using System.Collections.Generic;

namespace LibraryProject.Models;

public partial class Autori
{
    public int IdAutor { get; set; }

    public string NumeAutor { get; set; } = null!;

    public string PrenumeAutor { get; set; } = null!;

    public virtual ICollection<Carti> Cartis { get; set; } = new List<Carti>();
}
