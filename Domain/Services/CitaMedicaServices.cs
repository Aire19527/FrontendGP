using Domain.Services.Interfaces;
using Infraestrucutre.Core.DTO.CitaMedica;
using Infraestrucutre.Core.Models;
using Infraestrucutre.Core.UnitOfWork.Interface;

namespace Domain.Services
{
    public class CitaMedicaServices : ICitaMedicaServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public CitaMedicaServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<ConsultCitaMedicaDto> GetAllCitaMedica()
        {
            var list = _unitOfWork.CitaMedicaRepository.GetAll(x => x.IdEspecialistaNavigation,
                                                               p => p.IdPacienteNavigation,
                                                               e => e.IdEstadoNavigation);

            List<ConsultCitaMedicaDto> pacientes = list.Select(x => new ConsultCitaMedicaDto()
            {
                IdEstado = x.IdEstado,
                IdEspecialista = x.IdEspecialista,
                FechaHora = x.FechaHora,
                IdPaciente = x.IdPaciente,
                Observaciones = x.Observaciones,
                IdCita = x.IdCita,
                Estado = x.IdEstadoNavigation.Estado1,
                Paciente = x.IdPacienteNavigation.FullName,
                Especialista = x.IdEspecialistaNavigation.NombreEspecialista,
                StrFecha = x.FechaHora.ToString("dd/MM/yyyy HH:mm")

            }).ToList();

            return pacientes;
        }

        public async Task<bool> AddCitaMedica(AddCitaMedicaDto add)
        {
            CitaMedica entity = new CitaMedica()
            {
                IdEstado = 1,
                IdEspecialista = add.IdEspecialista,
                FechaHora = add.FechaHora,
                IdPaciente = add.IdPaciente,
                Observaciones = add.Observaciones,
            };

            _unitOfWork.CitaMedicaRepository.Insert(entity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateCitaMedica(CitaMedicaDto dto)
        {
            CitaMedica entity = GetCitaMedica(dto.IdCita);
            entity.IdEstado = dto.IdEstado;
            entity.IdEspecialista = dto.IdEspecialista;
            entity.FechaHora = dto.FechaHora;
            entity.IdPaciente = dto.IdPaciente;
            entity.Observaciones = dto.Observaciones;

            _unitOfWork.CitaMedicaRepository.Update(entity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> DeleteCitaMedica(int idCitaMedica)
        {
            CitaMedica entity = GetCitaMedica(idCitaMedica);

            _unitOfWork.CitaMedicaRepository.Delete(entity);

            return await _unitOfWork.Save() > 0;
        }

        private CitaMedica GetCitaMedica(int idCitaMedica) => _unitOfWork.CitaMedicaRepository.FirstOrDefault(x => x.IdCita == idCitaMedica);

        #endregion
    }
}
