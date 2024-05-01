using Domain.Services.Interfaces;
using Infraestrucutre.Core.DTO.CitaMedica;
using Infraestrucutre.Core.DTO.HistoriaClinica;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class CitaMedicaController : Controller
    {
        #region Attributes
        private readonly ICitaMedicaServices _citaMedicaServices;
        private readonly IHistoriaClinicaServices _historiaClinicaServices;
        #endregion

        #region Builder
        public CitaMedicaController(ICitaMedicaServices citaMedicaServices, IHistoriaClinicaServices historiaClinicaServices)
        {
            _citaMedicaServices = citaMedicaServices;
            _historiaClinicaServices = historiaClinicaServices;
        }
        #endregion

        #region Views
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Services
        [HttpGet]
        public IActionResult GetAllCitaMedica()
        {
            List<ConsultCitaMedicaDto> result = _citaMedicaServices.GetAllCitaMedica();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(AddCitaMedicaDto dto)
        {
            bool result = await _citaMedicaServices.AddCitaMedica(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CitaMedicaDto dto)
        {
            bool result = await _citaMedicaServices.UpdateCitaMedica(dto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idCitaMedica)
        {
            bool result = await _citaMedicaServices.DeleteCitaMedica(idCitaMedica);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddHistoriaClinica(AddHistoriaClinicaDto add)
        {
            bool result = await _historiaClinicaServices.AddHistoriaClinica(add);
            return Ok(result);
        }
        #endregion
    }
}
