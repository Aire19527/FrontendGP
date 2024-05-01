namespace Infraestrucutre.Core.DTO.CitaMedica
{
    public class ConsultCitaMedicaDto : CitaMedicaDto
    {
        public string Paciente { get; set; }
        public string Especialista { get; set; }
        public string Estado { get; set; }
        public string StrFecha { get; set; }
    }
}
