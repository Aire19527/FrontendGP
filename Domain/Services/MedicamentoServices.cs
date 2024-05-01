using Domain.Services.Interfaces;
using Infraestrucutre.Core.DTO.Medicamentos;
using Infraestrucutre.Core.Models;
using Infraestrucutre.Core.UnitOfWork.Interface;

namespace Domain.Services
{
    public class MedicamentoServices : IMedicamentoServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public MedicamentoServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public List<MedicamentosDto> GetAllMedicamentos()
        {
            var list = _unitOfWork.MedicamentoRepository.GetAll();

            List<MedicamentosDto> medicamentos = list.Select(x => new MedicamentosDto()
            {
                Dosis = x.Dosis,
                Cantidad = x.Cantidad,
                IdMedicamento = x.IdMedicamento,
                Nombre = x.Nombre
            }).ToList();

            return medicamentos;
        }

        public async Task<bool> AddMedicamentos(AddMedicamentosDto add)
        {
            Medicamento entity = new Medicamento()
            {
                Dosis = add.Dosis,
                Cantidad = add.Cantidad,
                Nombre = add.Nombre
            };

            _unitOfWork.MedicamentoRepository.Insert(entity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateMedicamento(MedicamentosDto dto)
        {
            Medicamento entity = GetMedicamento(dto.IdMedicamento);
            entity.Dosis = dto.Dosis;
            entity.Cantidad = dto.Cantidad;
            entity.Nombre = dto.Nombre;

            _unitOfWork.MedicamentoRepository.Update(entity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> DeleteMedicamento(int idMedicamento)
        {
            Medicamento entity = GetMedicamento(idMedicamento);
            _unitOfWork.MedicamentoRepository.Delete(entity);

            return await _unitOfWork.Save() > 0;
        }

        private Medicamento GetMedicamento(int idMedicamento) => _unitOfWork.MedicamentoRepository.FirstOrDefault(x => x.IdMedicamento == idMedicamento);


        #endregion
    }
}
