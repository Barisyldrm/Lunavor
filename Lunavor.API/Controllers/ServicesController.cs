using System.Collections.Generic;
using System.Threading.Tasks;
using Lunavor.Core.Services;
using Lunavor.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lunavor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IService<Service> _service;

        public ServicesController(IService<Service> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            var services = await _service.GetAllAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _service.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<Service>> CreateService(Service service)
        {
            var createdService = await _service.AddAsync(service);
            return CreatedAtAction(nameof(GetService), new { id = createdService.Id }, createdService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(service);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
} 