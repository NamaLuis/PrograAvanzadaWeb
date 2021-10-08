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
    public class ProductoController : ControllerBase
    {
        private readonly restauranteVerdeContext _context;
        private readonly IMapper _mapper;

        public ProductoController(restauranteVerdeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Producto>>> GetProducto()
        {
            var res = new BS.Producto(_context).GetAll();
            var mapaux = _mapper.Map<IEnumerable<data.Producto>, IEnumerable<DataModels.Producto>>(res).ToList();

            return mapaux;
        }

        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Producto>> GetProducto(int id)
        {
            var producto = new BS.Producto(_context).GetOneByID(id);
            var mapaux = _mapper.Map<data.Producto, DataModels.Producto>(producto);

            if (producto == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Producto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, DataModels.Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }


            try
            {
                var mapaux = _mapper.Map<DataModels.Producto, data.Producto>(producto);
                new BS.Producto(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ProductoExists(id))
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

        // POST: api/Producto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Producto>> PostProducto(DataModels.Producto producto)
        {
            var mapaux = _mapper.Map<DataModels.Producto, data.Producto>(producto);
            new BS.Producto(_context).Insert(mapaux);

            return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
        }

        // DELETE: api/Producto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Producto>> DeleteProducto(int id)
        {
            var producto = new BS.Producto(_context).GetOneByID(id);
            if (producto == null)
            {
                return NotFound();
            }

            new BS.Producto(_context).Delete(producto);
            var mapaux = _mapper.Map<data.Producto, DataModels.Producto>(producto);

            return mapaux;
        }

        private bool ProductoExists(int id)
        {
            return (new BS.Producto(_context).GetOneByID(id) != null);
        }
    }
}
