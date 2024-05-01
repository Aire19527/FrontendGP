using Domain.Services.Interfaces;
using Infraestrucutre.Core.DTO.Paciente;
using Infraestrucutre.Core.Models;
using Infraestrucutre.Core.UnitOfWork.Interface;

namespace Domain.Services
{
    public class PacienteServices : IPacienteServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public PacienteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<ConsultPacienteDto> GetAllPaciente()
        {
            var list = _unitOfWork.PacienteRepository.GetAll(x => x.IdGeneroNavigation);

            List<ConsultPacienteDto> pacientes = list.Select(x => new ConsultPacienteDto()
            {
                Apellido = x.Apellido,
                Direccion = x.Direccion,
                FechaNacimiento = x.FechaNacimiento,
                IdGenero = x.IdGenero,
                IdPaciente = x.IdPaciente,
                Nombre = x.Nombre,
                Telefono = x.Telefono,
                Sexo = x.IdGeneroNavigation.Genero1,
                FullName = x.FullName,
                StrFechaNacimiento = CalcularEdad(Convert.ToDateTime(x.FechaNacimiento))

            }).ToList();

            return pacientes;
        }

        private string CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;
            int edadAnos = fechaActual.Year - fechaNacimiento.Year;
            int edadMeses = fechaActual.Month - fechaNacimiento.Month;

            if (fechaActual.Day < fechaNacimiento.Day)
            {
                edadMeses--;
            }

            if (edadMeses < 0)
            {
                edadAnos--;
                edadMeses = 12 + edadMeses;
            }

            if (edadAnos == 0)
            {
                int dias = (fechaActual - fechaNacimiento).Days;
                int meses = (int)(dias / 30.436875); // Promedio de días por mes en un año
                dias -= meses * 30;
                return $"{meses} meses y {dias} días";
            }
            else
            {
                return $"{edadAnos} años y {edadMeses} meses";
            }
        }

        public async Task<bool> AddPaciente(AddPacienteDto add)
        {
            Paciente entity = new Paciente()
            {
                Apellido = add.Apellido,
                Direccion = add.Direccion,
                FechaNacimiento = add.FechaNacimiento,
                IdGenero = add.IdGenero,
                Nombre = add.Nombre,
                Telefono = add.Telefono,
            };

            _unitOfWork.PacienteRepository.Insert(entity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdatePaciente(PacienteDto dto)
        {
            Paciente entity = GetPaciente(dto.IdPaciente);
            entity.Apellido = dto.Apellido;
            entity.Direccion = dto.Direccion;
            entity.FechaNacimiento = dto.FechaNacimiento;
            entity.IdGenero = dto.IdGenero;
            entity.Nombre = dto.Nombre;
            entity.Telefono = dto.Telefono;

            _unitOfWork.PacienteRepository.Update(entity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> DeletePaciente(int idPaciente)
        {
            Paciente entity = GetPaciente(idPaciente);

            _unitOfWork.PacienteRepository.Delete(entity);

            return await _unitOfWork.Save() > 0;
        }

        private Paciente GetPaciente(int idPaciente) => _unitOfWork.PacienteRepository.FirstOrDefault(x => x.IdPaciente == idPaciente);

        #endregion
    }
}
