using System;
using System.Collections.Generic;

namespace Infraestrucutre.Core.Models;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string Genero1 { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
