using Infraestrucutre.Core.DTO.HistoriaClinica;

namespace Domain.Services.Interfaces
{
    public interface IHistoriaClinicaServices
    {
        Task<bool> AddHistoriaClinica(AddHistoriaClinicaDto add);
    }
}
