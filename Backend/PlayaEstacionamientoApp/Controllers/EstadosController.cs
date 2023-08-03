using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using PlayaEstacionamientoAPI.Models;

namespace PlayaEstacionamientoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IInspectionsService _estacionamientoService;
        private readonly IMapper _mapper;

        public EstadosController(IInspectionsService estacionamientoService, IMapper mapper)
        {
            _estacionamientoService = estacionamientoService;
            _mapper = mapper;
        }

        // GET: api/Estados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
            try
            {
                var estados = await _estacionamientoService.GetEstadosAsync();
                var result = _mapper.Map<List<EstadoModel>>(estados);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Estados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstadoById(int id)
        {
            try
            {
                var estado = await _estacionamientoService.GetEstadoByIdAsync(id);
                var result = _mapper.Map<EstadoModel>(estado);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Estados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, string nombre)
        {
            try
            {
                var estadoEditado = await _estacionamientoService.EditEstadoAsync(id, nombre);
                return Ok(estadoEditado);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        //POST: api/Estados
        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(Estado estado)
        {
            try
            {
                var estadoNuevo = await _estacionamientoService.PostEstadoAsync(estado);
                return Ok(estadoNuevo);
            }
            catch (Exception ex)
            { 
                return StatusCode(500);
            }
        }

        // DELETE: api/Estados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            try
            {
                var deleteResult = await _estacionamientoService.DeleteAEstadoAsync(id);
                if(deleteResult != null)
                {
                    var list = await _estacionamientoService.GetEstadosAsync();
                    var result = _mapper.Map<List<EstadoModel>>(list);
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        } 
    }
}
