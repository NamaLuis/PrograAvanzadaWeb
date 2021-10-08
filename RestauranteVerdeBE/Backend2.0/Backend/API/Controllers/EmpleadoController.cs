using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.EF;
using AutoMapper;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly restauranteVerdeContext _context;
        private readonly IMapper _mapper;
        public EmpleadoController(restauranteVerdeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Empleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Empleado>>> GetEmpleado()
        {
            var res = await new BS.Empleado(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Empleado>, IEnumerable<DataModels.Empleado>>(res).ToList();

            return mapaux;
        }

        // GET: api/Empleado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Empleado>> GetEmpleado(int id)
        {
            var empleado = await new BS.Empleado(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Empleado, DataModels.Empleado>(empleado);
            if (empleado == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Empleado/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, DataModels.Empleado empleado)
        {
            if (id != empleado.Cedula)
            {
                return BadRequest();
            }

            

            try
            {
                var mapaux = _mapper.Map<DataModels.Empleado, data.Empleado>(empleado);
                new BS.Empleado(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Empleado
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Empleado>> PostEmpleado(DataModels.Empleado empleado)
        {
            var mapaux = _mapper.Map<DataModels.Empleado, data.Empleado>(empleado);
            new BS.Empleado(_context).Insert(mapaux);
            return CreatedAtAction("GetEmpleado", new { id = empleado.Cedula }, empleado);
        }

        // DELETE: api/Empleado/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Empleado>> DeleteEmpleado(int id)
        {
            var empleado = new BS.Empleado(_context).GetOneByID(id);
            if (empleado == null)
            {
                return NotFound();
            }

            new BS.Empleado(_context).Delete(empleado);
            var mapaux = _mapper.Map<data.Empleado, DataModels.Empleado>(empleado);
            return mapaux;
        }

        private bool EmpleadoExists(int id)
        {
            return (new BS.Empleado(_context).GetOneByID(id) != null);
        }
    }
}

