using System;
using System.Collections.Generic;

namespace Infraestrucutre.Core.Models;

public partial class HistoriaMedicamento
{
    public int Id { get; set; }

    public int IdMedicamento { get; set; }

    public int IdHistoria { get; set; }

    public virtual HistoriaClinica IdHistoriaNavigation { get; set; } = null!;

    public virtual Medicamento IdMedicamentoNavigation { get; set; } = null!;
}
