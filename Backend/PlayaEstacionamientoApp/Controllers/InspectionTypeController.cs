using API.Models;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using PlayaEstacionamientoAPI.Models;

namespace PlayaEstacionamientoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionTypeController : ControllerBase
    {
        private readonly IInspectionsService _inspectionService;
        private readonly IMapper _mapper;

        public InspectionTypeController(IInspectionsService inspectionService, IMapper mapper)
        {
            _inspectionService = inspectionService;
            _mapper = mapper;
        }

        // GET: api/Inspections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectionType>>> GetInspectionTypes()
        {
            try
            {
                var inspectionTypes = await _inspectionService.GetInspectionTypesAsync();
                var result = _mapper.Map<List<InspectionTypeModel>>(inspectionTypes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Inspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionType>> GetInspectionTypesById(int id)
        {
            try
            {
                var inspectionType = await _inspectionService.GetInspectionTypeByIdAsync(id);
                var result = _mapper.Map<InspectionTypeModel>(inspectionType);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Inspections/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspectionTypes(int id, string inspectionName)
        {
            try
            {
                var inspectionEditado = await _inspectionService.EditInspectionTypeAsync(id, inspectionName);
                return Ok(inspectionEditado);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        //POST: api/Inspections
        [HttpPost]
        public async Task<ActionResult<InspectionType>> PostInspectionType(InspectionType inspectionType)
        {
            try
            {
                var inspectionTypeNuevo = await _inspectionService.PostInspectionTypeAsync(inspectionType);
                return Ok(inspectionTypeNuevo);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Inspections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspectionType(int id)
        {
            try
            {
                var deleteResult = await _inspectionService.DeleteInspectionTypeAsync(id);
                if (deleteResult != null)
                {
                    var list = await _inspectionService.GetInspectionTypesAsync();
                    var result = _mapper.Map<List<InspectionTypeModel>>(list);
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
