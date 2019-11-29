using Nodus.Elluris.Domain.Models;
using System.Collections.Generic;

namespace Nodus.Elluris.WebApi.Repository
{
    public interface IRepositoryObra
    {
        Obras Find(string Beacon);
        Evento GetEvento();
        IList<Beacon> GetAllBeacons();
    }
}
