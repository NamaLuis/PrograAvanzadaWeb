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
    public class ProveedoresController : ControllerBase
    {
        private readonly restauranteVerdeContext _context;
        private readonly IMapper _mapper;

        public ProveedoresController(restauranteVerdeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Proveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Proveedores>>> GetProveedores()
        {
            var res = new BS.Proveedores(_context).GetAll();
            var mapaux = _mapper.Map<IEnumerable<data.Proveedores>, IEnumerable<DataModels.Proveedores>>(res).ToList();

            return mapaux;
        }

        // GET: api/Proveedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Proveedores>> GetProveedores(int id)
        {
            var proveedores = new BS.Proveedores(_context).GetOneByID(id);
            var mapaux = _mapper.Map<data.Proveedores, DataModels.Proveedores>(proveedores);


            if (proveedores == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Proveedores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedores(int id, DataModels.Proveedores proveedores)
        {
            if (id != proveedores.Id)
            {
                return BadRequest();
            }


            try
            {
                var mapaux = _mapper.Map<DataModels.Proveedores, data.Proveedores>(proveedores);
                new BS.Proveedores(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ProveedoresExists(id))
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

        // POST: api/Proveedores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Proveedores>> PostProveedores(DataModels.Proveedores proveedores)
        {
           var mapaux = _mapper.Map<DataModels.Proveedores, data.Proveedores>(proveedores);
            new BS.Proveedores(_context).Insert(mapaux);

            return CreatedAtAction("GetProveedores", new { id = proveedores.Id }, proveedores);
        }

        // DELETE: api/Proveedores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Proveedores>> DeleteProveedores(int id)
        {
            var proveedores = new BS.Proveedores(_context).GetOneByID(id);
            if (proveedores == null)
            {
                return NotFound();
            }

            new BS.Proveedores(_context).Delete(proveedores);
            var mapaux = _mapper.Map<data.Proveedores, DataModels.Proveedores>(proveedores);

            return mapaux;
        }

        private bool ProveedoresExists(int id)
        {
            return (new BS.Proveedores(_context).GetOneByID(id) != null);
        }
    }
}
