using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestrucutre.Core.Models;

public partial class EspecialistaModel
{
    public int IdEspecialista { get; set; }

    public string Especialista { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    [NotMapped]
    public string NombreEspecialista { get { return $"{Especialista} - {NombreCompleto} "; } }
    public virtual ICollection<CitaMedica> CitaMedicas { get; set; } = new List<CitaMedica>();

    public virtual ICollection<Procedimiento> Procedimientos { get; set; } = new List<Procedimiento>();
}
