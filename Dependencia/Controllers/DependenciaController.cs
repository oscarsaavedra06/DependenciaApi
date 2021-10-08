using Dependencia.Interfaces;
using Dependencia.Models;
using Dependencia.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dependencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependenciaController : ControllerBase
    {
        private readonly InterfaceDependencia repo;

        public DependenciaController(InterfaceDependencia repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<List<Models.Dependencia>> Get()
        {
            return await repo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Models.Dependencia> Get(int id)
        {
            return await repo.GetById(id);
        }

        [HttpGet]
        [Route("GetAllWithEmployes")]
        public async Task<List<DependenciaEmpleados>> GetAllWithEmployes()
        {
            return await repo.GetAllWithEmployes();
        }

        [HttpGet]
        [Route("GetWithEmployes/{id}")]
        public async Task<DependenciaEmpleados> GetWithEmploye(int id)
        {
            return await repo.GetWithEmploye(id);
        }



        [HttpPost]
        public async Task<ActionResult> Post(Models.Dependencia entidad)
        {
            return Ok(await repo.Post(entidad));
        }
        [HttpPut]
        public async Task<ActionResult> Put(Models.Dependencia entidad)
        {
            return Ok(await repo.Put(entidad));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await repo.Delete(id));
        }
    }
}
