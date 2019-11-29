using Nodus.Elluris.Data.ORM;
using Nodus.Elluris.Domain.Models;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Nodus.Elluris.WebApi.Repository
{
    public class ObraRepository : IRepositoryObra
    {
        private readonly NodusArtDbContext _context;
        public ObraRepository(NodusArtDbContext ctx)
        {
            _context = ctx;
        }
        public Obras Find(string beacon)
        {
            var bc = _context.Beacons.Where(b => b.BeaconCode == beacon).Select(x => x.Id).FirstOrDefault();
            var ob = _context.BeaconObras.Where(bo => bo.Beacon.Id == bc).Select(x => x.Obra.Id).FirstOrDefault();

            var res = (from o in _context.Obras
                       where o.Id == ob
                       select o).FirstOrDefault();

            return res;
        }

        public IList<Beacon> GetAllBeacons()
        {
            var ret = _context.Beacons.ToList();
            if (ret == null)
            {
                return new List<Beacon>();
            }
            return ret;
        }

        public Evento GetEvento()
        {
            var per = _context.EventoPeriodos.Where(d => d.DataInicial <= DateTime.Now && d.DataFinal >= DateTime.Now).FirstOrDefault();
            var eve = _context.Eventos.Where(e => e.EventoPeriodoId == per.Id).FirstOrDefault();
            return eve;
        }

    }
}
