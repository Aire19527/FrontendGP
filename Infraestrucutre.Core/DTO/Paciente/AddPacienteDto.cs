namespace Infraestrucutre.Core.DTO.Paciente
{
    public class AddPacienteDto
    {
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }        

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public int IdGenero { get; set; }
    }
}
