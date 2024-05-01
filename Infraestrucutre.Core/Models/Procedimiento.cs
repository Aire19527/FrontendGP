using System;
using System.Collections.Generic;

namespace Infraestrucutre.Core.Models;

public partial class Procedimiento
{
    public int IdProcedimiento { get; set; }

    public string NombreProcedimiento { get; set; } = null!;

    public DateTime FechaHora { get; set; }

    public int IdEspecialista { get; set; }

    public string Resultado { get; set; } = null!;

    public virtual ICollection<HistoriaClinica> HistoriaClinicas { get; set; } = new List<HistoriaClinica>();

    public virtual EspecialistaModel IdEspecialistaNavigation { get; set; } = null!;
}
