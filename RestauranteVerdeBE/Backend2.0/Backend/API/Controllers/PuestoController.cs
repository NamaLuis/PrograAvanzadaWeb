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
    public class PuestoController : ControllerBase
    {
        private readonly restauranteVerdeContext _context;
        private readonly IMapper _mapper;

        public PuestoController(restauranteVerdeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Puesto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Puesto>>> GetPuesto()
        {
            var res = new BS.Puesto(_context).GetAll();
            var mapaux = _mapper.Map<IEnumerable<data.Puesto>, IEnumerable<DataModels.Puesto>>(res).ToList();

            return mapaux;
        }

        // GET: api/Puesto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Puesto>> GetPuesto(int id)
        {
            var puesto = new BS.Puesto(_context).GetOneByID(id);
            var mapaux = _mapper.Map<data.Puesto, DataModels.Puesto>(puesto);


            if (puesto == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Puesto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuesto(int id, DataModels.Puesto puesto)
        {
            if (id != puesto.Id)
            {
                return BadRequest();
            }

            

            try
            {
                var mapaux = _mapper.Map<DataModels.Puesto, data.Puesto>(puesto);
                new BS.Puesto(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!PuestoExists(id))
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

        // POST: api/Puesto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Puesto>> PostPuesto(DataModels.Puesto puesto)
        {
            var mapaux = _mapper.Map<DataModels.Puesto, data.Puesto>(puesto);
            new BS.Puesto(_context).Insert(mapaux);

            return CreatedAtAction("GetPuesto", new { id = puesto.Id }, puesto);
        }

        // DELETE: api/Puesto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Puesto>> DeletePuesto(int id)
        {
            var puesto = new BS.Puesto(_context).GetOneByID(id);
            if (puesto == null)
            {
                return NotFound();
            }

            new BS.Puesto(_context).Delete(puesto);
            var mapaux = _mapper.Map<data.Puesto, DataModels.Puesto>(puesto);

            return mapaux;
        }

        private bool PuestoExists(int id)
        {
            return (new BS.Puesto(_context).GetOneByID(id) != null);
        }
    }
    }

