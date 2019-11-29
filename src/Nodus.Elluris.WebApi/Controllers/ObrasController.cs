using Microsoft.AspNetCore.Mvc;
using Nodus.Elluris.Domain.Models;
using Nodus.Elluris.WebApi.Repository;

namespace Nodus.Elluris.WebApi.Controllers
{
    [Route("api/[Controller]")]
    public class ObrasController : Controller
    {
        private readonly IRepositoryObra _repositoryObra;

        public ObrasController(IRepositoryObra repoObra)
        {
            _repositoryObra = repoObra;
        }

        [HttpGet]
        public Evento GetEvento()
        {
            return _repositoryObra.GetEvento();
        }

        [HttpGet("{beacon}")]
        public IActionResult GetObra(string beacon)
        {
            var obra = _repositoryObra.Find(beacon);

            return new ObjectResult(obra);

        }
    }
}
