namespace Infraestrucutre.Core.DTO.CitaMedica
{
    public class AddCitaMedicaDto
    {
        public DateTime FechaHora { get; set; }

        public int IdEspecialista { get; set; }

        public string Observaciones { get; set; } = null!;

        public int IdEstado { get; set; }

        public int IdPaciente { get; set; }
    }
}
