using Domain.Services.Interfaces;
using Infraestrucutre.Core.DTO.Transversal.Especialista;
using Infraestrucutre.Core.DTO.Transversal.Estado;
using Infraestrucutre.Core.DTO.Transversal.Genero;
using Infraestrucutre.Core.UnitOfWork.Interface;

namespace Domain.Services
{
    public class TransversalServices : ITransversalServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public TransversalServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<EstadoDto> GetAllEstados()
        {
            var list = _unitOfWork.EstadoRepository.GetAll();

            List<EstadoDto> especialiastas = list.Select(x => new EstadoDto()
            {
                Descripcion = x.Descripcion,
                Estado = x.Estado1,
                IdEstado = x.IdEstado,
            }).ToList();

            return especialiastas;
        }

        public List<EspecialistaDto> GetAllEspecialistas()
        {
            var list = _unitOfWork.EspecialistaRepository.GetAll();

            List<EspecialistaDto> especialiastas = list.Select(x => new EspecialistaDto()
            {
                Especialista = x.Especialista,
                IdEspecialista = x.IdEspecialista,
                NombreCompleto = x.NombreCompleto,
                NombreEspecialista = x.NombreEspecialista
            }).ToList();

            return especialiastas;
        }

        public List<GeneroDto> GetAllGeneros()
        {
            var list = _unitOfWork.GeneroRepository.GetAll();

            List<GeneroDto> generos = list.Select(x => new GeneroDto()
            {
                Genero = x.Genero1,
                IdGenero = x.IdGenero,
            }).ToList();

            return generos;
        }
        #endregion
    }
}
