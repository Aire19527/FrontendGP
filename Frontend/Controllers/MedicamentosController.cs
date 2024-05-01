using Domain.Services.Interfaces;
using Infraestrucutre.Core.DTO.Medicamentos;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class MedicamentosController : Controller
    {
        #region Attributes
        private readonly IMedicamentoServices _medicamentoServices;
        #endregion

        #region Builder
        public MedicamentosController(IMedicamentoServices medicamentoServices)
        {
            _medicamentoServices = medicamentoServices;
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
        public IActionResult GetAllMedicamentos()
        {
            List<MedicamentosDto> result = _medicamentoServices.GetAllMedicamentos();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddMedicamentos(AddMedicamentosDto dto)
        {
            bool result = await _medicamentoServices.AddMedicamentos(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMedicamento(MedicamentosDto dto)
        {
            bool result = await _medicamentoServices.UpdateMedicamento(dto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMedicamento(int idMedicamento)
        {
            bool result = await _medicamentoServices.DeleteMedicamento(idMedicamento);
            return Ok(result);
        }
        #endregion


    }
}
