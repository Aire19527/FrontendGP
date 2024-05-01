using Domain.Services.Interfaces;
using Infraestrucutre.Core.DTO.Paciente;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class PacienteController : Controller
    {
        #region Attributes
        private readonly IPacienteServices _pacienteServices;
        #endregion

        #region Builder
        public PacienteController(IPacienteServices pacienteServices)
        {
            _pacienteServices = pacienteServices;
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
        public IActionResult GetAllPaciente()
        {
            List<ConsultPacienteDto> result = _pacienteServices.GetAllPaciente();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(AddPacienteDto dto)
        {
            bool result = await _pacienteServices.AddPaciente(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PacienteDto dto)
        {
            bool result = await _pacienteServices.UpdatePaciente(dto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idPaciente)
        {
            bool result = await _pacienteServices.DeletePaciente(idPaciente);
            return Ok(result);
        }
        #endregion
    }
}
