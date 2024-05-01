using System;
using System.Collections.Generic;

namespace Infraestrucutre.Core.Models;

public partial class CitaMedica
{
    public int IdCita { get; set; }

    public DateTime FechaHora { get; set; }

    public int IdEspecialista { get; set; }

    public string Observaciones { get; set; } = null!;

    public int IdEstado { get; set; }

    public int IdPaciente { get; set; }

    public virtual EspecialistaModel IdEspecialistaNavigation { get; set; } = null!;

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
