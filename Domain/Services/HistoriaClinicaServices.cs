using Domain.Services.Interfaces;
using Infraestrucutre.Core.DTO.HistoriaClinica;
using Infraestrucutre.Core.Models;
using Infraestrucutre.Core.UnitOfWork.Interface;

namespace Domain.Services
{
    public class HistoriaClinicaServices : IHistoriaClinicaServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public HistoriaClinicaServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public async Task<bool> AddHistoriaClinica(AddHistoriaClinicaDto add)
        {
            bool result = false;

            HistoriaClinica entity = new HistoriaClinica()
            {
                FechaConsulta = DateTime.Now,
                IdPaciente = add.IdPaciente,
                ResultadoExamenes = add.ResultadoExamenes,
                Tratamiento = add.Tratamiento,
                Diagnostico = add.Diagnostico,
                IdProcedimientoNavigation = new Procedimiento()
                {
                    FechaHora = DateTime.Now,
                    IdEspecialista = add.Procedimiento.IdEspecialista,
                    NombreProcedimiento = add.Procedimiento.NombreProcedimiento,
                    Resultado = add.Procedimiento.Resultado
                },

            };

            using (var db = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    _unitOfWork.HistoriaClinicaRepository.Insert(entity);

                    result = await _unitOfWork.Save() > 0;
                    if (result)
                    {
                        var medicamentos = add.Medicamentos.Select(x => new HistoriaMedicamento()
                        {
                            IdHistoria = entity.IdHistoria,
                            IdMedicamento = x
                        });
                        _unitOfWork.HistoriaMedicamentoRepository.Insert(medicamentos);
                        result = await _unitOfWork.Save() > 0;
                    }

                    await db.CommitAsync();
                }
                catch (Exception ex)
                {
                    await db.RollbackAsync();
                    throw;
                }
            }

            return result;
        }
    }
}
