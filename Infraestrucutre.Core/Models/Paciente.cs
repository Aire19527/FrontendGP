using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestrucutre.Core.Models;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public int IdGenero { get; set; }

    public virtual ICollection<CitaMedica> CitaMedicas { get; set; } = new List<CitaMedica>();

    public virtual ICollection<HistoriaClinica> HistoriaClinicas { get; set; } = new List<HistoriaClinica>();

    public virtual Genero IdGeneroNavigation { get; set; } = null!;

    [NotMapped]
    public string FullName { get { return $"{this.Nombre} {this.Apellido}"; } }
}
