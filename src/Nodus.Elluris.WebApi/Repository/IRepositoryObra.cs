using Nodus.Elluris.Domain.Models;

namespace Nodus.Elluris.WebApi.Repository
{
    public interface IRepositoryObra
    {
        Obras Find(string Beacon);
        Evento GetEvento();
    }
}
