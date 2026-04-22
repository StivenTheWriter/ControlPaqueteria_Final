using Microsoft.AspNetCore.Mvc;
using Paqueteria.Domain.Entities;
using Paqueteria.Domain.Repository;

namespace Paqueteria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentesController : ControllerBase
    {
        private readonly IResidenteRepository _residenteRepo;

        public ResidentesController(IResidenteRepository residenteRepo)
        {
            _residenteRepo = residenteRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Residente>>> Get()
        {
            var residentes = await _residenteRepo.GetAllAsync();
            return Ok(residentes);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Residente residente)
        {
            await _residenteRepo.AddAsync(residente);
            return Ok(new { message = "Residente registrado con éxito" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Residente residente)
        {
            if (id != residente.Id) return BadRequest();
            await _residenteRepo.UpdateAsync(residente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _residenteRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}