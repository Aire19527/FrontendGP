using Domain.Services.Interfaces;
using Infraestrucutre.Core.DTO.HistoriaClinica;
using Infraestrucutre.Core.DTO.Transversal.Especialista;
using Infraestrucutre.Core.DTO.Transversal.Estado;
using Infraestrucutre.Core.DTO.Transversal.Genero;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class TransversalController : Controller
    {
        #region Attributes
        private readonly ITransversalServices _transversalServices;
        #endregion

        #region Builder
        public TransversalController(ITransversalServices transversalServices)
        {
            _transversalServices = transversalServices;
        }
        #endregion

        #region Services
        [HttpGet]
        public IActionResult GetAllEstados()
        {
            List<EstadoDto> result = _transversalServices.GetAllEstados();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllGeneros()
        {
            List<GeneroDto> result = _transversalServices.GetAllGeneros();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllEspecialistas()
        {
            List<EspecialistaDto> result = _transversalServices.GetAllEspecialistas();
            return Ok(result);
        }

     
        #endregion
    }
}
