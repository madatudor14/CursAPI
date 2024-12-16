using System;
using System.Collections.Generic;

namespace LibraryProject.Models;

public partial class Categorii
{
    public int IdCategorie { get; set; }

    public string NumeCategorie { get; set; } = null!;

    public virtual ICollection<Carti> Cartis { get; set; } = new List<Carti>();
}
