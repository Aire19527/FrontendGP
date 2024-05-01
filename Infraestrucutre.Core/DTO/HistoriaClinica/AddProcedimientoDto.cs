namespace Infraestrucutre.Core.DTO.HistoriaClinica
{
    public class AddProcedimientoDto
    {
        public string NombreProcedimiento { get; set; } = null!;

        public int IdEspecialista { get; set; }

        public string Resultado { get; set; } = null!;
    }
}
