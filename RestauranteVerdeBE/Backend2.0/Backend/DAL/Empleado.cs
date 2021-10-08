using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
namespace DAL
{
    public class Empleado : ICRUD<data.Empleado>
    {
        private RepositoryEmpleado _repo = null;

        public Empleado(restauranteVerdeContext solutionDbContext)
        {
            _repo = new RepositoryEmpleado(solutionDbContext);
        }
        public void Delete(data.Empleado t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Empleado> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Empleado>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public data.Empleado GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public async Task<data.Empleado> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdAsAsync(id);
        }

        public void Insert(data.Empleado t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Empleado t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
