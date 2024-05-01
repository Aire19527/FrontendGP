using Infraestrucutre.Core.DTO.Medicamentos;

namespace Domain.Services.Interfaces
{
    public interface IMedicamentoServices
    {
        List<MedicamentosDto> GetAllMedicamentos();

        Task<bool> AddMedicamentos(AddMedicamentosDto add);

        Task<bool> UpdateMedicamento(MedicamentosDto dto);

        Task<bool> DeleteMedicamento(int idMedicamento);
    }
}
