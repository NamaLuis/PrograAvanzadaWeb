using DAL.DO.Objects;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
   public class RepositoryEmpleado : Repository<data.Empleado>, IRepositoryEmpleado
    {
        public RepositoryEmpleado(restauranteVerdeContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Empleado>> GetAllWithAsAsync()
        {
            return await _db.Empleado
                .Include(m => m.IdPuestoNavigation)
                .ToListAsync();
        }

        public async Task<Empleado> GetOneByIdAsAsync(int id)
        {
            return await _db.Empleado
               .Include(m => m.IdPuestoNavigation)
               .SingleOrDefaultAsync(m => m.IdPuesto == id);
        }
        private restauranteVerdeContext _db
        {
            get { return dbContext as restauranteVerdeContext; }
        }
    }
}
