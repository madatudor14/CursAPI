using System;
using System.Collections.Generic;

namespace LibraryProject.Models;

public partial class Imprumuturi
{
    public int IdImprumut { get; set; }

    public int IdCarte { get; set; }

    public int IdUtilizator { get; set; }

    public DateOnly DataImprumut { get; set; }

    public DateOnly? DataReturnare { get; set; }

    public string? Status { get; set; }

    public virtual Carti IdCarteNavigation { get; set; } = null!;

    public virtual Utilizatori IdUtilizatorNavigation { get; set; } = null!;
}
