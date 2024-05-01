using Infraestrucutre.Core.DTO.CitaMedica;

namespace Domain.Services.Interfaces
{
    public interface ICitaMedicaServices
    {
        List<ConsultCitaMedicaDto> GetAllCitaMedica();
        Task<bool> AddCitaMedica(AddCitaMedicaDto add);
        Task<bool> UpdateCitaMedica(CitaMedicaDto dto);
        Task<bool> DeleteCitaMedica(int idCitaMedica);
    }
}
