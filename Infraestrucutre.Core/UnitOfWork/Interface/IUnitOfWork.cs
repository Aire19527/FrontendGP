using Infraestrucutre.Core.Models;
using Infraestrucutre.Core.Repository.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infraestrucutre.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Paciente> PacienteRepository { get; }
        IRepository<Medicamento> MedicamentoRepository { get; }
        IRepository<EspecialistaModel> EspecialistaRepository { get; }
        IRepository<CitaMedica> CitaMedicaRepository { get; }
        IRepository<Estado> EstadoRepository { get; }
        IRepository<Genero> GeneroRepository { get; }
        IRepository<HistoriaClinica> HistoriaClinicaRepository { get; }
        IRepository<HistoriaMedicamento> HistoriaMedicamentoRepository { get; }
        IRepository<Procedimiento> ProcedimientoRepository { get; }


        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<int> Save();
    }

}
