using API.Models;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace PlayaEstacionamientoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionController : ControllerBase
    {
        private readonly IInspectionsService _inspectionService;
        private readonly IMapper _mapper;

        public InspectionController(IInspectionsService inspectionService, IMapper mapper)
        {
            _inspectionService = inspectionService;
            _mapper = mapper;
        }

        // GET: api/Inspections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inspection>>> GetInspections()
        {
            try
            {
                var inspections = await _inspectionService.GetInspectionsAsync();
                var result = _mapper.Map<List<InspectionModel>>(inspections);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Inspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inspection>> GetInspectionsById(int id)
        {
            try
            {
                var inspection = await _inspectionService.GetInspectionsByIdAsync(id);
                var result = _mapper.Map<InspectionModel>(inspection);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Inspections/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspections(int id, Inspection inspection)
        {
            try
            {
                var inspectionEditado = await _inspectionService.EditInspectionsAsync(id, inspection.Description, inspection.StatusId);
                return Ok(inspectionEditado);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        //POST: api/Inspections
        [HttpPost]
        public async Task<ActionResult<Inspection>> PostInspection(Inspection inspection)
        {
            try
            {
                var estadoNuevo = await _inspectionService.PostInspectionsAsync(inspection);


                return Ok(estadoNuevo);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Inspections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspection(int id)
        {
            try
            {
                var deleteResult = await _inspectionService.DeleteInspectionsAsync(id);
                if (deleteResult != null)
                {
                    var list = await _inspectionService.GetInspectionsAsync();
                    var result = _mapper.Map<List<InspectionModel>>(list);
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
