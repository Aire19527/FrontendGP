using System;
using System.Collections.Generic;

namespace Infraestrucutre.Core.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string Estado1 { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<CitaMedica> CitaMedicas { get; set; } = new List<CitaMedica>();
}
