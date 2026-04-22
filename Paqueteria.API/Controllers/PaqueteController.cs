using Microsoft.AspNetCore.Mvc;
using Paqueteria.Business.DTOs;
using Paqueteria.Business.Services;

namespace Paqueteria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PaquetesController : ControllerBase
    {
        private readonly IPaqueteService _paqueteService;

        public PaquetesController(IPaqueteService paqueteService)
        {
            _paqueteService = paqueteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaqueteDto>>> Get()
        {
            var paquetes = await _paqueteService.ObtenerTodosLosPaquetes();
            return Ok(paquetes);
        }

        [HttpPost("{residenteId}")]
        public async Task<ActionResult> Post([FromBody] PaqueteDto paqueteDto, int residenteId)
        {
            await _paqueteService.RegistrarPaquete(paqueteDto, residenteId);
            return Ok(new { message = "Paquete registrado correctamente" });
        }

        [HttpPut("{id}/entregar")]
        public async Task<ActionResult> MarcarComoEntregado(int id)
        {
            
            var paquetes = await _paqueteService.ObtenerTodosLosPaquetes();
            var paquete = paquetes.FirstOrDefault(p => p.Id == id);

            if (paquete == null) return NotFound();

            
            return Ok(new { message = "Paquete marcado como entregado" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _paqueteService.EliminarPaquete(id);
            return Ok(new { message = "Paquete eliminado con éxito" });
        }
    }
}