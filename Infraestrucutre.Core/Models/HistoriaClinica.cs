using System;
using System.Collections.Generic;

namespace Infraestrucutre.Core.Models;

public partial class HistoriaClinica
{
    public int IdHistoria { get; set; }

    public DateTime FechaConsulta { get; set; }

    public string Diagnostico { get; set; } = null!;

    public string Tratamiento { get; set; } = null!;

    public string ResultadoExamenes { get; set; } = null!;

    public int IdPaciente { get; set; }

    public int IdProcedimiento { get; set; }

    public virtual ICollection<HistoriaMedicamento> HistoriaMedicamentos { get; set; } = new List<HistoriaMedicamento>();

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;

    public virtual Procedimiento IdProcedimientoNavigation { get; set; } = null!;
}
