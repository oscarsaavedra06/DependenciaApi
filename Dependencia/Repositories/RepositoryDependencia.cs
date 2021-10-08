using Dependencia.Data;
using Dependencia.Interfaces;
using Dependencia.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dependencia.Repositories
{
    public class RepositoryDependencia : InterfaceDependencia
    {
        private readonly DependenciaDbContext context;

        public RepositoryDependencia(DependenciaDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var item = await context.dependencias.FirstOrDefaultAsync(x => x.Id == id);
            context.dependencias.Remove(item);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Models.Dependencia>> GetAll()
        {
            return await context.dependencias.ToListAsync();
        }
        public async Task<List<DependenciaEmpleados>> GetAllWithEmployes()
        {
            List<DependenciaEmpleados> result = new List<DependenciaEmpleados>();
            var dependencias = await context.dependencias.ToListAsync();
            foreach (var item in dependencias)
            {
                DependenciaEmpleados obj = new DependenciaEmpleados();
                obj.NombreDependencia = item.NombreDependencia;
                obj.Direccion = item.Direccion;

                using (var client = new HttpClient())
                {
                    var Employes = await client.GetStringAsync($"https://localhost:44349/api/Empleado/GetByIdDependence/{item.Id}");
                    var EmployesList = JsonConvert.DeserializeObject<List<Empleado>>(Employes);
                    obj.empleados = EmployesList;
                }

                result.Add(obj);
            }

            return result;
        }
        public async Task<DependenciaEmpleados> GetWithEmploye(int id)
        {
            DependenciaEmpleados result = new DependenciaEmpleados();
            var dependencia = await context.dependencias.FirstOrDefaultAsync(x => x.Id == id);


            result.NombreDependencia = dependencia.NombreDependencia;
            result.Direccion = dependencia.Direccion;

            using (var client = new HttpClient())
            {
                var Employes = await client.GetStringAsync($"https://localhost:44349/api/Empleado/GetByIdDependence/{dependencia.Id}");
                var EmployesList = JsonConvert.DeserializeObject<List<Empleado>>(Employes);
                result.empleados = EmployesList;
            }

            


            return result;
        }
        public async Task<Models.Dependencia> GetById(int id)
        {
            return await context.dependencias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Post(Models.Dependencia entidad)
        {
            await context.dependencias.AddAsync(entidad);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Put(Models.Dependencia entidad)
        {
            var item = await context.dependencias.FirstOrDefaultAsync(x => x.Id == entidad.Id);
            item.NombreDependencia = entidad.NombreDependencia;
            item.Direccion = entidad.Direccion;
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
