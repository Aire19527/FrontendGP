using System;
using System.Collections.Generic;

namespace Infraestrucutre.Core.Models;

public partial class Medicamento
{
    public int IdMedicamento { get; set; }

    public string Nombre { get; set; }

    public string Dosis { get; set; }

    public int Cantidad { get; set; }


    public virtual ICollection<HistoriaMedicamento> HistoriaMedicamentos { get; set; } = new List<HistoriaMedicamento>();
}
