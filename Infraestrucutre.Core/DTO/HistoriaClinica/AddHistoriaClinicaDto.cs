namespace Infraestrucutre.Core.DTO.HistoriaClinica
{
    public class AddHistoriaClinicaDto
    {

        public string Diagnostico { get; set; } = null!;

        public string Tratamiento { get; set; } = null!;

        public string ResultadoExamenes { get; set; } = null!;

        public int IdPaciente { get; set; }
        public List<int> Medicamentos { get; set; }

        public AddProcedimientoDto Procedimiento { get; set; }
    }
}
