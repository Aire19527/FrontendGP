using Infraestrucutre.Core.DTO.Transversal.Especialista;
using Infraestrucutre.Core.DTO.Transversal.Estado;
using Infraestrucutre.Core.DTO.Transversal.Genero;

namespace Domain.Services.Interfaces
{
    public interface ITransversalServices
    {
        List<EstadoDto> GetAllEstados();
        List<EspecialistaDto> GetAllEspecialistas();
        List<GeneroDto> GetAllGeneros();
    }
}
