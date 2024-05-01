using Infraestrucutre.Core.DTO.Paciente;

namespace Domain.Services.Interfaces
{
    public interface IPacienteServices
    {
        List<ConsultPacienteDto> GetAllPaciente();
        Task<bool> AddPaciente(AddPacienteDto add);
        Task<bool> UpdatePaciente(PacienteDto dto);
        Task<bool> DeletePaciente(int idPaciente);
    }
}
