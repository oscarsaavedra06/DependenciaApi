using Dependencia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dependencia.Interfaces
{
    public interface InterfaceDependencia
    {
        Task<List<Models.Dependencia>> GetAll();
        Task<Models.Dependencia> GetById(int id);
        Task<List<DependenciaEmpleados>> GetAllWithEmployes();
        Task<DependenciaEmpleados> GetWithEmploye(int id);
        Task<bool> Post(Models.Dependencia entidad);
        Task<bool> Put(Models.Dependencia entidad);
        Task<bool> Delete(int id);
    }
}
